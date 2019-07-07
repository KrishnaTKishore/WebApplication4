using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class ADfirstpg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void empdbbn_Click(object sender, EventArgs e)
        {
            Server.Transfer("ADusrpg.aspx");
        }

        protected void logdbbn_Click(object sender, EventArgs e)
        {

        }

        protected void prjdbbn_Click(object sender, EventArgs e)
        {

        }
    }
}