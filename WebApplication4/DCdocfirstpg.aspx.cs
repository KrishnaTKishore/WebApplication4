using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class DCdocfirstpg : System.Web.UI.Page
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

        protected void wir_Click(object sender, EventArgs e)
        {
            HttpCookie Cookie = new HttpCookie("logid");
            Cookie.Value = logid.Text;
            Cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Cookie);
            HttpCookie Cookie1 = new HttpCookie("logdesg");
            Cookie1.Value = logdesg.Text;
            Cookie1.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Cookie1);
            Server.Transfer("DCwirpg.aspx");
        }

        protected void mir_Click(object sender, EventArgs e)
        {
            HttpCookie Cookie = new HttpCookie("logid");
            Cookie.Value = logid.Text;
            Cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Cookie);
            HttpCookie Cookie1 = new HttpCookie("logdesg");
            Cookie1.Value = logdesg.Text;
            Cookie1.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Cookie1);
            Server.Transfer("DCmirpg.aspx");
        }

        protected void ms_Click(object sender, EventArgs e)
        {
            HttpCookie Cookie = new HttpCookie("logid");
            Cookie.Value = logid.Text;
            Cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Cookie);
            HttpCookie Cookie1 = new HttpCookie("logdesg");
            Cookie1.Value = logdesg.Text;
            Cookie1.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Cookie1);
            Server.Transfer("DCmspg.aspx");
        }

        protected void ncr_Click(object sender, EventArgs e)
        {
            HttpCookie Cookie = new HttpCookie("logid");
            Cookie.Value = logid.Text;
            Cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Cookie);
            HttpCookie Cookie1 = new HttpCookie("logdesg");
            Cookie1.Value = logdesg.Text;
            Cookie1.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Cookie1);
            Server.Transfer("DCncrpg.aspx");
        }

        protected void sor_Click(object sender, EventArgs e)
        {
            HttpCookie Cookie = new HttpCookie("logid");
            Cookie.Value = logid.Text;
            Cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Cookie);
            HttpCookie Cookie1 = new HttpCookie("logdesg");
            Cookie1.Value = logdesg.Text;
            Cookie1.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Cookie1);
            Server.Transfer("DCsorpg.aspx");
        }

        protected void mss_Click(object sender, EventArgs e)
        {
            HttpCookie Cookie = new HttpCookie("logid");
            Cookie.Value = logid.Text;
            Cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Cookie);
            HttpCookie Cookie1 = new HttpCookie("logdesg");
            Cookie1.Value = logdesg.Text;
            Cookie1.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Cookie1);
            Server.Transfer("DCmsspg.aspx");
        }

        protected void scpq_Click(object sender, EventArgs e)
        {
            HttpCookie Cookie = new HttpCookie("logid");
            Cookie.Value = logid.Text;
            Cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Cookie);
            HttpCookie Cookie1 = new HttpCookie("logdesg");
            Cookie1.Value = logdesg.Text;
            Cookie1.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Cookie1);
            Server.Transfer("DCscpqpg.aspx");
        }

        protected void abd_Click(object sender, EventArgs e)
        {
            HttpCookie Cookie = new HttpCookie("logid");
            Cookie.Value = logid.Text;
            Cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Cookie);
            HttpCookie Cookie1 = new HttpCookie("logdesg");
            Cookie1.Value = logdesg.Text;
            Cookie1.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Cookie1);
            Server.Transfer("DCabdpg.aspx");
        }

        protected void sds_Click(object sender, EventArgs e)
        {
            HttpCookie Cookie = new HttpCookie("logid");
            Cookie.Value = logid.Text;
            Cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Cookie);
            HttpCookie Cookie1 = new HttpCookie("logdesg");
            Cookie1.Value = logdesg.Text;
            Cookie1.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Cookie1);
            Server.Transfer("DCsdspg.aspx");
        }

        protected void rfi_Click(object sender, EventArgs e)
        {
            HttpCookie Cookie = new HttpCookie("logid");
            Cookie.Value = logid.Text;
            Cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Cookie);
            HttpCookie Cookie1 = new HttpCookie("logdesg");
            Cookie1.Value = logdesg.Text;
            Cookie1.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Cookie1);
            Server.Transfer("DCrfipg.aspx");
        }
    }
}