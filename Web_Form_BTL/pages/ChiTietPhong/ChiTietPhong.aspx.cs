using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Form_BTL.moDels.modelView;
using Web_Form_BTL.BLL;

namespace Web_Form_BTL.pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<KhachSanView> ds()
        {
            int idKhachSan = Convert.ToInt32(Request.QueryString["idKhachSan"]);
            int idLoaiPhong = Convert.ToInt32(Request.QueryString["idLoaiPhong"]);

            List<KhachSanView> danhSach = new List<KhachSanView>();

            KhachSanBLL khachSanBLL = new KhachSanBLL();
            danhSach = khachSanBLL.GetAllKhachSanViews(idKhachSan: idKhachSan, idLoaiPhong: idLoaiPhong);
            return danhSach;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            List<KhachSanView> danhSach = new List<KhachSanView>();
            danhSach = ds();

            string dateNhan = Request.QueryString["ngayNhan"];
            string dateTra = Request.QueryString["ngayTra"];

            txtNgayNhan.Text = dateNhan;
            txtNgayTra.Text = dateTra;

            decimal giaPhong = danhSach[0].GiaTu;

            hdnGiaPhong.Value = giaPhong.ToString(
                System.Globalization.CultureInfo.InvariantCulture
            );

            txtSoKhach.Text = danhSach[0].SoNguoiToiDa.ToString();
            txtSoKhach.Attributes["max"] = danhSach[0].SoNguoiToiDa.ToString();
            txtSoKhach.Attributes["min"] = 0.ToString();

            lblTenKhachSan.Text = danhSach[0].Ten;
            lblTenLoaiPhong.Text = danhSach[0].TenLoai;
            lblGiaPhong.Text = danhSach[0].GiaTu.ToString("N0") + " VNĐ";
            lblLoaiPhong.Text = danhSach[0].TenLoai;
            lblSoNguoiToiDa.Text = danhSach[0].SoNguoiToiDa.ToString();
            lblTienNghi.Text = danhSach[0].TienNghi;
            lblMoTa.Text = danhSach[0].MoTa;
            imgAnhNho1.ImageUrl = "~/pages/image/" + danhSach[0].HinhAnh+"";
            imgAnhChinh.ImageUrl = "~/pages/image/" + danhSach[0].HinhAnh+"";

            
            lblTenKhachSanModal.Text = danhSach[0].Ten;
            lblTenPhongModal.Text = danhSach[0].TenLoai;
            modalSoKhach.Text = txtSoKhach.Text;
            lblGiaModal.Text = danhSach[0].GiaTu.ToString("N0") + " VNĐ";
            
        }

        
        protected void btnXacNhanDatPhong_Click(object sender, EventArgs e)
        {

        }
      
    }
}