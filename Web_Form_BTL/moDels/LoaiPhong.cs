using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Form_BTL.moDels
{
    public class LoaiPhong
    {
        public int Id { get; set; }
        public int KhachSanId { get; set; }
        public string TenLoai { get; set; }
        public int SoNguoiToiDa { get; set; }
        public int SoLuongPhong { get; set; }
        public string TienNghi { get; set; }
    }
}