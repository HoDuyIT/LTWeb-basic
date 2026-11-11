using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Form_BTL.moDels
{
    public class DatPhong
    {
        public int Id { get; set; }
        public int NguoiDungId { get; set; }
        public int LoaiPhongId { get; set; }
        public DateTime NgayNhan { get; set; }
        public DateTime NgayTra { get; set; }
        public int SoKhach { get; set; }
        public int SoPhongDat { get; set; }
        public string TrangThai { get; set; }
    }
}