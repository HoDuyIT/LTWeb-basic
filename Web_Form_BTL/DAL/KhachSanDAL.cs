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

        public List<KhachSanView> GetAllKhachSanViews()
        {
            List<KhachSanView> khachSanViewList = new List<KhachSanView>();
            String sql = @"SELECT ks.Id, ks.Ten, ks.DiaChi, ks.SoSao, ks.HinhAnh, ks.MoTa, MIN(lp.GiaMoiDem) AS GiaTu
                        FROM KhachSan ks
                        LEFT JOIN LoaiPhong lp ON ks.Id = lp.KhachSanId
                        GROUP BY ks.Id, ks.Ten, ks.DiaChi, ks.SoSao, ks.HinhAnh, ks.MoTa";
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
                                Id = Convert.ToInt32(reader["Id"]),
                                Ten = reader["Ten"].ToString(),
                                DiaChi = reader["DiaChi"].ToString(),
                                SoSao = Convert.ToInt32(reader["SoSao"]),
                                HinhAnh = reader["HinhAnh"].ToString(),
                                MoTa = reader["MoTa"].ToString(),
                                GiaTu = reader["GiaTu"] == DBNull.Value
                                    ? 0
                                    : Convert.ToDecimal(reader["GiaTu"])
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
            using(SQLiteConnection cnn = DatabaseHelper.OpenConnection())
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