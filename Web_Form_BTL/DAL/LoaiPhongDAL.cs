using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Web_Form_BTL.moDels;

namespace Web_Form_BTL.DAL
{
    public class LoaiPhongDAL
    {
        public List<LoaiPhong> GetAllLoaiPhong()
        {
            List<LoaiPhong> danhSach = new List<LoaiPhong>();

            string sql = @"
                SELECT lp.*, ks.Ten AS TenKhachSan, ks.DiaChi, ks.HinhAnh
                FROM LoaiPhong lp
                INNER JOIN KhachSan ks ON ks.Id = lp.KhachSanId
                ORDER BY ks.Ten, lp.TenLoai, lp.Id";

            using (SQLiteConnection conn = DatabaseHelper.OpenConnection())
            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    LoaiPhong phong = new LoaiPhong
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        KhachSanId = Convert.ToInt32(reader["KhachSanId"]),
                        TenLoai = reader["TenLoai"].ToString(),
                        SoNguoiToiDa = Convert.ToInt32(reader["SoNguoiToiDa"]),
                        GiaMoiDem = Convert.ToInt64(reader["GiaMoiDem"]),
                        SoLuongPhong = Convert.ToInt32(reader["SoLuongPhong"]),
                        TienNghi = reader["TienNghi"].ToString(),
                        TenKhachSan = reader["TenKhachSan"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        HinhAnh = reader["HinhAnh"].ToString()
                    };

                    danhSach.Add(phong);
                }
            }

            return danhSach;
        }

        public List<KhachSan> LayDanhSachKhachSan()
        {
            List<KhachSan> danhSach = new List<KhachSan>();

            string sql = "SELECT Id, Ten FROM KhachSan ORDER BY Ten, Id";

            using (SQLiteConnection conn = DatabaseHelper.OpenConnection())
            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    KhachSan khachSan = new KhachSan
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Ten = reader["Ten"].ToString()
                    };

                    danhSach.Add(khachSan);
                }
            }

            return danhSach;
        }

        public bool ThemLoaiPhong(LoaiPhong phong)
        {
            string sql = @"
                INSERT INTO LoaiPhong
                    (KhachSanId, TenLoai, SoNguoiToiDa, GiaMoiDem, SoLuongPhong, TienNghi)
                SELECT Id, @TenLoai, @SoNguoi, @Gia, @SoLuong, @TienNghi
                FROM KhachSan
                WHERE Id = @KhachSanId";

            int soDong = DatabaseHelper.ExecuteNonQuery(
                sql,
                new SQLiteParameter("@KhachSanId", phong.KhachSanId),
                new SQLiteParameter("@TenLoai", phong.TenLoai),
                new SQLiteParameter("@SoNguoi", phong.SoNguoiToiDa),
                new SQLiteParameter("@Gia", phong.GiaMoiDem),
                new SQLiteParameter("@SoLuong", phong.SoLuongPhong),
                new SQLiteParameter("@TienNghi", phong.TienNghi)
            );

            return soDong == 1;
        }
    }
}