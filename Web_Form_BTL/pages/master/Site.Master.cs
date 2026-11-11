using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Form_BTL.moDels;

namespace Web_Form_BTL.pages.master
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NguoiDung nguoiDung = Session["NguoiDung"] as NguoiDung;
            //chua dang nhap
            if(nguoiDung == null)
            {
                LinkLichSuDatPhong.Visible = false;
                LinkTaiKhoan.Visible = false;
                LinkQLPhong.Visible = false;
                LinkDangNhap.Visible = true;
                LinkQLDatPhong.Visible = false;
                LinkQLKhachHang.Visible = false;
            }
            else
            {
                if(nguoiDung.VaiTro == "Admin")
                {
                    LinkTaiKhoan.Visible = true;
                    LinkTaiKhoan.Text = "Xin Chao: " + nguoiDung.TenDangNhap;
                    LinkLichSuDatPhong.Visible = false;
                    LinkDangNhap.Visible = false;
                    LinkQLKhachHang.Visible = true;
                    LinkQLDatPhong.Visible = true;
                    LinkQLPhong.Visible = true;

                }
                else
                {
                    LinkTaiKhoan.Visible = true;
                    LinkTaiKhoan.Text = "Xin Chao: " + nguoiDung.TenDangNhap;
                    LinkLichSuDatPhong.Visible = true;
                    LinkDangNhap.Visible = false;
                    LinkQLKhachHang.Visible = false;
                    LinkQLDatPhong.Visible = false;
                    LinkQLPhong.Visible = false;
                }
            }
            
        }
    }
}