using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Form_BTL.moDels.modelView
{
    public class KhachSanView
    {
        // Thông tin từ bảng KhachSan
        public int idKhachSan { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public int SoSao { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }

        // Thông tin tổng hợp từ bảng LoaiPhong
        public decimal GiaTu { get; set; }
        public string TenLoai { get; set; }
        public int SoNguoiToiDa { get; set; }
        public string TienNghi { get; set; } 
        public int idLoaiPhong { get; set; }
    }
}