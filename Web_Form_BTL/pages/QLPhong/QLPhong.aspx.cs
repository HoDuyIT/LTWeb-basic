using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Form_BTL.DAL;
using Web_Form_BTL.moDels;

namespace Web_Form_BTL.pages.QLPhong
{
    public partial class QLPhong : Page
    {
        private readonly LoaiPhongDAL loaiPhongDAL = new LoaiPhongDAL();

        protected void Page_Init(object sender, EventArgs e)
        {
            NguoiDung nguoiDung = Session["NguoiDung"] as NguoiDung;

            if (nguoiDung == null)
            {
                Response.Redirect("~/pages/DangNhap/DangNhap.aspx");
                return;
            }

            if (nguoiDung.VaiTro != "Admin")
            {
                Response.Redirect("~/pages/TrangChu/TrangChu.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HienThiDanhSach();
            }
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
            HienThiDanhSach();
        }

        private void HienThiDanhSach()
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            List<LoaiPhong> danhSach = loaiPhongDAL.GetAllLoaiPhong();

            if (tuKhoa.Length > 0)
            {
                danhSach = danhSach.FindAll(phong =>
                    phong.TenLoai.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            rpLoaiPhong.DataSource = danhSach;
            rpLoaiPhong.DataBind();

            lblTongSearch.Text = danhSach.Count.ToString();
            phKhongCoKetQua.Visible = danhSach.Count == 0;
        }

        protected void btnThemPhong_Click(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
            lblLoiThemPhong.Text = "";

            ddlKhachSan.DataSource = loaiPhongDAL.LayDanhSachKhachSan();
            ddlKhachSan.DataTextField = "Ten";
            ddlKhachSan.DataValueField = "Id";
            ddlKhachSan.DataBind();
            ddlKhachSan.Items.Insert(0, new ListItem("-- Chọn khách sạn --", ""));

            pnlThemPhong.Visible = true;
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            DongFormThemPhong();
        }

        protected void btnLuuPhong_Click(object sender, EventArgs e)
        {
            string tenLoai = txtTenLoai.Text.Trim();

            int khachSanId;
            int soNguoi;
            long gia;
            int soLuong;

            if (!int.TryParse(ddlKhachSan.SelectedValue, out khachSanId))
            {
                lblLoiThemPhong.Text = "Bạn cần chọn khách sạn.";
                return;
            }

            if (tenLoai.Length == 0)
            {
                lblLoiThemPhong.Text = "Bạn cần nhập tên loại phòng.";
                return;
            }

            if (!int.TryParse(txtSoNguoi.Text, out soNguoi) || soNguoi <= 0)
            {
                lblLoiThemPhong.Text = "Số người tối đa phải là số nguyên lớn hơn 0.";
                return;
            }

            if (!long.TryParse(txtGia.Text, out gia) || gia < 0)
            {
                lblLoiThemPhong.Text = "Giá mỗi đêm phải là số nguyên từ 0 trở lên.";
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out soLuong) || soLuong < 0)
            {
                lblLoiThemPhong.Text = "Số lượng phòng phải là số nguyên từ 0 trở lên.";
                return;
            }

            LoaiPhong phong = new LoaiPhong
            {
                KhachSanId = khachSanId,
                TenLoai = tenLoai,
                SoNguoiToiDa = soNguoi,
                GiaMoiDem = gia,
                SoLuongPhong = soLuong,
                TienNghi = txtTienNghi.Text.Trim()
            };

            if (!loaiPhongDAL.ThemLoaiPhong(phong))
            {
                lblLoiThemPhong.Text = "Khách sạn đã chọn không còn trong danh sách.";
                return;
            }

            DongFormThemPhong();
            txtTimKiem.Text = tenLoai;
            HienThiDanhSach();
            lblThongBao.Text = "Đã thêm loại phòng thành công.";
        }

        private void DongFormThemPhong()
        {
            pnlThemPhong.Visible = false;
            ddlKhachSan.ClearSelection();
            txtTenLoai.Text = "";
            txtSoNguoi.Text = "";
            txtGia.Text = "";
            txtSoLuong.Text = "";
            txtTienNghi.Text = "";
            lblLoiThemPhong.Text = "";
        }
    }
}