using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace WebApplication4
{
    public partial class ADcmppg : System.Web.UI.Page
    {
        //establishing connection
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DMSdb.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            Disp();
        }
        void Disp()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY wrk_insp_ref_no) AS sl_no,* from wir ";

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            // GridView1.Columns[11].Visible = false;
            con.Close();
        }

        protected void add_btn_Click(object sender, EventArgs e)
        {
//Get the file uploaded to the Uploads file
            if (FileUpload1.HasFile)
            {
                // Get the file extension
                string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);

                if (fileExtension.ToLower() != ".doc" && fileExtension.ToLower() != ".docx" && fileExtension.ToLower() != ".pdf")
                {
                    notify.ForeColor = System.Drawing.Color.Red;
                    notify.Text = "Only files with .doc and .docx extension are allowed";
                }
                else
                {
                    // Get the file size
                    int fileSize = FileUpload1.PostedFile.ContentLength;
                    // If file size is greater than 2 MB
                    if (fileSize > 2097152)
                    {
                        notify.ForeColor = System.Drawing.Color.Red;
                        notify.Text = "File size cannot be greater than 2 MB";
                    }
                    else
                    {
                        // Upload the file
                        FileUpload1.SaveAs(Server.MapPath("~/Uploads/" + FileUpload1.FileName));
                        notify.ForeColor = System.Drawing.Color.Green;
                        notify.Text = "File uploaded successfully";
                    }
                }
            }
            else
            {
                notify.ForeColor = System.Drawing.Color.Red;
                notify.Text = "Please select a file";
            }
            int count = 0;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

         
           if(rev6_sub_dt_tb.Text != "")
            {
                count++;
                cur_stat_sub_dt_tb.Text = rev6_sub_dt_tb.Text;
                cur_stat_rsp_dt_tb.Text = rev6_ret_dt_tb.Text;
                cur_stat_tb.Text = rev6_stat_tb.Text;
                cur_stat_rev_tb.Text = "06";
            }
            else if (rev5_sub_dt_tb.Text != "")
            {
                count++;
                cur_stat_sub_dt_tb.Text = rev5_sub_dt_tb.Text;
                cur_stat_rsp_dt_tb.Text = rev5_ret_dt_tb.Text;
                cur_stat_tb.Text = rev5_stat_tb.Text;
                cur_stat_rev_tb.Text = "05";
            }
            else if (rev4_sub_dt_tb.Text != "")
            {
                count++;
                cur_stat_sub_dt_tb.Text = rev4_sub_dt_tb.Text;
                cur_stat_rsp_dt_tb.Text = rev4_ret_dt_tb.Text;
                cur_stat_tb.Text = rev4_stat_tb.Text;
                cur_stat_rev_tb.Text = "04";
            }
            else if (rev3_sub_dt_tb.Text != "")
            {
                count++;
                cur_stat_sub_dt_tb.Text = rev3_sub_dt_tb.Text;
                cur_stat_rsp_dt_tb.Text = rev3_ret_dt_tb.Text;
                cur_stat_tb.Text = rev3_stat_tb.Text;
                cur_stat_rev_tb.Text = "03";
            }
            else if (rev2_sub_dt_tb.Text != "")
            {
                count++;
                cur_stat_sub_dt_tb.Text = rev2_sub_dt_tb.Text;
                cur_stat_rsp_dt_tb.Text = rev2_ret_dt_tb.Text;
                cur_stat_tb.Text = rev2_stat_tb.Text;
                cur_stat_rev_tb.Text = "02";
            }
            else if (rev1_sub_dt_tb.Text != "")
            {
                count++;
                cur_stat_sub_dt_tb.Text = rev1_sub_dt_tb.Text;
                cur_stat_rsp_dt_tb.Text = rev1_ret_dt_tb.Text;
                cur_stat_tb.Text = rev1_stat_tb.Text;
                cur_stat_rev_tb.Text = "06";
            }
            else if (rev0_sub_dt_tb.Text != "")
            {
                count++;
                cur_stat_sub_dt_tb.Text = rev0_sub_dt_tb.Text;
                cur_stat_rsp_dt_tb.Text = rev0_ret_dt_tb.Text;
                cur_stat_tb.Text = rev0_stat_tb.Text;
                cur_stat_rev_tb.Text = "06";
            }
            else if(rev0_sub_dt_tb.Text=="")
            {
                notify.Text = "Please enter the initial submission date, returned date and status";
                
            }
            if (count != 0)
            {
                //adding new user details into the database
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into wir(wrk_insp_ref_no,wrk_insp_req,boq_ref, location,site_engr,rsn_c_d,sub_cntrctr, dspln,cur_stat_sub_dt,cur_stat_rsp_dt,cur_stat,cur_stat_rev,no_of_dys,remrk,rsn_fr_over_due,doc,rev0_sub_dt,rev0_ret_dt,rev0_stat,rev1_sub_dt,rev1_ret_dt,rev1_stat,rev2_sub_dt,rev2_ret_dt,rev2_stat,rev3_sub_dt,rev3_ret_dt,rev3_stat,rev4_sub_dt,rev4_ret_dt,rev4_stat,rev5_sub_dt,rev5_ret_dt,rev5_stat,rev6_sub_dt,rev6_ret_dt,rev6_stat) values('" + wirno_tb.Text + "','" + wir_tb.Text + "','" + boqref_tb.Text + "','" + loc_tb.Text + "','" + site_engr.Text + "','" + cd_tb.Text + "','" + subcon_tb.Text + "','" + decipline.Text + "','" + cur_stat_sub_dt_tb.Text + "','" + cur_stat_rsp_dt_tb.Text + "','" + cur_stat_tb.Text + "','" + cur_stat_rev_tb.Text + "','" + no_of_dys_tb.Text + "','" + remrk_tb.Text + "','" + rsn_fr_over_due.Text + "','"+FileUpload1.FileName+"','"+rev0_sub_dt_tb.Text+"','"+rev0_ret_dt_tb.Text+"','"+rev0_stat_tb.Text+"','" + rev1_sub_dt_tb.Text + "','" + rev1_ret_dt_tb.Text + "','" + rev1_stat_tb.Text + "','" + rev2_sub_dt_tb.Text + "','" + rev2_ret_dt_tb.Text + "','" + rev2_stat_tb.Text + "','" + rev3_sub_dt_tb.Text + "','" + rev3_ret_dt_tb.Text + "','" + rev3_stat_tb.Text + "','" + rev4_sub_dt_tb.Text + "','" + rev4_ret_dt_tb.Text + "','" + rev4_stat_tb.Text + "','" + rev5_sub_dt_tb.Text + "','" + rev5_ret_dt_tb.Text + "','" + rev5_stat_tb.Text + "','" + rev6_sub_dt_tb.Text + "','" + rev6_ret_dt_tb.Text + "','" + rev6_stat_tb.Text +  "')";
                cmd.ExecuteNonQuery();
                Clear_Click(this, new EventArgs());
                con.Close();
            }
         /*   if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }*/

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

        protected void Clearsrch_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void upld_btn_Click(object sender, EventArgs e)
        {
          
        }
    }
}