using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Form_BTL.DAL;
using Web_Form_BTL.moDels.modelView;

namespace Web_Form_BTL.BLL
{
    public class KhachSanBLL
    {
        public List<KhachSanView> GetAllKhachSanViews()
        {
            KhachSanDAL khachSanDAL = new KhachSanDAL();

            return khachSanDAL.GetAllKhachSanViews();
        }
       
    }
}