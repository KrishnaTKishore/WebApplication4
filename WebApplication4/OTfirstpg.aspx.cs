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
    public partial class OTfirstpg : System.Web.UI.Page
    {
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
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //all unique project names are retrieved from database
            String strQuery1 = "select prj_id, prj_name from project";

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
                /*
                if (usrddlprj.Items.Count > 0)
                {
                    usrddlprj.Items.Clear();
                }*/
                seaprjNMtb.DataSource = cmd1.ExecuteReader();
                seaprjNMtb.DataTextField = "prj_name";
                seaprjNMtb.DataValueField = "prj_id";
                seaprjNMtb.DataBind();
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
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

        }
        

        //searches the record
        protected void Search_Click(object sender, EventArgs e)
        {
            if ((seadoctyptb.Text == "") || (seaprjNMtb.Text == ""))
            {
                notify.Text = "<span style='color:red'>Neccessary columns filled to search</span> ";
            }
            else
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                switch (seadoctyptb.SelectedValue)
                {
                    case "wir":
                        {
                            cmd1.CommandText = "select ROW_NUMBER() OVER (ORDER BY wrk_insp_ref_no) AS sl_no,* from wir where  wrk_insp_ref_no = (select wrk_insp_ref_no from wirprj where prj_id='" + seaprjNMtb.SelectedValue + "')";
                            break;
                        }
                    case "mir" :
                        {
                            cmd1.CommandText = "select ROW_NUMBER() OVER (ORDER BY mat_insp_ref_no) AS sl_no,* from mir where  mat_insp_ref_no = (select mat_insp_ref_no from mirprj where prj_id='" + seaprjNMtb.SelectedValue+"')";
                            break;
                        }
                   
                    case "ms":
                        {
                            cmd1.CommandText = "select ROW_NUMBER() OVER (ORDER BY mat_sub_ref_no) AS sl_no,* from ms where  mat_sub_ref_no = (select mat_sub_ref_no from msprj where prj_id='" + seaprjNMtb.SelectedValue + "')";
                            break;
                        }
                    case "ncr":
                        {
                            cmd1.CommandText = "select ROW_NUMBER() OVER (ORDER BY ncr_ref_no) AS sl_no,* from ncr where  ncr_ref_no = (select ncr_ref_no from ncrprj where prj_id='" + seaprjNMtb.SelectedValue + "')";
                            break;
                        }
                    case "sor":
                        {
                            cmd1.CommandText = "select ROW_NUMBER() OVER (ORDER BY sor_ref_no) AS sl_no,* from sor where  sor_ref_no = (select sor_ref_no from sorprj where prj_id='" + seaprjNMtb.SelectedValue + "')";
                            break;
                        }
                 /*   case "mss":
                        {
                            cmd1.CommandText = "select ROW_NUMBER() OVER (ORDER BY mat_insp_ref_no) AS sl_no,* from mir where  mat_insp_ref_no = (select mat_insp_ref_no from mirprj where prj_id='" + seaprjNMtb.SelectedValue + "')";
                            break;
                        }
                    case "mir":
                        {
                            cmd1.CommandText = "select ROW_NUMBER() OVER (ORDER BY mat_insp_ref_no) AS sl_no,* from mir where  mat_insp_ref_no = (select mat_insp_ref_no from mirprj where prj_id='" + seaprjNMtb.SelectedValue + "')";
                            break;
                        }
                    case "mir":
                        {
                            cmd1.CommandText = "select ROW_NUMBER() OVER (ORDER BY mat_insp_ref_no) AS sl_no,* from mir where  mat_insp_ref_no = (select mat_insp_ref_no from mirprj where prj_id='" + seaprjNMtb.SelectedValue + "')";
                            break;
                        }
                    case "mir":
                        {
                            cmd1.CommandText = "select ROW_NUMBER() OVER (ORDER BY mat_insp_ref_no) AS sl_no,* from mir where  mat_insp_ref_no = (select mat_insp_ref_no from mirprj where prj_id='" + seaprjNMtb.SelectedValue + "')";
                            break;
                        }
                    case "mir":
                        {
                            cmd1.CommandText = "select ROW_NUMBER() OVER (ORDER BY mat_insp_ref_no) AS sl_no,* from mir where  mat_insp_ref_no = (select mat_insp_ref_no from mirprj where prj_id='" + seaprjNMtb.SelectedValue + "')";
                            break;
                        }*/
                    default:
                        {
                            break;
                        }
                }
                        cmd1.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd1);
                        da.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        TextBox1.Text = Convert.ToString(dt.Rows.Count);
                        if (TextBox1.Text == "0")
                        {
                            notify.Text = "<span style='color:red'> No record found </span>";
                        }
                        con.Close();
                
            }
        
        }
        //cleans the search column and search results and notify
        protected void Clearsrch_Click(object sender, EventArgs e)
        {
            seadoctyptb.Text = "";
            seaprjNMtb.Text = "";
            notify.Text = "";
        }

        protected void seadoctyptb_SelectedIndexChanged(object sender, EventArgs e)
        {

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

    }
}