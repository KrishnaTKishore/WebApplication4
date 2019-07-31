using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication4
{
    public partial class LogIn : System.Web.UI.Page
    {
        //fetching the physical location of the database
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DMSdb.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            if (Request.Cookies["logid"] != null)
            {
                logid.Text = Request.Cookies["logid"].Value.ToString();
            }
            if (Request.Cookies["logdesg"] != null)
            {
                logdesg.Text = Request.Cookies["logdesg"].Value.ToString();
            }
        }

        protected void Log_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataReader mr = null;
            //retrieving the data of the corresponding id and password entered
            SqlCommand cmd = new SqlCommand("select user_id,user_password,user_designation from users where user_id ='" + emp_id.Text + "' and user_password='" + password.Text + "'", con);

            mr = cmd.ExecuteReader();

            while (mr.Read())
            {
                //entering the designation fetched into the hidden designation box
                TextBox1.Text = (mr["user_designation"].ToString());
                //checking if the entered credentials is dc login credentials 
                if (emp_id.Text == (mr["user_id"].ToString()) && password.Text == (mr["user_password"].ToString()) && TextBox1.Text == "Document Controller")  // use the search function from DB
                {

                    HttpCookie Cookie = new HttpCookie("logid");
                    Cookie.Value = emp_id.Text;
                    Cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(Cookie);
                    HttpCookie Cookie1 = new HttpCookie("logdesg");
                    Cookie1.Value = TextBox1.Text;
                    Cookie1.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(Cookie1);
                    Server.Transfer("DCfirstpg.aspx");

                }
                //checking if the entered credentials is admin login credentials 
                else if (emp_id.Text == (mr["user_id"].ToString()) && password.Text == (mr["user_password"].ToString()) && TextBox1.Text == "Admin")
                {
                    HttpCookie Cookie = new HttpCookie("logid");
                    Cookie.Value = emp_id.Text;
                    Cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(Cookie);
                    HttpCookie Cookie1 = new HttpCookie("logdesg");
                    Cookie1.Value = TextBox1.Text;
                    Cookie1.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(Cookie1);
                    Server.Transfer("ADfirstpg.aspx");
                }
                //checking is the user has entered the correct login credentials
                else if (emp_id.Text == (mr["user_id"].ToString()) && password.Text == (mr["user_password"].ToString()))
                {
                    HttpCookie Cookie = new HttpCookie("logid");
                    Cookie.Value = emp_id.Text;
                    Cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(Cookie);
                    HttpCookie Cookie1 = new HttpCookie("logdesg");
                    Cookie1.Value = TextBox1.Text;
                    Cookie1.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(Cookie1);
                    Server.Transfer("OTfirstpg.aspx");
                }
                //error message
                //if (emp_id.Text == null && password.Text == null && TextBox1.Text == null)

            }
            Response.Write("<span='color:red'>We couldn't identify you. Kindly recheck the login details</span>");

            con.Close();

        }
    }
}