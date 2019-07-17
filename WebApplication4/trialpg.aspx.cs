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
    public partial class trialpg : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DMSdb.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            TextBox1.Visible = false;
            Disp();
            int count =Convert.ToInt32(TextBox1.Text);
            GridView1.Visible = false;
            for (int i = 0; i < count; i++)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select prj_name from project";  
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                CheckBoxList1.DataSource = dt;
                CheckBoxList1.DataBind();
                //CheckBoxList1.Text = dt.ToString();
                 con.Close();
            }
        }
                /*
                ///////
                SqlDataReader rdr = cmd.ExecuteReader();
               
                    string pn = rdr["prj_name"].ToString();

                    CheckBoxList cb = new CheckBoxList();
                    cb.Text = pn;
                    cb.ID = "chkbx"+i;
                    // cb.Text = rdr[i].ToString();
                    // cb.Text = Convert.ToString(rdr[i]);
                    //phTextBoxes.Controls.Add(txtBox);
                    //tdTextBoxes.Controls.Add(txtBox);
                    pnlTextBoxes.Controls.Add(cb);

               
                rdr.Close();
                */
             
        public void Disp()
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

        protected void trialadd_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //adding new user details into the database
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            /* if(chkbx[i].checked)
                 {

                 }*/
            /* for (int i = 0; i < 100; i++)
              {
                  if (chkbx[i]==true)
                      cmd.CommandText = "insert into usrprj(user_id,prj_id) values ('" + usrid_tb.Text + "','" + chkbx.IsChecked() + "')";
                  cmd.ExecuteNonQuery();
              }*/
            // Clear_Click(this, new EventArgs());
            // notify.Text = "<span style= 'color:green' >\n \nUser details added successfully</span> ";

            if (con.State == ConnectionState.Open)
                con.Close();
        }
    }
}