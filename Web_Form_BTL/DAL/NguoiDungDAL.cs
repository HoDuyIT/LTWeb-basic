using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using Web_Form_BTL.DAL;
using Web_Form_BTL.moDels;

namespace Web_Form_BTL.appData
{
    public class NguoiDungDAL
    {
        public NguoiDung DangNhap(string tenDangNhap, string matKhau)
        {
            NguoiDung nguoiDung = null;
            string sql = "SELECT * FROM NguoiDung WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";
            using (SQLiteConnection conn = DatabaseHelper.OpenConnection())
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nguoiDung = new NguoiDung
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                TenDangNhap = reader["TenDangNhap"].ToString(),
                                MatKhau = reader["MatKhau"].ToString(),
                                HoTen = reader["HoTen"].ToString(),
                                Email = reader["Email"].ToString(),
                                SoDienThoai = reader["SoDienThoai"].ToString(),
                                VaiTro = reader["VaiTro"].ToString()
                            };
                        }
                    }
                }
            }
            return nguoiDung;
        }
        public List<NguoiDung> GetAllNguoiDung()
        {
            List<NguoiDung> nguoiDungList = new List<NguoiDung>();
            String sql = "SELECT * FROM NguoiDung";

            using (SQLiteConnection conn = DatabaseHelper.OpenConnection())
            {
                using(SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NguoiDung nguoiDung = new NguoiDung
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                TenDangNhap = reader["TenDangNhap"].ToString(),
                                MatKhau = reader["MatKhau"].ToString(),
                                HoTen = reader["HoTen"].ToString(),
                                Email = reader["Email"].ToString(),
                                SoDienThoai = reader["SoDienThoai"].ToString(),
                                VaiTro = reader["VaiTro"].ToString()
                            };
                            nguoiDungList.Add(nguoiDung);
                        }
                    }
                }
            }
            return nguoiDungList;
        }
    }
}