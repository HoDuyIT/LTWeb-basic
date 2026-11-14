using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Form_BTL.BLL;
using Web_Form_BTL.moDels;
using Web_Form_BTL.moDels.modelView;

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

            if(dateNhan != null)
            {
                txtNgayNhan.Text = dateNhan;
            }
            if(dateTra != null)
            {
                txtNgayTra.Text = dateTra;
            }

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
            List < KhachSanView > danhSach = new List<KhachSanView>();
            danhSach = ds();        
            DateTime ngayNhan = Convert.ToDateTime(txtNgayNhan.Text);

            DateTime ngayTra = Convert.ToDateTime(txtNgayTra.Text);

            TimeSpan soNgay = ngayTra - ngayNhan;

            float Tong = soNgay.Days * (float)danhSach[0].GiaTu;

            NguoiDung nguoiDung = Session["NguoiDung"] as NguoiDung;

            if (nguoiDung == null)
            {
                Response.Redirect("~/pages/DangNhap/DangNhap.aspx");
                return;
            }


            int nguoiDungId = nguoiDung.Id;



            // Tiếp tục xử lý đặt phòng
            DatPhong datPhong = new DatPhong
            {
                NguoiDungId = nguoiDungId,
                LoaiPhongId = Convert.ToInt32(danhSach[0].idLoaiPhong),
                NgayNhan = Convert.ToDateTime(txtNgayNhan.Text),
                NgayTra = Convert.ToDateTime(txtNgayTra.Text),
                SoKhach = Convert.ToInt32(txtSoKhach.Text),
                SoPhongDat = 1,
                TongTien = Tong,
                TrangThai = "ChoXacNhan"
                
            };
            DatPhongBLL datPhongBLL = new DatPhongBLL();
            datPhongBLL.ThemDatPhong(datPhong); 
        }
      
    }
}