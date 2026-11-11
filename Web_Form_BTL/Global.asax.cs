using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Form_BTL
{
    public class Global: HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Khởi tạo cơ sở dữ liệu khi ứng dụng bắt đầu
            DAL.DatabaseHelper.DatabaseInttalizer();
        }
    }
}