using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication4
{
    public partial class DCprjpg : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DMSdb.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();

            }
            con.Open();
            displaydata();
        }
        public void displaydata()
        {
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = " select * from project";
            cmd1.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }


        protected void add_btn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into project(prj_name,prj_created,prj_completed,prj_status) values ('" + prjnm_tb.Text + "','" + prjcd_tb.Text + "','" + prjcom_tb.Text  + "','" + prjstat_tb.Text + "')";
            cmd.ExecuteNonQuery();

            prjnm_tb.Text = "";
            prjcd_tb.Text = "";
            prjcom_tb.Text = "";
            prjid_tb.Text = "";
            prjstat_tb.SelectedIndex = 0;
            
            displaydata();

        }

        protected void Update_Click(object sender, EventArgs e)
        {

        }

        protected void Delete_Click(object sender, EventArgs e)
        {

        }

        protected void Clear_Click(object sender, EventArgs e)
        {

        }

        protected void Search_Click(object sender, EventArgs e)
        {

        }

        protected void Lodbtn_Click(object sender, EventArgs e)
        {

        }

        protected void Clearsrch_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}