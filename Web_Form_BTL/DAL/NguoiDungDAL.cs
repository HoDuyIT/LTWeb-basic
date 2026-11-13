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
        public bool DangKy(NguoiDung nguoiDung)
        {
            using (SQLiteConnection conn = DatabaseHelper.OpenConnection())
            {
                // Kiểm tra tên đăng nhập đã được sử dụng chưa.
                string sqlKiemTra = @"
                    SELECT COUNT(*)
                    FROM NguoiDung
                    WHERE TenDangNhap = @TenDangNhap;";

                using (SQLiteCommand cmdKiemTra =
                    new SQLiteCommand(sqlKiemTra, conn))
                {
                    cmdKiemTra.Parameters.AddWithValue(
                        "@TenDangNhap",
                        nguoiDung.TenDangNhap
                    );

                    long soTaiKhoan =
                        Convert.ToInt64(cmdKiemTra.ExecuteScalar());

                    if (soTaiKhoan > 0)
                    {
                        return false;
                    }
                }

                // Thêm tài khoản mới. VaiTro được đặt cố định là KhachHang.
                string sqlThem = @"
                    INSERT INTO NguoiDung
                        (TenDangNhap, MatKhau, HoTen, Email, SoDienThoai, VaiTro)
                    VALUES
                        (@TenDangNhap, @MatKhau, @HoTen, @Email, @SoDienThoai, @VaiTro);";

                using (SQLiteCommand cmdThem =
                    new SQLiteCommand(sqlThem, conn))
                {
                    cmdThem.Parameters.AddWithValue(
                        "@TenDangNhap", nguoiDung.TenDangNhap);

                    cmdThem.Parameters.AddWithValue(
                        "@MatKhau", nguoiDung.MatKhau);

                    cmdThem.Parameters.AddWithValue(
                        "@HoTen", nguoiDung.HoTen);

                    cmdThem.Parameters.AddWithValue(
                        "@Email",
                        string.IsNullOrWhiteSpace(nguoiDung.Email)
                            ? (object)DBNull.Value
                            : nguoiDung.Email);

                    cmdThem.Parameters.AddWithValue(
                        "@SoDienThoai",
                        string.IsNullOrWhiteSpace(nguoiDung.SoDienThoai)
                            ? (object)DBNull.Value
                            : nguoiDung.SoDienThoai);

                    cmdThem.Parameters.AddWithValue(
                        "@VaiTro", "KhachHang");

                    return cmdThem.ExecuteNonQuery() > 0;
                }
            }
        }

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
        public bool CapNhatThongTinCaNhan(
    int id,
    string hoTen,
    string email,
    string soDienThoai)
        {
            string sql = @"
        UPDATE NguoiDung
        SET
            HoTen = @HoTen,
            Email = @Email,
            SoDienThoai = @SoDienThoai
        WHERE Id = @Id;";

            using (SQLiteConnection conn = DatabaseHelper.OpenConnection())
            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@HoTen", hoTen);

                cmd.Parameters.AddWithValue(
                    "@Email",
                    string.IsNullOrWhiteSpace(email)
                        ? (object)DBNull.Value
                        : email
                );

                cmd.Parameters.AddWithValue(
                    "@SoDienThoai",
                    string.IsNullOrWhiteSpace(soDienThoai)
                        ? (object)DBNull.Value
                        : soDienThoai
                );

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}