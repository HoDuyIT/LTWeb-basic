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

        private string Grid_Load(string LoaiPhong,string SoNguoi)
        {
            KhachSanBLL khachSanBLL = new KhachSanBLL();
            List<KhachSanView> danhSach =
                khachSanBLL.GetAllKhachSanViews(LoaiPhong, SoNguoi);

            rpKhachSan.DataSource = danhSach;
            rpKhachSan.DataBind();
            return danhSach.Count.ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string LoaiPhong = null;
                string SoNguoi = null;

                NguoiDung nguoiDung = Session["NguoiDung"] as NguoiDung;
                string soluongKhachSan = Grid_Load(LoaiPhong,SoNguoi);

                lblTongSearch.Text = soluongKhachSan;

                
            }
        }
        protected void btnTimKiem_Click(object sender, EventArgs e)
        {

            string loaiPhong = txtLoaiPhong.Text.Trim();
            
            string SoNguoi = ddlSoNguoi.SelectedValue.Trim();

            loaiPhong = "Phòng " + loaiPhong;

            string soluongKhachSan = Grid_Load(loaiPhong, SoNguoi);

            lblTongSearch.Text = soluongKhachSan;

        }
    }
}