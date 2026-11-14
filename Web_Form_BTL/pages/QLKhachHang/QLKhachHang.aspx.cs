using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Form_BTL.appData;
using Web_Form_BTL.moDels;

namespace Web_Form_BTL.pages.QLKhachHang
{
    public partial class QLKhachHang : System.Web.UI.Page
    {
        private NguoiDungDAL nguoiDungDAL = new NguoiDungDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                hienThiDanhSach();
            }
        }
        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            TuKhoaTimKiem = txtTimKiem.Text.Trim();
            hienThiDanhSach();
        }
        private String TuKhoaTimKiem
        {
            get { return ViewState["TuKhoaTimKiem"] as string ?? ""; }
            set { ViewState["TuKhoaTimKiem"] = value; }
        }

        void hienThiDanhSach()
        {
            List<NguoiDung> danhsach = nguoiDungDAL.GetAllNguoiDung();
            string tuKhoa = BoDauTiengViet(TuKhoaTimKiem.Trim());

            if (tuKhoa.Length > 0)
            {
                danhsach = danhsach.Where(khachHang =>
                {
                    string hoTen = BoDauTiengViet(khachHang.HoTen);
                    return hoTen.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0;
                }).ToList();
            }
            rpKhachHang.DataSource = danhsach;
            rpKhachHang.DataBind();
            lblTongSearch.Text = danhsach.Count.ToString();
            phKhongCoKetQua.Visible = danhsach.Count == 0;

        }
        private string BoDauTiengViet(string chuoi)
        {
            string chuoiChuanHoa = (chuoi ?? "").Normalize(NormalizationForm.FormD);
            StringBuilder ketQua = new StringBuilder();

            foreach (char kyTu in chuoiChuanHoa)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(kyTu) != UnicodeCategory.NonSpacingMark)
                {
                    ketQua.Append(kyTu);
                }
            }

            return ketQua.ToString()
                .Replace('đ', 'd')
                .Replace('Đ', 'D');
        }
    }
}