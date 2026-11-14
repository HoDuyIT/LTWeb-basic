using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Form_BTL.moDels.modelView
{
    public class KhachHangView
    {
        public int Id { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }

        public int SoDem { get; set; }
        public decimal TongThanhToan { get; set; }


    }
}