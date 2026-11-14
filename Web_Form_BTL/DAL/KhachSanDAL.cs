using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using Web_Form_BTL.moDels;
using Web_Form_BTL.moDels.modelView;

namespace Web_Form_BTL.DAL
{
    public class KhachSanDAL
    {
        public static string queryNomal(string LoaiPhong, string SoNguoi, int? idKhachSan, int? idLoaiPhong, string where)
        {
            if (!string.IsNullOrEmpty(LoaiPhong))
            {
                where += " AND lp.TenLoai LIKE '%" + LoaiPhong + "%' ";
            }

            if (!string.IsNullOrEmpty(SoNguoi))
            {
                where += " AND lp.SoNguoiToiDa = " + SoNguoi + " ";
            }

            if (idKhachSan.HasValue)//kiem tra null hay khogn la qua thang hash nay neu co data thi true, nguoc lai false
            {
                where += " AND ks.Id = " + idKhachSan.Value + " ";
            }

            if (idLoaiPhong.HasValue)
            {
                where += " AND lp.Id = " + idLoaiPhong.Value + " ";
            }
            return where;
        }

        public List<KhachSanView> GetAllKhachSanViews(string LoaiPhong = null, string SoNguoi = null, int? idKhachSan = null, int? idLoaiPhong = null)
        {
            List<KhachSanView> khachSanViewList = new List<KhachSanView>();


            String sql = @" SELECT ks.Id as idKhachSan , ks.Ten, ks.DiaChi, ks.SoSao, ks.HinhAnh, ks.MoTa, 
                        lp.GiaMoiDem AS GiaTu,lp.TenLoai,lp.SoNguoiToiDa,lp.TienNghi,lp.Id as idLoaiPhong 
                        FROM KhachSan ks
                        LEFT JOIN LoaiPhong lp ON ks.Id = lp.KhachSanId ";

            String where = " Where 1=1 ";

            where = queryNomal(LoaiPhong, SoNguoi, idKhachSan, idLoaiPhong, where);


            sql += where;

            using (SQLiteConnection cnn = DatabaseHelper.OpenConnection())
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, cnn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            KhachSanView khachSanView = new KhachSanView
                            {
                                idKhachSan = reader["idKhachSan"] == DBNull.Value
                                        ? 0 : Convert.ToInt32(reader["idKhachSan"]),

                                Ten = reader["Ten"] == DBNull.Value
                                        ? "" : reader["Ten"].ToString(),

                                DiaChi = reader["DiaChi"] == DBNull.Value
                                        ? "" : reader["DiaChi"].ToString(),

                                SoSao = reader["SoSao"] == DBNull.Value
                                        ? 0 : Convert.ToInt32(reader["SoSao"]),

                                HinhAnh = reader["HinhAnh"] == DBNull.Value
                                        ? "" : reader["HinhAnh"].ToString(),

                                MoTa = reader["MoTa"] == DBNull.Value
                                        ? "" : reader["MoTa"].ToString(),

                                GiaTu = reader["GiaTu"] == DBNull.Value
                                        ? 0 : Convert.ToDecimal(reader["GiaTu"]),

                                TenLoai = reader["TenLoai"] == DBNull.Value
                                        ? "" : reader["TenLoai"].ToString(),

                                SoNguoiToiDa = reader["SoNguoiToiDa"] == DBNull.Value
                                        ? 0 : Convert.ToInt32(reader["SoNguoiToiDa"]),

                                TienNghi = reader["TienNghi"] == DBNull.Value
                                        ? "" : reader["TienNghi"].ToString(),

                                idLoaiPhong = reader["idLoaiPhong"] == DBNull.Value
                                        ? 0 : Convert.ToInt32(reader["idLoaiPhong"])
                            };
                            khachSanViewList.Add(khachSanView);
                        }
                    }
                }
            }
            return khachSanViewList;
        }

        List<KhachSan> GetAllKhachSan()
        {
            List<KhachSan> khachSanList = new List<KhachSan>();
            String sql = "SELECT * FROM KhachSan";
            using (SQLiteConnection cnn = DatabaseHelper.OpenConnection())
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, cnn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            KhachSan khachSan = new KhachSan
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Ten = reader["Ten"].ToString(),
                                DiaChi = reader["DiaChi"].ToString(),
                                ThanhPho = reader["ThanhPho"].ToString(),
                                SoSao = Convert.ToInt32(reader["SoSao"]),
                                MoTa = reader["MoTa"].ToString(),
                                HinhAnh = reader["HinhAnh"].ToString(),
                                TrangThai = reader["TrangThai"].ToString()
                            };
                            khachSanList.Add(khachSan);
                        }
                    }
                }
            }
            return khachSanList;
        }



    }
}