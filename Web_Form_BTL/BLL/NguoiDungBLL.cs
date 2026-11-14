using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Form_BTL.appData;
using Web_Form_BTL.DAL;
using Web_Form_BTL.moDels;

namespace Web_Form_BTL.BLL
{
    public class NguoiDungBLL
    {
        private NguoiDungDAL nguoiDungDAL = new NguoiDungDAL();
        public NguoiDung DangNhap(string tenDangNhap, string matKhau)
        {

            return nguoiDungDAL.DangNhap(tenDangNhap, matKhau);

        }
        public bool DangKy(NguoiDung nguoiDung)
        {
            return nguoiDungDAL.DangKy(nguoiDung);
        }


        public bool CapNhatThongTinQuanTri(
           int id,
           string hoTen,
           string email,
           string soDienThoai,
           string tenDangNhap,
           string matKhau)
        {
            return nguoiDungDAL.CapNhatThongTinQuanTri(
                id,
                hoTen,
                email,
                soDienThoai,
                tenDangNhap,
                matKhau
            );
        }
        public bool CapNhatThongTinCaNhan(
           int id,
           string hoTen,
           string email,
           string soDienThoai)
        {
            return nguoiDungDAL.CapNhatThongTinCaNhan(
                id,
                hoTen,
                email,
                soDienThoai
            );
        }
        
    }
}