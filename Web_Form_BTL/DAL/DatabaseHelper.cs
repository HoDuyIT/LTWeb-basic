using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace Web_Form_BTL.DAL
{
    public class DatabaseHelper
    {
        // Đường dẫn tới file database
        private static string GetConnectionString()
        {
            string dbPath = HttpContext.Current.Server.MapPath(
                "~/appData/HotelBooking.db"
            );

            System.Diagnostics.Debug.WriteLine("DATABASE PATH: " + dbPath);

            return "Data Source=" + dbPath + ";Version=3;";
        }



        // Mở kết nối tới database
        public static SQLiteConnection OpenConnection()
        {
            SQLiteConnection connection =
                new SQLiteConnection(GetConnectionString());

            connection.Open();

            using (SQLiteCommand command =
                new SQLiteCommand("PRAGMA foreign_keys = ON;", connection)) // kiểm tra và bật chế độ khóa ngoại
            {
                command.ExecuteNonQuery();
            }

            return connection;
        }

        public static void DatabaseInttalizer()  //tao cac bang trong database
        {
            using (SQLiteConnection conn = OpenConnection())
            {
                // Bảng người dùng
                string sqlNguoiDung = @"
                    CREATE TABLE IF NOT EXISTS NguoiDung
                    (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        TenDangNhap TEXT NOT NULL UNIQUE,
                        MatKhau TEXT NOT NULL,
                        HoTen TEXT NOT NULL,
                        Email TEXT,
                        SoDienThoai TEXT,
                        VaiTro TEXT NOT NULL
                    );
                ";

                // Bảng khách sạn
                string sqlKhachSan = @"
                    CREATE TABLE IF NOT EXISTS KhachSan
                    (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Ten TEXT NOT NULL,
                        DiaChi TEXT NOT NULL,
                        ThanhPho TEXT NOT NULL,
                        SoSao INTEGER CHECK(SoSao BETWEEN 1 AND 5),
                        MoTa TEXT,
                        HinhAnh TEXT,
                        ChuSoHuuId INTEGER NOT NULL,
                        TrangThai TEXT NOT NULL,

                        FOREIGN KEY (ChuSoHuuId)
                        REFERENCES NguoiDung(Id)
                    );
                ";

                // Bảng loại phòng
                string sqlLoaiPhong = @"
                    CREATE TABLE IF NOT EXISTS LoaiPhong
                    (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        KhachSanId INTEGER NOT NULL,
                        TenLoai TEXT NOT NULL,
                        SoNguoiToiDa INTEGER NOT NULL CHECK(SoNguoiToiDa > 0),
                        GiaMoiDem INTEGER NOT NULL CHECK(GiaMoiDem >= 0),
                        SoLuongPhong INTEGER NOT NULL CHECK(SoLuongPhong >= 0),
                        TienNghi TEXT,

                        FOREIGN KEY (KhachSanId)
                        REFERENCES KhachSan(Id)
                    );
                ";

                // Bảng đặt phòng
                string sqlDatPhong = @"
                    CREATE TABLE IF NOT EXISTS DatPhong
                    (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        NguoiDungId INTEGER NOT NULL,
                        LoaiPhongId INTEGER NOT NULL,
                        NgayNhan TEXT NOT NULL,
                        NgayTra TEXT NOT NULL,
                        SoKhach INTEGER NOT NULL CHECK(SoKhach > 0),
                        SoPhongDat INTEGER NOT NULL CHECK(SoPhongDat > 0),
                        TongTien INTEGER NOT NULL CHECK(TongTien >= 0),
                        TrangThai TEXT NOT NULL,

                        CHECK(NgayTra > NgayNhan),

                        FOREIGN KEY (NguoiDungId)
                        REFERENCES NguoiDung(Id),

                        FOREIGN KEY (LoaiPhongId)
                        REFERENCES LoaiPhong(Id)
                    );
                ";

                // Thực thi lần lượt các câu lệnh SQL
                string[] danhSachSQL =
                {
                    sqlNguoiDung,
                    sqlKhachSan,
                    sqlLoaiPhong,
                    sqlDatPhong
                };

                foreach (string sql in danhSachSQL)
                {
                    using (SQLiteCommand command = new SQLiteCommand(sql, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        

        public static int ExecuteNonQuery(String sql, params SQLiteParameter[] parameters) //thuc hienj cac cau lenh insert, update, delete -- parameters: tham so truyen vao cau lenh sql
        {
            using (SQLiteConnection conn = OpenConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    return command.ExecuteNonQuery(); // Trả về số lượng bản ghi bị ảnh hưởng
                }
            }
        }
    }
}