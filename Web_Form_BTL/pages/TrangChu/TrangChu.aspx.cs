using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Form_BTL.BLL;
using Web_Form_BTL.moDels.modelView;
using Web_Form_BTL.moDels;
namespace Web_Form_BTL.pages.TrangChu
{
    public partial class TrangChu : System.Web.UI.Page
    {
        private void Grid_Load()
        {
            KhachSanBLL khachSanBLL = new KhachSanBLL();
            List<KhachSanView> danhSach =
                khachSanBLL.GetAllKhachSanViews();

            rpKhachSan.DataSource = danhSach;
            rpKhachSan.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NguoiDung nguoiDung = Session["NguoiDung"] as NguoiDung;
                Grid_Load();

                
            }
        }
        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/QuanTri/QuanTri.aspx");
        }
    }
}