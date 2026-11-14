using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Web_Form_BTL.moDels;

namespace Web_Form_BTL.DAL
{
    public class QuanLyKhachSanDAL
    {
        public List<KhachSan> LayDanhSach()
        {
            List<KhachSan> danhSach = new List<KhachSan>();

            string sql = @"
                SELECT Id, Ten, DiaChi, ThanhPho, SoSao, MoTa, HinhAnh, TrangThai
                FROM KhachSan
                ORDER BY Id DESC";

            using (SQLiteConnection conn = DatabaseHelper.OpenConnection())
            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    danhSach.Add(DocKhachSan(reader));
                }
            }

            return danhSach;
        }

        public KhachSan LayTheoId(int id)
        {
            string sql = @"
                SELECT Id, Ten, DiaChi, ThanhPho, SoSao, MoTa, HinhAnh, TrangThai
                FROM KhachSan
                WHERE Id = @Id";

            using (SQLiteConnection conn = DatabaseHelper.OpenConnection())
            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return DocKhachSan(reader);
                    }
                }
            }

            return null;
        }

        private KhachSan DocKhachSan(SQLiteDataReader reader)
        {
            return new KhachSan
            {
                Id = Convert.ToInt32(reader["Id"]),
                Ten = reader["Ten"].ToString(),
                DiaChi = reader["DiaChi"].ToString(),
                ThanhPho = reader["ThanhPho"].ToString(),
                SoSao = reader["SoSao"] == DBNull.Value
                    ? 0
                    : Convert.ToInt32(reader["SoSao"]),
                MoTa = reader["MoTa"].ToString(),
                HinhAnh = reader["HinhAnh"].ToString(),
                TrangThai = reader["TrangThai"].ToString()
            };
        }

        public bool ThemKhachSan(KhachSan khachSan, int chuSoHuuId)
        {
            using (SQLiteConnection conn = DatabaseHelper.OpenConnection())
            {
                string sqlKiemTraCot = @"
                    SELECT COUNT(*)
                    FROM pragma_table_info('KhachSan')
                    WHERE name = 'ChuSoHuuId' COLLATE NOCASE";

                bool coCotChuSoHuu;

                using (SQLiteCommand cmdKiemTra = new SQLiteCommand(sqlKiemTraCot, conn))
                {
                    coCotChuSoHuu = Convert.ToInt32(cmdKiemTra.ExecuteScalar()) > 0;
                }

                string cotChuSoHuu = coCotChuSoHuu ? ", ChuSoHuuId" : "";
                string giaTriChuSoHuu = coCotChuSoHuu ? ", Id" : "";

                string sql = $@"
                    INSERT INTO KhachSan
                        (Ten, DiaChi, ThanhPho, SoSao, MoTa, HinhAnh, TrangThai{cotChuSoHuu})
                    SELECT
                        @Ten, @DiaChi, @ThanhPho, @SoSao, @MoTa, @HinhAnh,
                        @TrangThai{giaTriChuSoHuu}
                    FROM NguoiDung  
                    WHERE Id = @AdminId AND VaiTro = 'Admin'";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    GanThongTinKhachSan(cmd, khachSan);
                    cmd.Parameters.AddWithValue("@AdminId", chuSoHuuId);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        public bool SuaKhachSan(KhachSan khachSan)
        {
            string sql = @"
                UPDATE KhachSan
                SET Ten = @Ten,
                    DiaChi = @DiaChi,
                    ThanhPho = @ThanhPho,
                    SoSao = @SoSao,
                    MoTa = @MoTa,
                    HinhAnh = @HinhAnh,
                    TrangThai = @TrangThai
                WHERE Id = @Id";

            using (SQLiteConnection conn = DatabaseHelper.OpenConnection())
            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            {
                GanThongTinKhachSan(cmd, khachSan);
                cmd.Parameters.AddWithValue("@Id", khachSan.Id);

                return cmd.ExecuteNonQuery() == 1;
            }
        }

        public bool XoaKhachSan(int id)
        {
            string sql = @"
                DELETE FROM KhachSan
                WHERE Id = @Id
                  AND NOT EXISTS (
                      SELECT 1
                      FROM LoaiPhong
                      WHERE KhachSanId = @Id
                  )";

            return DatabaseHelper.ExecuteNonQuery(
                sql, new SQLiteParameter("@Id", id)
            ) == 1;
        }

        private void GanThongTinKhachSan(SQLiteCommand cmd, KhachSan khachSan)
        {
            cmd.Parameters.AddWithValue("@Ten", khachSan.Ten);
            cmd.Parameters.AddWithValue("@DiaChi", khachSan.DiaChi);
            cmd.Parameters.AddWithValue("@ThanhPho", khachSan.ThanhPho);
            cmd.Parameters.AddWithValue("@SoSao", khachSan.SoSao);
            cmd.Parameters.AddWithValue("@MoTa", khachSan.MoTa);
            cmd.Parameters.AddWithValue("@HinhAnh", khachSan.HinhAnh);
            cmd.Parameters.AddWithValue("@TrangThai", khachSan.TrangThai);
        }
    }
}