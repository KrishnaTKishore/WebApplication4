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
    public partial class DCprjpg1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DMSdb.mdf;Integrated Security=True");
        //the gridview has all the records displayed when the page starts
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
            displaydata();
        }
        //when you search a record...the first records details are displayed into the label
        public void fill()
        {
            this.GridView1.SelectedIndex = 0;
            lab_prjid.Text = GridView1.SelectedRow.Cells[1].Text;
            Lab_prjnm.Text = GridView1.SelectedRow.Cells[2].Text;
            Lab_cre.Text = GridView1.SelectedRow.Cells[3].Text;
            Lab_com.Text = GridView1.SelectedRow.Cells[4].Text;
            Lab_stat.Text = GridView1.SelectedRow.Cells[5].Text;
        }
        //the records of projects are displayed
        public void displaydata()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = " select ROW_NUMBER() OVER (ORDER BY prj_id) AS sl_no,* from project";
            cmd1.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            TextBox1.Text = Convert.ToString(dt.Rows.Count);
            con.Close();

        }
        //searches the record
        protected void Search_Click(object sender, EventArgs e)
        {
            if ((seaprjIDtb.Text == "") && (seaprjNMtb.Text == ""))
            {
                notify.Text = "<span style='color:red'>No columns filled to search</span> ";
            }
            else
            {
                if ((seaprjIDtb.Text == "") && (seaprjNMtb.Text != ""))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                    }
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = " select ROW_NUMBER() OVER (ORDER BY prj_id) AS sl_no,* from project where prj_name='" + seaprjNMtb.Text + "'";
                    cmd1.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    TextBox1.Text = Convert.ToString(dt.Rows.Count);
                    if (TextBox1.Text == "0")
                    {
                        notify.Text = "<span style='color:red'> No project found</span>";
                    }

                    if (TextBox1.Text == "1")
                    {
                        fill();
                    }
                    con.Close();
                }
                else if ((seaprjNMtb.Text == "") && (seaprjIDtb.Text != ""))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                    }
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = " select ROW_NUMBER() OVER (ORDER BY prj_id) AS sl_no,* from project where prj_id='" + seaprjIDtb.Text + "'";
                    cmd1.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    TextBox1.Text = Convert.ToString(dt.Rows.Count);
                    if (TextBox1.Text == "0")
                    {
                        notify.Text = "<span style='color:red'> No project found</span>";
                    }
                    if (TextBox1.Text == "1")
                    {
                        fill();
                    }
                    con.Close();
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                    }
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = " select ROW_NUMBER() OVER (ORDER BY prj_id) AS sl_no,* from project where prj_id='" + seaprjIDtb.Text + "' and prj_name ='" + seaprjNMtb.Text + "'";
                    cmd1.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    TextBox1.Text = Convert.ToString(dt.Rows.Count);
                    if (TextBox1.Text == "0")
                    {
                        notify.Text = "<span style='color:red'> No project found</span>";
                        displaydata();
                    }
                    if (Convert.ToInt32(TextBox1.Text) == 1)
                    {
                        fill();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }
        //cleans the search column and search results and notify
        protected void Clearsrch_Click(object sender, EventArgs e)
        {
            lab_prjid.Text = "";
            Lab_prjnm.Text = "";
            Lab_cre.Text = "";
            Lab_com.Text = "";
            Lab_stat.Text = "";
            seaprjIDtb.Text = "";
            seaprjNMtb.Text = "";
            notify.Text = "";
        }

    }
}