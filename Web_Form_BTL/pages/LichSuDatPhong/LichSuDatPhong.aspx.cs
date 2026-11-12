using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Form_BTL.DAL;
using Web_Form_BTL.moDels;
using Web_Form_BTL.moDels.modelView;

namespace Web_Form_BTL.pages.LichSuDatPhong
{
    public partial class LichSuDatHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HienThiLichSuDatPhong();
            }
        }

        private void HienThiLichSuDatPhong()
        {
            NguoiDung nguoiDung =
                Session["NguoiDung"] as NguoiDung;

            if (nguoiDung == null)
            {
                HienThiDanhSachRong();
                return;
            }

            DatPhongDAL datPhongDAL = new DatPhongDAL();

            // Model NguoiDung của dự án có thuộc tính Id.
            List<LichSuDatPhongView> danhSach =
                datPhongDAL.GetLichSuDatPhong(nguoiDung.Id);

            if (danhSach == null)
            {
                danhSach = new List<LichSuDatPhongView>();
            }

            rpLichSuDatPhong.DataSource = danhSach;
            rpLichSuDatPhong.DataBind();

            pnlKhongCoDatPhong.Visible = danhSach.Count == 0;
        }

        private void HienThiDanhSachRong()
        {
            rpLichSuDatPhong.DataSource =
                new List<LichSuDatPhongView>();

            rpLichSuDatPhong.DataBind();
            pnlKhongCoDatPhong.Visible = true;
        }

    }
}