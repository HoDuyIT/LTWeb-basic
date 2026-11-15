using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Form_BTL.DAL;
using Web_Form_BTL.moDels;
using Web_Form_BTL.moDels.modelView;

namespace Web_Form_BTL.pages.QLDatPhong
{
    public partial class QLDatPhong : Page
    {
        private readonly DatPhongDAL datPhongDAL = new DatPhongDAL();

        private string TrangThaiDangLoc
        {
            get { return ViewState["TrangThaiDangLoc"] as string ?? ""; }
            set { ViewState["TrangThaiDangLoc"] = value; }
        }

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
                return;
            }

            ViewStateUserKey = Session.SessionID;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HienThiDanhSach();
            }
        }

        protected void LocTrangThai_Command(object sender, CommandEventArgs e)
        {
            TrangThaiDangLoc = Convert.ToString(e.CommandArgument);
            lblThongBao.Text = "";

            HienThiDanhSach();
        }

        private void HienThiDanhSach()
        {
            List<LichSuDatPhongView> danhSach = datPhongDAL.GetAllLichSuDatPhong();
            string trangThai = TrangThaiDangLoc;

            if (trangThai.Length > 0)
            {
                danhSach = danhSach.FindAll(don => don.TrangThaiDat == trangThai);
            }

            rpDatPhong.DataSource = danhSach;
            rpDatPhong.DataBind();

            phDanhSachTrong.Visible = danhSach.Count == 0;

            btnDaXacNhan.CssClass = trangThai == "DaXacNhan"
                ? "qldp-nut qldp-dang-loc" : "qldp-nut";

            btnChuaXacNhan.CssClass = trangThai == "ChoXacNhan"
                ? "qldp-nut qldp-dang-loc" : "qldp-nut";

            btnDaHuy.CssClass = trangThai == "DaHuy"
                ? "qldp-nut qldp-dang-loc" : "qldp-nut";
        }

        protected void rpDatPhong_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int maDatPhong;

            if (e.CommandName != "XacNhan"
                || !int.TryParse(Convert.ToString(e.CommandArgument), out maDatPhong)
                || maDatPhong <= 0)
            {
                return;
            }

            bool thanhCong = datPhongDAL.XacNhanDatPhong(maDatPhong);

            lblThongBao.Text = thanhCong
                ? "Đã xác nhận đơn đặt phòng #" + maDatPhong + "."
                : "Đơn đặt phòng đã được xác nhận hoặc không còn tồn tại.";

            HienThiDanhSach();
        }

        protected string TenTrangThai(string trangThai)
        {
            switch (trangThai)
            {
                case "ChoXacNhan":
                    return "Chưa xác nhận";

                case "DaXacNhan":
                    return "Đã xác nhận";

                case "DaHuy":
                    return "Đã hủy";

                case "HoanThanh":
                    return "Hoàn thành";

                default:
                    return trangThai;
            }
        }
    }
}