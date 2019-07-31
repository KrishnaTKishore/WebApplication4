using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class DCfirstpg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["logid"] != null)
            {
                logid.Text= Request.Cookies["logid"].Value.ToString();
            }
            if (Request.Cookies["logdesg"] != null)
            {
                logdesg.Text = Request.Cookies["logdesg"].Value.ToString();
            }
        }

        protected void add_prj_Click(object sender, EventArgs e)
        {
            HttpCookie Cookie = new HttpCookie("logid");
            Cookie.Value = logid.Text;
            Cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Cookie);
            HttpCookie Cookie1 = new HttpCookie("logdesg");
            Cookie1.Value = logdesg.Text;
            Cookie1.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Cookie1);
            Server.Transfer("DCprjpg.aspx");
        }

        protected void doc_db_Click(object sender, EventArgs e)
        {
            HttpCookie Cookie = new HttpCookie("logid");
            Cookie.Value = logid.Text;
            Cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Cookie);
            HttpCookie Cookie1 = new HttpCookie("logdesg");
            Cookie1.Value = logdesg.Text;
            Cookie1.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Cookie1);
            Server.Transfer("DCdocfirstpg.aspx");
        }

        protected void vw_prj_Click(object sender, EventArgs e)
        {

        }
    }
}