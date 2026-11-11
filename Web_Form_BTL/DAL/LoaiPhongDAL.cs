using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using Web_Form_BTL.moDels;


namespace Web_Form_BTL.DAL
{
    public class LoaiPhongDAL
    {
        public List<LoaiPhong> GetAllLoaiPhong()
        {
            List<LoaiPhong> loaiPhongList = new List<LoaiPhong>();
            string sql = "SELECT * FROM LoaiPhong";
            using(SQLiteConnection cnn = DatabaseHelper.OpenConnection())
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, cnn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LoaiPhong loaiPhong = new LoaiPhong
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                KhachSanId = Convert.ToInt32(reader["KhachSanId"]),
                                TenLoai = reader["TenLoai"].ToString(),
                                SoNguoiToiDa = Convert.ToInt32(reader["SoNguoiToiDa"]),
                                SoLuongPhong = Convert.ToInt32(reader["SoLuongPhong"]),
                                TienNghi = reader["TienNghi"].ToString()
                            };
                            loaiPhongList.Add(loaiPhong);
                        }
                    }
                }
            }
            return loaiPhongList;
        }
    }
}