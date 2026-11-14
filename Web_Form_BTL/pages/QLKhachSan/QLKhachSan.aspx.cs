using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Form_BTL.DAL;
using Web_Form_BTL.moDels;

namespace Web_Form_BTL.pages.QLKhachSan
{
    public partial class QLKhachSan : Page
    {
        private readonly QuanLyKhachSanDAL khachSanDAL = new QuanLyKhachSanDAL();
        private NguoiDung admin;

        private int IdDangSua
        {
            get { return (int?)ViewState["IdDangSua"] ?? 0; }
            set { ViewState["IdDangSua"] = value; }
        }

        private string TuKhoaTimKiem
        {
            get { return ViewState["TuKhoaTimKiem"] as string ?? ""; }
            set { ViewState["TuKhoaTimKiem"] = value; }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            admin = Session["NguoiDung"] as NguoiDung;

            if (admin == null)
            {
                Response.Redirect("~/pages/DangNhap/DangNhap.aspx");
                return;
            }

            if (admin.VaiTro != "Admin")
            {
                Response.Redirect("~/pages/TrangChu/TrangChu.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblThongBao.Text = Session["QLKhachSan_ThongBao"] as string ?? "";
                Session.Remove("QLKhachSan_ThongBao");

                HienThiDanhSach();
            }
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            TuKhoaTimKiem = txtTimKiem.Text.Trim();
            lblThongBao.Text = "";
            lblLoiDanhSach.Text = "";

            HienThiDanhSach();
        }

        private void HienThiDanhSach()
        {
            List<KhachSan> danhSach = khachSanDAL.LayDanhSach();
            string tuKhoa = TuKhoaTimKiem;

            if (tuKhoa.Length > 0)
            {
                danhSach = danhSach.FindAll(khachSan =>
                    khachSan.Ten.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            rpKhachSan.DataSource = danhSach;
            rpKhachSan.DataBind();

            litSoKetQua.Text = danhSach.Count.ToString();
            phDanhSachTrong.Visible = danhSach.Count == 0;
        }

        protected void rpKhachSan_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id;

            if (!int.TryParse(Convert.ToString(e.CommandArgument), out id) || id <= 0)
            {
                return;
            }

            lblThongBao.Text = "";
            lblLoiDanhSach.Text = "";

            if (e.CommandName == "SuaKhachSan")
            {
                NapThongTinDeSua(id);
            }
            else if (e.CommandName == "XoaKhachSan")
            {
                if (khachSanDAL.XoaKhachSan(id))
                {
                    VeDanhSach("Đã xóa khách sạn.");
                    return;
                }

                lblLoiDanhSach.Text = "Khách sạn còn loại phòng liên kết hoặc đã bị xóa.";
            }
        }

        private void NapThongTinDeSua(int id)
        {
            KhachSan khachSan = khachSanDAL.LayTheoId(id);

            if (khachSan == null)
            {
                lblLoiDanhSach.Text = "Khách sạn này đã bị xóa.";
                HienThiDanhSach();
                return;
            }

            IdDangSua = id;
            ViewState["HinhAnhCu"] = khachSan.HinhAnh;

            txtTen.Text = khachSan.Ten;
            txtDiaChi.Text = khachSan.DiaChi;
            txtThanhPho.Text = khachSan.ThanhPho;
            txtHinhAnh.Text = khachSan.HinhAnh;
            txtMoTa.Text = khachSan.MoTa;

            ddlSoSao.SelectedValue = khachSan.SoSao > 0
                ? khachSan.SoSao.ToString()
                : "";

            ddlTrangThai.SelectedValue = khachSan.TrangThai == "NgungHoatDong"
                ? "NgungHoatDong"
                : "HoatDong";

            lblLoi.Text = "";
            litTieuDeForm.Text = "Sửa thông tin khách sạn";
            btnThemKhachSan.Text = "Lưu thay đổi";
            btnHuySua.Visible = true;
            txtTen.Focus();
        }

        protected void btnThemKhachSan_Click(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
            lblLoiDanhSach.Text = "";
            lblLoi.Text = "";

            string ten = txtTen.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string thanhPho = txtThanhPho.Text.Trim();
            string hinhAnh = txtHinhAnh.Text.Trim();

            if (ten.Length == 0 || diaChi.Length == 0 || thanhPho.Length == 0)
            {
                lblLoi.Text = "Hãy nhập tên, địa chỉ và thành phố của khách sạn.";
                return;
            }

            int soSao;

            if (!int.TryParse(ddlSoSao.SelectedValue, out soSao) || soSao < 1 || soSao > 5)
            {
                lblLoi.Text = "Hãy chọn số sao từ 1 đến 5.";
                return;
            }

            string hinhAnhCu = ViewState["HinhAnhCu"] as string ?? "";

            if (hinhAnh.Length > 0 && hinhAnh != hinhAnhCu && !KiemTraAnh(hinhAnh))
            {
                lblLoi.Text = "Hãy nhập đúng tên một file ảnh trong thư mục pages/image.";
                return;
            }

            KhachSan khachSan = new KhachSan
            {
                Id = IdDangSua,
                Ten = ten,
                DiaChi = diaChi,
                ThanhPho = thanhPho,
                SoSao = soSao,
                HinhAnh = hinhAnh,
                MoTa = txtMoTa.Text.Trim(),
                TrangThai = ddlTrangThai.SelectedValue
            };

            if (IdDangSua > 0)
            {
                if (!khachSanDAL.SuaKhachSan(khachSan))
                {
                    lblLoi.Text = "Khách sạn này đã bị xóa.";
                    HienThiDanhSach();
                    return;
                }

                VeDanhSach("Đã cập nhật khách sạn.");
                return;
            }

            if (!khachSanDAL.ThemKhachSan(khachSan, admin.Id))
            {
                lblLoi.Text = "Không lưu được khách sạn. Hãy đăng nhập lại bằng tài khoản Admin.";
                return;
            }

            VeDanhSach("Đã thêm khách sạn.");
        }

        protected void btnHuySua_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/QLKhachSan/QLKhachSan.aspx");
        }

        private void VeDanhSach(string thongBao)
        {
            Session["QLKhachSan_ThongBao"] = thongBao;
            Response.Redirect("~/pages/QLKhachSan/QLKhachSan.aspx");
        }

        private bool KiemTraAnh(string tenFile)
        {
            string mauTenAnh = @"^[\p{L}\p{M}\p{N} _.-]+\.(jpg|jpeg|png|webp|gif)$";

            return Regex.IsMatch(tenFile, mauTenAnh, RegexOptions.IgnoreCase)
                && File.Exists(Server.MapPath("~/pages/image/" + tenFile));
        }
    }
}