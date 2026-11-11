using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Web;
using Web_Form_BTL.moDels;

namespace Web_Form_BTL.DAL
{
    public class DatPhongDAL
    {
        public List<DatPhong> GetAllDatPhong()
        {
              List<DatPhong> datPhongList = new List<DatPhong>();
            string sql = "SELECT * FROM DatPhong";
            using (SQLiteConnection cnn = DatabaseHelper.OpenConnection())
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, cnn))
                {
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
                }
            }
            return datPhongList;
        }
    }
}