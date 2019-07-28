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
    public partial class DCncrpg : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DMSdb.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            Disp();
            if (!IsPostBack)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //all unique project names are retrieved from database
                String strQuery1 = "select distinct prj_name from project";
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
                    usrddlprj.DataValueField = "prj_name";
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
            cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY ncr_ref_no) AS sl_no,* from ncr ";
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
            cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY ncr_ref_no) AS sl_no,* from ncr where ncr_ref_no = '" + ncr_ref_no_tb.Text + "'";

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
                Disp_no();
                if (TextBox1.Text == "1")
                {
                    count++;
                    notify.Text = "This id already exists ";
                }
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                if (count == 0)
                {
                    //adding new user details into the database
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into ncr(ncr_ref_no,ncr_desc,org,dt_iss,root_cse,desp,site_eng,iss,pca,aca,cai,vca,dcd,no_dys_tb,act_owner,cur_stat,rea_ex,clsr_sht,doc,consub,ca,crd,ca_rmk,cid,cvd,org_rmk,cls_dt,vc_rmk) values ('" + ncr_ref_no_tb.Text + "','" + ncr_desc_tb.Text + "','" + org_tb.Text + "','" + dt_iss_tb.Text + "','" + root_cse_tb.Text + "','" + desp_tb.Text + "','" + site_eng_tb.Text + "','" + iss_tb.Text + "','" + pca_tb.Text + "','" + aca_tb.Text + "','" + cai_tb.Text + "','" +vca_tb.Text + "','" + dcd_tb.Text + "','" + no_dys_tb.Text + "','" + act_owner_tb.Text + "','" + cur_stat_tb.Text + "','" + rea_ex_tb.Text + "','" + clsr_sht_tb.Text + "','" + FileUpload1.FileName + "','" + consub_tb.Text + "','" + ca_tb.Text + "','" + crd_tb.Text + "','" + ca_rmk_tb.Text + "','" + cid_tb.Text + "','" + cvd_tb.Text + "','" + org_rmk_tb.Text + "','" + cls_dt_tb.Text + "','" + vc_rmk_tb.Text + "')";
                    cmd.ExecuteNonQuery();
                    Clear_Click(this, new EventArgs());
                    Disp();
                    con.Close();
                }
                /*   if (con.State == ConnectionState.Closed)
                   {
                       con.Open();
                   }*/

            }

        }

        protected void Update_Click(object sender, EventArgs e)
        {

            {
                Disp_no();
                if (TextBox1.Text == "0")
                {
                    TextBox1.Text = "";
                    notify.Text = "<span style= 'color:red'>No non-conformance report found";
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
                        cmd.CommandText = "update ncr set ncr_desc='" + ncr_desc_tb + "'org='" + org_tb.Text + "',dt_iss='" + dt_iss_tb.Text + "',root_cse='" + root_cse_tb.Text + "', desp='" + desp_tb.Text + "',site_eng='" + site_eng_tb.Text + "', iss_dt='" + iss_tb.Text + "', pca='" + pca_tb.Text + "', aca='" + aca_tb.Text + "',cai='" + cai_tb.Text + "',vca='" + vca_tb.Text + "',dcd_dt='" + dcd_tb.Text + "',no_dys_tb='" + no_dys_tb.Text + "',act_owner='" + act_owner_tb.Text + "',cur_stat='" + cur_stat_tb.Text + "',rea_ex='" + rea_ex_tb.Text + "',clsr_sht='" + clsr_sht_tb.Text + "',doc='" + FileUpload1.FileName + "',consub='" + consub_tb.Text + "',ca='" + ca_tb.Text + "',crd='" + crd_tb.Text + "',ca_rmk='" + ca_rmk_tb.Text + "',cid='" + cid_tb.Text + "',cvd='" + cvd_tb.Text + "',org_rmk='" + org_rmk_tb.Text + "',cls_dt='" + cls_dt_tb.Text + "',vc_rmk='" + vc_rmk_tb.Text + "' where ncr_ref_no='"+ncr_ref_no_tb.Text+"'";
                        cmd.ExecuteNonQuery();
                        Disp();
                        Clear_Click(this, new EventArgs());
                        con.Close();
                    }
                    TextBox1.Text = "";
                }
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
                    notify.Text = "\n<span style='color:red'> the record with ID = " + ncr_ref_no_tb.Text + " is not found..deleting is not possible if the id does not match any record</span>";
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from ncr where ncr_ref_no ='" + ncr_ref_no_tb.Text + "'";

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
                ncr_ref_no_tb.Focus();
        }

        protected void Search_Click(object sender, EventArgs e)
        {

            
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //if search text is not provided, it should show an appropriate message.
                if (ncr_ref_no_tb.Text == "")
                {
                    Clear_Click(this, new EventArgs());
                ncr_ref_no_tb.Focus();
                    notify.Text = "<span style= 'color:red'>\n Please enter valid reference number for searching...no values entered for searching </span>";
                }
                else
                {
                    Disp_no();
                    GridView1_SelectedIndexChanged(this, new EventArgs());
                    if (Convert.ToInt32(TextBox1.Text) == 0)
                    {
                        Clear_Click(this, new EventArgs());
                    ncr_ref_no_tb.Focus();
                        notify.Text = "<span style= 'color:red'>\n\n Please enter valid data for searching.. " + ncr_ref_no_tb.Text + " the values don't match any record</span>";

                        Disp();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            ncr_ref_no_tb.Text = ""; 
            ncr_desc_tb.Text = ""; 
            org_tb.Text = ""; 
            dt_iss_tb.Text = "";
            root_cse_tb.Text = "";
            desp_tb.Text = "";
            site_eng_tb.Text = "";
            iss_tb.Text = "";
            pca_tb.Text = "";
            aca_tb.Text = "";
            cai_tb.Text = "";
            vca_tb.Text = "";
            dcd_tb.Text = "";
            no_dys_tb.Text = "";
            act_owner_tb.Text = "";
            cur_stat_tb.Text = "";
            rea_ex_tb.Text = "";
            clsr_sht_tb.Text = "";
            consub_tb.Text = "";
            ca_tb.Text = "";
            crd_tb.Text = "";
            ca_rmk_tb.Text = "";
            cid_tb.Text = "";
            cvd_tb.Text = "";
            org_rmk_tb.Text = "";
            cls_dt_tb.Text = "";
            vc_rmk_tb.Text = "";
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            ncr_ref_no_tb.Text = GridView1.SelectedRow.Cells[3].Text;
            ncr_desc_tb.Text = GridView1.SelectedRow.Cells[4].Text;
            org_tb.Text = GridView1.SelectedRow.Cells[5].Text;
            dt_iss_tb.Text = GridView1.SelectedRow.Cells[6].Text;
            root_cse_tb.Text = GridView1.SelectedRow.Cells[7].Text;
            desp_tb.Text = GridView1.SelectedRow.Cells[8].Text;
            site_eng_tb.Text = GridView1.SelectedRow.Cells[9].Text;
            iss_tb.Text = GridView1.SelectedRow.Cells[10].Text;
            pca_tb.Text = GridView1.SelectedRow.Cells[11].Text;
            aca_tb.Text = GridView1.SelectedRow.Cells[12].Text;
            cai_tb.Text = GridView1.SelectedRow.Cells[13].Text;
            vca_tb.Text = GridView1.SelectedRow.Cells[14].Text;
            dcd_tb.Text = GridView1.SelectedRow.Cells[15].Text;
            no_dys_tb.Text = GridView1.SelectedRow.Cells[16].Text;
            act_owner_tb.Text = GridView1.SelectedRow.Cells[17].Text;
            cur_stat_tb.Text = GridView1.SelectedRow.Cells[18].Text;
            rea_ex_tb.Text = GridView1.SelectedRow.Cells[19].Text;
            clsr_sht_tb.Text = GridView1.SelectedRow.Cells[20].Text;
            consub_tb.Text = GridView1.SelectedRow.Cells[22].Text;
            ca_tb.Text = GridView1.SelectedRow.Cells[23].Text;
            crd_tb.Text = GridView1.SelectedRow.Cells[24].Text;
            ca_rmk_tb.Text = GridView1.SelectedRow.Cells[25].Text;
            cid_tb.Text = GridView1.SelectedRow.Cells[26].Text;
            cvd_tb.Text = GridView1.SelectedRow.Cells[27].Text;
            org_rmk_tb.Text = GridView1.SelectedRow.Cells[28].Text;
            cls_dt_tb.Text = GridView1.SelectedRow.Cells[29].Text;
            vc_rmk_tb.Text = GridView1.SelectedRow.Cells[30].Text;



        }
    }
}