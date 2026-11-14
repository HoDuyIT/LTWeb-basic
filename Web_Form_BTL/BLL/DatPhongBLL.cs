using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Form_BTL.moDels;
namespace Web_Form_BTL.BLL
{
    public class DatPhongBLL
    {
        public void ThemDatPhong(DatPhong datPhong)
        {
            DAL.DatPhongDAL datPhongDAL = new DAL.DatPhongDAL();
            datPhongDAL.ThemDatPhong(datPhong);
        }
    }
}