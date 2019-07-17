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

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            displaydata();
        }
        //Displays all data in gridview
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
            //total number of row in the gridview.
            TextBox1.Text = Convert.ToString(dt.Rows.Count);
            con.Close();

        }
        //displays the data using the ID
        public void disp_id()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = " select ROW_NUMBER() OVER (ORDER BY prj_id) AS sl_no,* from project where prj_id='" + prjid_tb.Text+"'";
            cmd1.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            TextBox1.Text = Convert.ToString(dt.Rows.Count);
            con.Close();
        }
        //adding the project to the database
        protected void add_btn_Click(object sender, EventArgs e)
        {
            add_btn.OnClientClick = "return validation();";
            disp_id();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (TextBox1.Text == "1")
            {
                notify.Text = "<span style='color:red'>the project id exists..no two record can share the same id</span>";
            }
            else
            {

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into project(prj_id,prj_name,prj_created,prj_completed,prj_status) values ('" + prjid_tb.Text + "','" + prjnm_tb.Text + "','" + prjcd_tb.Text + "','" + prjcom_tb.Text + "','" + prjstat_tb.SelectedValue + "')";
                cmd.ExecuteNonQuery();
                displaydata();
                Clear_Click(this, new EventArgs());
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        //updating the project to the database
        protected void Update_Click(object sender, EventArgs e)
        {
            add_btn.OnClientClick = "return validation();";
            disp_id();
            if (Convert.ToInt32(TextBox1.Text) != 1)
            {
                notify.Text = "<span style= 'color:red'>\n \nThe project with project id'" + prjid_tb + "' is not found</span>";
            }
            else
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //updating user details into the database
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " UPDATE project SET prj_id = '" + prjid_tb.Text + "', prj_name ='" + prjnm_tb.Text + "',prj_created='" + prjcd_tb.Text + "',prj_completed='" + prjcom_tb.Text + "',prj_status='" +prjstat_tb.Text + "' where prj_id='"+prjid_tb.Text+"'";
                cmd.ExecuteNonQuery();
                Clear_Click(this, new EventArgs());
                displaydata();
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            prjid_tb.Focus();
        }
        //deleting the project from database
        protected void Delete_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            disp_id();
            //if the id is not matching with any record, app. message is displayed
            if (TextBox1.Text == "0")
            {
                notify.Text = "\n<span style='color:red'> the record with ID = " + prjid_tb.Text + " is not found..deleting is not possible if the id does not match any record</span>";
            }
            else
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from project where prj_id ='" + prjid_tb.Text + "'";
                cmd.ExecuteNonQuery();
                disp_id();
                if (TextBox1.Text == "0")
                {
                    notify.Text = "<span style= 'color:green'>\n project details deleted </span>";
                }
                displaydata();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            Clear_Click(this, new EventArgs());
            prjid_tb.Focus();
        }
        //clear the textboxes
        protected void Clear_Click(object sender, EventArgs e)
        {
            prjid_tb.Text = "";
            prjnm_tb.Text = "";
            prjcd_tb.Text = "";
            prjcom_tb.Text = "";
            prjstat_tb.SelectedIndex = 0;
            notify.Text = "";
            displaydata();
        }
        //search for a record
        protected void Search_Click(object sender, EventArgs e)
        {
            if ((seaprjIDtb.Text == "") && (seaprjNMtb.Text == ""))
            {
                notify.Text = "<span style='color:red'>No columns filled to search</span> ";
            }
            else
            {
                if ((seaprjIDtb.Text == "")&& (seaprjNMtb.Text != ""))
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
        //fill the display after searches
        public void fill()
        {
            this.GridView1.SelectedIndex = 0;
           lab_prjid.Text = GridView1.SelectedRow.Cells[2].Text;
            Lab_prjnm.Text = GridView1.SelectedRow.Cells[3].Text;
            Lab_cre.Text = GridView1.SelectedRow.Cells[4].Text;
            Lab_com.Text = GridView1.SelectedRow.Cells[5].Text;
            Lab_stat.Text = GridView1.SelectedRow.Cells[6].Text;
        }
        //transfer the display after searches
        protected void Lodbtn_Click(object sender, EventArgs e)
        {
            prjid_tb.Text= lab_prjid.Text;
            prjnm_tb.Text = Lab_prjnm.Text;
            prjcd_tb.Text = Convert.ToString(Lab_cre.Text);
            prjcom_tb.Text = Convert.ToString( Lab_com.Text);
            prjstat_tb.Text = Lab_stat.Text;
            Clearsrch_Click(this, new EventArgs());
        }
        //clear the notify,display and searchboxes
        protected void Clearsrch_Click(object sender, EventArgs e)
        {
            lab_prjid.Text  ="";
            Lab_prjnm.Text  ="";
            Lab_cre.Text    ="";
            Lab_com.Text    ="";
            Lab_stat.Text   ="";
            seaprjIDtb.Text ="";
            seaprjNMtb.Text ="";
            notify.Text     ="";
            displaydata();
        }
        //the textboxes are filled with the details of selected row
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            prjid_tb.Text = GridView1.SelectedRow.Cells[2].Text;
            prjnm_tb.Text = GridView1.SelectedRow.Cells[3].Text;
            prjcd_tb.Text =Convert.ToString( GridView1.SelectedRow.Cells[4].Text);
            prjcom_tb.Text = Convert.ToString(GridView1.SelectedRow.Cells[5].Text);
            prjstat_tb.Text = GridView1.SelectedRow.Cells[6].Text;
            
        }
    }
}