using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class DCsdspg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["logid"] != null)
            {
                logid.Text = Request.Cookies["logid"].Value.ToString();
            }
            if (Request.Cookies["logdesg"] != null)
            {
                logdesg.Text = Request.Cookies["logdesg"].Value.ToString();
            }
        }
    }
}