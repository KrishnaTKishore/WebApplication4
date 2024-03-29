﻿using System;
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
    public partial class DCmirpg : System.Web.UI.Page
    {   //establishing connection
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DMSdb.mdf;Integrated Security=True");

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
            Disp();
            if (!IsPostBack)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //all unique project names are retrieved from database
                String strQuery1 = "select prj_name,prj_id from project";
                SqlCommand cmd1 = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = strQuery1,
                    Connection = con
                };
                try
                {
                    //all the unique projects are shown in the drop down box in add/update part

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    usrddlprj.DataSource = cmd1.ExecuteReader();
                    usrddlprj.DataTextField = "prj_name";
                    usrddlprj.DataValueField = "prj_id";
                    usrddlprj.DataBind();
                    con.Close();
                    //all the unique projects are shown in the drop down box in search part
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //all unique project names are retrieved from database
                String strQuery2 = "select prj_name from project";

                SqlCommand cmd = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = strQuery2,
                    Connection = con
                };
                try
                {
                    //all the unique projects are shown in the drop down box in add/update part
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    /*
                    if (usrddlprj.Items.Count > 0)
                    {
                        usrddlprj.Items.Clear();
                    }*/
                    usrddlprj.DataSource = cmd1.ExecuteReader();
                    usrddlprj.DataTextField = "prj_name";
                    usrddlprj.DataValueField = "prj_id";
                    usrddlprj.DataBind();
                    con.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }
            void Disp()
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY mat_insp_ref_no) AS sl_no,* from mir ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                // GridView1.Columns[11].Visible = false;

                // TextBox1.Text = Convert.ToString(dt.Rows.Count);
                con.Close();
            }
            void Disp_no()
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY mat_insp_ref_no) AS sl_no,* from mir where mat_insp_ref_no = '" + matno_tb.Text + "'";

                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                TextBox1.Text = Convert.ToString(dt.Rows.Count);

                // GridView1.Columns[11].Visible = false;
                con.Close();
            }

            protected void add_btn_Click(object sender, EventArgs e)
            {
            //Get the file uploaded to the Uploads file
            if (!FileUpload1.HasFile)
            {
                notify.ForeColor = System.Drawing.Color.Red;
                notify.Text = "<span style= 'color:red'>Please select a file";
            }
            else
            {
                // Get the file extension
                string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);

                if (fileExtension.ToLower() != ".doc" && fileExtension.ToLower() != ".docx" && fileExtension.ToLower() != ".pdf")
                {
                    notify.ForeColor = System.Drawing.Color.Red;
                    notify.Text = "<span style= 'color:red'>Only files with .doc , .pdf and .docx extension are allowed";
                }
                else
                {
                    // Get the file size
                    int fileSize = FileUpload1.PostedFile.ContentLength;
                    // If file size is greater than 2 MB
                    if (fileSize > 2097152)
                    {
                        notify.ForeColor = System.Drawing.Color.Red;
                        notify.Text = "<span style= 'color:red'>File size cannot be greater than 2 MB";
                    }
                    else
                    {
                        // Upload the file
                        FileUpload1.SaveAs(Server.MapPath("~/Uploads/" + FileUpload1.FileName));
                        notify.ForeColor = System.Drawing.Color.Green;
                        notify.Text = "<span style= 'color:green'>File uploaded successfully";
                    }
                }
            }
            int count = 0;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                if (rev6_sub_dt_tb.Text != "")
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
                    cur_stat_rev_tb.Text = "01";
                }
                else if (rev0_sub_dt_tb.Text != "")
                {
                    count++;
                    cur_stat_sub_dt_tb.Text = rev0_sub_dt_tb.Text;
                    cur_stat_rsp_dt_tb.Text = rev0_ret_dt_tb.Text;
                    cur_stat_tb.Text = rev0_stat_tb.Text;
                    cur_stat_rev_tb.Text = "00";
                }
                else if (rev0_sub_dt_tb.Text == "")
                {
                    notify.Text = "<span style= 'color:red'>Please enter the initial submission date, returned date and status";

                }
                if (count != 0)
                {
                    //adding new user details into the database
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into mir(mat_insp_ref_no,mat_desc,mat_sub_ref,mat_qnty,manuf,suplr,dspln,actioner,cur_stat_sub_dt,cur_stat_rsp_dt,cur_stat,cur_stat_rev,no_of_dys,remrk,rsn_fr_over_due,doc,rev0_sub_dt,rev0_ret_dt,rev0_stat,rev1_sub_dt,rev1_ret_dt,rev1_stat,rev2_sub_dt,rev2_ret_dt,rev2_stat,rev3_sub_dt,rev3_ret_dt,rev3_stat,rev4_sub_dt,rev4_ret_dt,rev4_stat,rev5_sub_dt,rev5_ret_dt,rev5_stat,rev6_sub_dt,rev6_ret_dt,rev6_stat) values('" + matno_tb.Text + "','" + matdesc_tb.Text + "','" + mat_sub_ref_tb.Text + "','" + mat_qnty_tb.Text + "','" + manuf_tb.Text + "','" + suplr_tb.Text + "','" + dspln_tb.Text + "','" + actioner_tb.Text + "','" + cur_stat_sub_dt_tb.Text + "','" + cur_stat_rsp_dt_tb.Text + "','" + cur_stat_tb.Text + "','" + cur_stat_rev_tb.Text + "','" + no_of_dys_tb.Text + "','" + remrk_tb.Text + "','" + rsn_fr_over_due_tb.Text + "','" + FileUpload1.FileName + "','" + rev0_sub_dt_tb.Text + "','" + rev0_ret_dt_tb.Text + "','" + rev0_stat_tb.Text + "','" + rev1_sub_dt_tb.Text + "','" + rev1_ret_dt_tb.Text + "','" + rev1_stat_tb.Text + "','" + rev2_sub_dt_tb.Text + "','" + rev2_ret_dt_tb.Text + "','" + rev2_stat_tb.Text + "','" + rev3_sub_dt_tb.Text + "','" + rev3_ret_dt_tb.Text + "','" + rev3_stat_tb.Text + "','" + rev4_sub_dt_tb.Text + "','" + rev4_ret_dt_tb.Text + "','" + rev4_stat_tb.Text + "','" + rev5_sub_dt_tb.Text + "','" + rev5_ret_dt_tb.Text + "','" + rev5_stat_tb.Text + "','" + rev6_sub_dt_tb.Text + "','" + rev6_ret_dt_tb.Text + "','" + rev6_stat_tb.Text + "')";
                    cmd.ExecuteNonQuery();
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "insert into mirprj(mat_insp_ref_no,prj_id) values('" + matno_tb.Text + "','" + usrddlprj.SelectedValue + "')";
                cmd1.ExecuteNonQuery();
                Clear_Click(this, new EventArgs());
                    Disp();
                    con.Close();
                }
                /*   if (con.State == ConnectionState.Closed)
                   {
                       con.Open();
                   }*/

            }

            protected void Update_Click(object sender, EventArgs e)
            {
                Disp_no();
                if (TextBox1.Text == "0")
                {
                    TextBox1.Text = "";
                    notify.Text = "<span style= 'color:red'>No work inspection request found";
                }

                else
                {
                    int count = 0;

                    //Get the file uploaded to the Uploads file
                    if (FileUpload1.HasFile)
                    {
                        // Get the file extension
                        string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);

                        if (fileExtension.ToLower() != ".doc" && fileExtension.ToLower() != ".docx" && fileExtension.ToLower() != ".p]df")
                        {
                            notify.ForeColor = System.Drawing.Color.Red;
                            notify.Text = "<span style= 'color:red'>Only files with .doc and .docx extension are allowed";
                        }
                        else
                        {
                            // Get the file size
                            int fileSize = FileUpload1.PostedFile.ContentLength;
                            // If file size is greater than 2 MB
                            if (fileSize > 2097152)
                            {
                                notify.ForeColor = System.Drawing.Color.Red;
                                notify.Text = "<span style= 'color:red'>File size cannot be greater than 2 MB";
                            }
                            else
                            {
                                // Upload the file
                                FileUpload1.SaveAs(Server.MapPath("~/Uploads/" + FileUpload1.FileName));
                                notify.ForeColor = System.Drawing.Color.Green;
                                notify.Text = "<span style= 'color:green'>File uploaded successfully";
                            }
                        }
                    }
                    else
                    {
                        count++;
                        notify.ForeColor = System.Drawing.Color.Red;
                        notify.Text = "<span style= 'color:red'>Please select a file";
                    }


                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }


                    if (rev6_sub_dt_tb.Text != "")
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
                        cur_stat_rev_tb.Text = "01";
                    }
                    else if (rev0_sub_dt_tb.Text != "")
                    {
                        count++;
                        cur_stat_sub_dt_tb.Text = rev0_sub_dt_tb.Text;
                        cur_stat_rsp_dt_tb.Text = rev0_ret_dt_tb.Text;
                        cur_stat_tb.Text = rev0_stat_tb.Text;
                        cur_stat_rev_tb.Text = "00";
                    }
                    else if (rev0_sub_dt_tb.Text == "")
                    {
                        notify.Text = "<span style= 'color:red'>Please enter the initial submission date, returned date and status";

                    }
                    //Get the file uploaded to the Uploads file
                    if (FileUpload1.HasFile)
                    {
                        // Get the file extension
                        string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);

                        if (fileExtension.ToLower() != ".doc" && fileExtension.ToLower() != ".docx" && fileExtension.ToLower() != ".p]df")
                        {
                            notify.ForeColor = System.Drawing.Color.Red;
                            notify.Text = "<span style= 'color:red'>Only files with .doc and .docx extension are allowed";
                        }
                        else
                        {
                            // Get the file size
                            int fileSize = FileUpload1.PostedFile.ContentLength;
                            // If file size is greater than 2 MB
                            if (fileSize > 2097152)
                            {
                                notify.ForeColor = System.Drawing.Color.Red;
                                notify.Text = "<span style= 'color:red'>File size cannot be greater than 2 MB";
                            }
                            else
                            {
                                // Upload the file
                                FileUpload1.SaveAs(Server.MapPath("~/Uploads/" + FileUpload1.FileName));
                                notify.ForeColor = System.Drawing.Color.Green;
                                notify.Text = "<span style= 'color:green'>File uploaded successfully";
                            }
                        }
                    }
                    else
                    {
                        count++;
                        notify.Text = "<span style= 'color:red'>Please upload the document";
                    }
                    if (count != 0)
                    {
                        //adding new user details into the database
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "update mir set mat_desc ='" + matdesc_tb.Text + "',mat_sub_ref_tb='" + mat_sub_ref_tb.Text + "', mat_qnty='" + mat_qnty_tb.Text + "',manuf='" + manuf_tb.Text + "',suplr='" + suplr_tb.Text + "',dspln='" + dspln_tb.Text + "', actioner='" + actioner_tb.Text + "',cur_stat_sub_dt='" + cur_stat_sub_dt_tb.Text + "',cur_stat_rsp_dt='" + cur_stat_rsp_dt_tb.Text + "',cur_stat='" + cur_stat_tb.Text + "',cur_stat_rev='" + cur_stat_rev_tb.Text + "',no_of_dys='" + no_of_dys_tb.Text + "',remrk='" + remrk_tb.Text + "',rsn_fr_over_due='" + rsn_fr_over_due_tb.Text + "',doc='" + FileUpload1.FileName + "',rev0_sub_dt='" + rev0_sub_dt_tb.Text + "',rev0_ret_dt='" + rev0_ret_dt_tb.Text + "',rev0_stat='" + rev0_stat_tb.Text + "',rev1_sub_dt='" + rev1_sub_dt_tb.Text + "',rev1_ret_dt='" + rev1_ret_dt_tb.Text + "',rev1_stat='" + rev1_stat_tb.Text + "',rev2_sub_dt='" + rev2_sub_dt_tb.Text + "',rev2_ret_dt='" + rev2_ret_dt_tb.Text + "',rev2_stat='" + rev2_stat_tb.Text + "',rev3_sub_dt='" + rev3_sub_dt_tb.Text + "',rev3_ret_dt='" + rev3_ret_dt_tb.Text + "',rev3_stat='" + rev3_stat_tb.Text + "',rev4_sub_dt='" + rev4_sub_dt_tb.Text + "',rev4_ret_dt='" + rev4_ret_dt_tb.Text + "',rev4_stat='" + rev4_stat_tb.Text + "',rev5_sub_dt='" + rev5_sub_dt_tb.Text + "',rev5_ret_dt='" + rev5_ret_dt_tb.Text + "',rev5_stat='" + rev5_stat_tb.Text + "',rev6_sub_dt='" + rev6_sub_dt_tb.Text + "',rev6_ret_dt='" + rev6_ret_dt_tb.Text + "',rev6_stat='" + rev6_stat_tb.Text + "' where mat_insp_ref_no='" + matno_tb.Text + "'";
                        cmd.ExecuteNonQuery();
                        Disp();
                        Clear_Click(this, new EventArgs());
                        con.Close();
                    }
                    TextBox1.Text = "";

                }

            }

            protected void Delete_Click(object sender, EventArgs e)
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                Disp_no();
                //if the id is not matching with any record, app. message is displayed
                if (TextBox1.Text == "0")
                {
                    notify.Text = "\n<span style='color:red'> the record with ID = " + matno_tb.Text + " is not found..deleting is not possible if the id does not match any record</span>";
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from wir where mat_insp_ref_no ='" + matno_tb.Text + "'";

                    // cmd.CommandText = "delete from usrprj where user_id ='" + usrid_tb.Text + "'";
                    cmd.ExecuteNonQuery();
                    Disp_no();
                    if (TextBox1.Text == "0")
                    {
                        notify.Text = "<span style= 'color:green'>\n work inspection request details deleted </span>";
                    }
                    Disp();
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                Clear_Click(this, new EventArgs());
                TextBox1.Text = "";
                matno_tb.Focus();
            }

            protected void Clear_Click(object sender, EventArgs e)
            {
                TextBox1.Text = "";
                matno_tb.Text = "";
                matdesc_tb.Text = "";
                mat_sub_ref_tb.Text = "";
                mat_qnty_tb.Text = "";
                usrddlprj.SelectedIndex = 0;
                manuf_tb.Text = "";
                suplr_tb.Text = "";
                dspln_tb.Text = "";
                actioner_tb.Text = "";
                cur_stat_sub_dt_tb.Text = "";
                cur_stat_rsp_dt_tb.Text = "";
                cur_stat_tb.Text = "";
                cur_stat_rev_tb.Text = "";
                no_of_dys_tb.Text = "";
                remrk_tb.Text = "";
                rsn_fr_over_due_tb.Text = "";
                rev1_sub_dt_tb.Text = "";
                rev1_ret_dt_tb.Text = "";
                rev1_stat_tb.Text = "";
                rev2_sub_dt_tb.Text = "";
                rev2_ret_dt_tb.Text = "";
                rev2_stat_tb.Text = "";
                rev3_sub_dt_tb.Text = "";
                rev3_ret_dt_tb.Text = "";
                rev3_stat_tb.Text = "";
                rev4_sub_dt_tb.Text = "";
                rev4_ret_dt_tb.Text = "";
                rev4_stat_tb.Text = "";
                rev5_sub_dt_tb.Text = "";
                rev5_ret_dt_tb.Text = "";
                rev5_stat_tb.Text = "";
                rev6_sub_dt_tb.Text = "";
                rev6_ret_dt_tb.Text = "";
                rev6_stat_tb.Text = "";
            }



            protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
            {

                matno_tb.Text = GridView1.SelectedRow.Cells[3].Text;
                matdesc_tb.Text = GridView1.SelectedRow.Cells[4].Text;
                mat_sub_ref_tb.Text = GridView1.SelectedRow.Cells[5].Text;
                mat_qnty_tb.Text = GridView1.SelectedRow.Cells[6].Text;
                manuf_tb.Text = GridView1.SelectedRow.Cells[7].Text;
                suplr_tb.Text = GridView1.SelectedRow.Cells[8].Text;
                dspln_tb.Text = GridView1.SelectedRow.Cells[9].Text;
                actioner_tb.Text = GridView1.SelectedRow.Cells[10].Text;
                cur_stat_sub_dt_tb.Text = Convert.ToString(GridView1.SelectedRow.Cells[11].Text);
                cur_stat_rsp_dt_tb.Text = Convert.ToString(GridView1.SelectedRow.Cells[12].Text);
                cur_stat_tb.Text = GridView1.SelectedRow.Cells[13].Text;
                cur_stat_rev_tb.Text = GridView1.SelectedRow.Cells[14].Text;
                no_of_dys_tb.Text = GridView1.SelectedRow.Cells[15].Text;
                remrk_tb.Text = GridView1.SelectedRow.Cells[16].Text;
                rsn_fr_over_due_tb.Text = GridView1.SelectedRow.Cells[17].Text;
                rev0_sub_dt_tb.Text = Convert.ToString(GridView1.SelectedRow.Cells[19].Text);
                rev0_ret_dt_tb.Text = Convert.ToString(GridView1.SelectedRow.Cells[20].Text);
                rev0_stat_tb.Text = GridView1.SelectedRow.Cells[21].Text;
                rev1_sub_dt_tb.Text = Convert.ToString(GridView1.SelectedRow.Cells[22].Text);
                rev1_ret_dt_tb.Text = Convert.ToString(GridView1.SelectedRow.Cells[23].Text);
                rev1_stat_tb.Text = GridView1.SelectedRow.Cells[24].Text;
                rev2_sub_dt_tb.Text = Convert.ToString(GridView1.SelectedRow.Cells[25].Text);
                rev2_ret_dt_tb.Text = Convert.ToString(GridView1.SelectedRow.Cells[26].Text);
                rev2_stat_tb.Text = GridView1.SelectedRow.Cells[27].Text;
                rev3_sub_dt_tb.Text = Convert.ToString(GridView1.SelectedRow.Cells[28].Text);
                rev3_ret_dt_tb.Text = Convert.ToString(GridView1.SelectedRow.Cells[29].Text);
                rev3_stat_tb.Text = GridView1.SelectedRow.Cells[30].Text;
                rev4_sub_dt_tb.Text = Convert.ToString(GridView1.SelectedRow.Cells[31].Text);
                rev4_ret_dt_tb.Text = Convert.ToString(GridView1.SelectedRow.Cells[32].Text);
                rev4_stat_tb.Text = GridView1.SelectedRow.Cells[33].Text;
                rev5_sub_dt_tb.Text = Convert.ToString(GridView1.SelectedRow.Cells[34].Text);
                rev5_ret_dt_tb.Text = Convert.ToString(GridView1.SelectedRow.Cells[35].Text);
                rev5_stat_tb.Text = GridView1.SelectedRow.Cells[36].Text;
                rev6_sub_dt_tb.Text = Convert.ToString(GridView1.SelectedRow.Cells[37].Text);
                rev6_ret_dt_tb.Text = Convert.ToString(GridView1.SelectedRow.Cells[38].Text);
                rev6_stat_tb.Text = GridView1.SelectedRow.Cells[39].Text;


            }
            protected void LinkButton1_Click(object sender, EventArgs e)
            {
                LinkButton linkdownload = sender as LinkButton;
                GridViewRow gridrow = linkdownload.NamingContainer as GridViewRow;
                string downloadfile = GridView1.DataKeys[gridrow.RowIndex].Value.ToString();
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment;filename=\"" + downloadfile + "\"");
                Response.TransmitFile(Server.MapPath("Uploads/" + downloadfile));
                Response.End();

            }




            protected void Search_Click(object sender, EventArgs e)
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //if search text is not provided, it should show an appropriate message.
                if (matno_tb.Text == "")
                {

                    Clear_Click(this, new EventArgs());
                    matno_tb.Focus();
                    notify.Text = "<span style= 'color:red'>\n Please enter valid reference number for searching...no values entered for searching </span>";


                }
                else
                {
                    Disp_no();

                    if (Convert.ToInt32(TextBox1.Text) == 0)
                    {
                        Clear_Click(this, new EventArgs());
                        matno_tb.Focus();
                        notify.Text = "<span style= 'color:red'>\n\n Please enter valid data for searching.. " + matno_tb.Text + " the values don't match any record</span>";

                        Disp();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }


            }
    }
}