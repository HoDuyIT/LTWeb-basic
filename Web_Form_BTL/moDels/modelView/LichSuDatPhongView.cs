using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    namespace Web_Form_BTL.moDels.modelView
    {
        public class LichSuDatPhongView
        {
            public int MaDatPhong { get; set; }
            public string TenPhong { get; set; }
            public string HinhAnh { get; set; }
            public string TrangThaiDat { get; set; }
            public DateTime NgayNhan { get; set; }
            public DateTime NgayTra { get; set; }
            public int SoDem { get; set; }
            public int SoKhach { get; set; }
            public decimal TongThanhToan { get; set; }
        }
    }