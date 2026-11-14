using System;
using System.Net.Mail;
using System.Web.UI;
using Web_Form_BTL.BLL;
using Web_Form_BTL.moDels;

namespace Web_Form_BTL.pages.DangNhap.TaiKhoan
{
    public partial class TaiKhoan : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NguoiDung nguoiDung =
                Session["NguoiDung"] as NguoiDung;

            // Chưa đăng nhập thì chuyển đến trang đăng nhập.
            if (nguoiDung == null)
            {
                Response.Redirect(
                    "~/pages/DangNhap/DangNhap.aspx",
                    false
                );

                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            // Chỉ tải thông tin khi mở trang lần đầu.
            if (!IsPostBack)
            {
                HienThiThongTin(nguoiDung);
                ChuyenCheDoXem();
            }
        }

        private void HienThiThongTin(NguoiDung nguoiDung)
        {
            lblHoTenHeader.Text =
                Server.HtmlEncode(nguoiDung.HoTen);

            lblEmailHeader.Text =
                Server.HtmlEncode(nguoiDung.Email);

            lblHoTen.Text =
                Server.HtmlEncode(nguoiDung.HoTen);

            lblSoDienThoai.Text =
                Server.HtmlEncode(nguoiDung.SoDienThoai);

            lblEmail.Text =
                Server.HtmlEncode(nguoiDung.Email);

            lblVaiTro.Text =
                Server.HtmlEncode(nguoiDung.VaiTro);

            lblTenDangNhap.Text =
                Server.HtmlEncode(nguoiDung.TenDangNhap);
        }

        private void ChuyenCheDoXem()
        {
            pnlThongTin.Visible = true;
            pnlChinhSua.Visible = false;
        }

        private void ChuyenCheDoChinhSua(NguoiDung nguoiDung)
        {
            txtHoTen.Text = nguoiDung.HoTen;
            txtSoDienThoai.Text = nguoiDung.SoDienThoai;
            txtEmail.Text = nguoiDung.Email;

            pnlThongTin.Visible = false;
            pnlChinhSua.Visible = true;
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            NguoiDung nguoiDung =
                Session["NguoiDung"] as NguoiDung;

            if (nguoiDung == null)
            {
                return;
            }

            lblThongBao.Text = "";
            ChuyenCheDoChinhSua(nguoiDung);
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            NguoiDung nguoiDung =
                Session["NguoiDung"] as NguoiDung;

            if (nguoiDung == null)
            {
                return;
            }

            // Bỏ các nội dung vừa nhập, quay lại dữ liệu đã lưu.
            HienThiThongTin(nguoiDung);
            lblThongBao.Text = "";
            ChuyenCheDoXem();
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            NguoiDung nguoiDung =
                Session["NguoiDung"] as NguoiDung;

            if (nguoiDung == null)
            {
                return;
            }

            string hoTen = txtHoTen.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                lblThongBao.Text = "Họ tên không được để trống.";
                pnlThongTin.Visible = false;
                pnlChinhSua.Visible = true;
                return;
            }

            // Kiểm tra định dạng email nếu người dùng có nhập.
            if (!string.IsNullOrWhiteSpace(email))
            {
                try
                {
                    MailAddress diaChiEmail = new MailAddress(email);
                }
                catch
                {
                    lblThongBao.Text = "Email không đúng định dạng.";
                    pnlThongTin.Visible = false;
                    pnlChinhSua.Visible = true;
                    return;
                }
            }

            NguoiDungBLL nguoiDungBLL = new NguoiDungBLL();

            bool capNhatThanhCong =
                nguoiDungBLL.CapNhatThongTinCaNhan(
                    nguoiDung.Id,
                    hoTen,
                    email,
                    soDienThoai
                );

            if (!capNhatThanhCong)
            {
                lblThongBao.Text = "Không cập nhật được thông tin.";
                pnlThongTin.Visible = false;
                pnlChinhSua.Visible = true;
                return;
            }

            // Cập nhật đối tượng trong Session để các trang khác
            // cũng nhận được thông tin mới.
            nguoiDung.HoTen = hoTen;
            nguoiDung.Email = email;
            nguoiDung.SoDienThoai = soDienThoai;
            Session["NguoiDung"] = nguoiDung;

            HienThiThongTin(nguoiDung);
            ChuyenCheDoXem();

            lblThongBao.Text = "Đã cập nhật thông tin tài khoản.";
        }
    }
}