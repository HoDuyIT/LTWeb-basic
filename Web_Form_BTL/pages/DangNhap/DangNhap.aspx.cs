using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Form_BTL.BLL;

namespace Web_Form_BTL.moDels
{
    public partial class DangNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text;
            string password = txtMatKhau.Text;

            // Thực hiện kiểm tra đăng nhập ở đây

            NguoiDungBLL nguoiDungBLL = new NguoiDungBLL();
            NguoiDung nguoiDung = nguoiDungBLL.DangNhap(username, password);
            if(nguoiDung != null)
            {
                Session["NguoiDung"] = nguoiDung; 
                Response.Redirect("~/pages/TrangChu/TrangChu.aspx"); 
            }
            else
            {
                lblThongBao.Text = "Tên đăng nhập hoặc mật khẩu không đúng.";
            }
        }
    }
}