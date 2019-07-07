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

        }

        protected void add_prj_Click(object sender, EventArgs e)
        {
            Server.Transfer("DCprjpg.aspx");
        }
    }
}