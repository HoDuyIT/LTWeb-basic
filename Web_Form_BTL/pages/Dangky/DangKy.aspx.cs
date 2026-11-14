using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Form_BTL.BLL;
using Web_Form_BTL.moDels;

namespace Web_Form_BTL.pages.Dangky
{
    public partial class DangKy : System.Web.UI.Page
    {
        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string email = txtEmail.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();
            string matKhau = txtMatKhau.Text;

            if (string.IsNullOrWhiteSpace(tenDangNhap) ||
                string.IsNullOrWhiteSpace(matKhau) ||
                string.IsNullOrWhiteSpace(hoTen))
            {
                lblThongBao.Text =
                    "Vui lòng nhập tên đăng nhập, mật khẩu và họ tên.";
                return;
            }

            NguoiDung nguoiDung = new NguoiDung
            {
                TenDangNhap = tenDangNhap,
                MatKhau = matKhau,
                HoTen = hoTen,
                Email = email,
                SoDienThoai = soDienThoai,
                VaiTro = "KhachHang"
            };

            NguoiDungBLL nguoiDungBLL = new NguoiDungBLL();
            bool thanhCong = nguoiDungBLL.DangKy(nguoiDung);

            if (thanhCong)
            {
                Response.Redirect(
                    "~/pages/DangNhap/DangNhap.aspx",
                    false
                );

                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                lblThongBao.Text =
                    "Tên đăng nhập này đã được sử dụng.";
            }
        }
    }
}