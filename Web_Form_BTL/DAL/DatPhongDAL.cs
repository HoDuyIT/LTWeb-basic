using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Web_Form_BTL.moDels;
using Web_Form_BTL.moDels.modelView;

namespace Web_Form_BTL.DAL
{
    public class DatPhongDAL
    {
        public List<DatPhong> GetAllDatPhong()
        {
            List<DatPhong> datPhongList = new List<DatPhong>();

            string sql = @"
                SELECT
                    Id,
                    NguoiDungId,
                    LoaiPhongId,
                    NgayNhan,
                    NgayTra,
                    SoKhach,
                    SoPhongDat,
                    TrangThai
                FROM DatPhong;";

            using (SQLiteConnection cnn = DatabaseHelper.OpenConnection())
            using (SQLiteCommand cmd = new SQLiteCommand(sql, cnn))
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    DatPhong datPhong = new DatPhong
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        NguoiDungId = Convert.ToInt32(reader["NguoiDungId"]),
                        LoaiPhongId = Convert.ToInt32(reader["LoaiPhongId"]),
                        NgayNhan = Convert.ToDateTime(reader["NgayNhan"]),
                        NgayTra = Convert.ToDateTime(reader["NgayTra"]),
                        SoKhach = Convert.ToInt32(reader["SoKhach"]),
                        SoPhongDat = Convert.ToInt32(reader["SoPhongDat"]),
                        TrangThai = reader["TrangThai"].ToString()
                    };

                    datPhongList.Add(datPhong);
                }
            }

            return datPhongList;
        }

        public List<LichSuDatPhongView> GetLichSuDatPhong(int nguoiDungId)
        {
            List<LichSuDatPhongView> danhSach =
                new List<LichSuDatPhongView>();

            string sql = @"
                SELECT
                    dp.Id AS MaDatPhong,
                    lp.TenLoai AS TenPhong,
                    ks.HinhAnh AS HinhAnh,
                    dp.TrangThai AS TrangThaiDat,
                    dp.NgayNhan AS NgayNhan,
                    dp.NgayTra AS NgayTra,
                    CAST(
                        julianday(dp.NgayTra) - julianday(dp.NgayNhan)
                        AS INTEGER
                    ) AS SoDem,
                    dp.SoKhach AS SoKhach,
                    dp.TongTien AS TongThanhToan
                FROM DatPhong dp
                INNER JOIN LoaiPhong lp
                    ON dp.LoaiPhongId = lp.Id
                INNER JOIN KhachSan ks
                    ON lp.KhachSanId = ks.Id
                WHERE dp.NguoiDungId = @NguoiDungId
                ORDER BY dp.NgayNhan DESC;";

            using (SQLiteConnection cnn = DatabaseHelper.OpenConnection())
            using (SQLiteCommand cmd = new SQLiteCommand(sql, cnn))
            {
                cmd.Parameters.AddWithValue("@NguoiDungId", nguoiDungId);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LichSuDatPhongView datPhong =
                            new LichSuDatPhongView
                            {
                                MaDatPhong =
                                    Convert.ToInt32(reader["MaDatPhong"]),

                                TenPhong =
                                    reader["TenPhong"].ToString(),

                                HinhAnh =
                                    reader["HinhAnh"] == DBNull.Value
                                        ? ""
                                        : reader["HinhAnh"].ToString(),

                                TrangThaiDat =
                                    reader["TrangThaiDat"].ToString(),

                                NgayNhan =
                                    Convert.ToDateTime(reader["NgayNhan"]),

                                NgayTra =
                                    Convert.ToDateTime(reader["NgayTra"]),

                                SoDem =
                                    Convert.ToInt32(reader["SoDem"]),

                                SoKhach =
                                    Convert.ToInt32(reader["SoKhach"]),

                                TongThanhToan =
                                    Convert.ToDecimal(reader["TongThanhToan"])
                            };

                        danhSach.Add(datPhong);
                    }
                }
            }

            return danhSach;
        }
    }
}