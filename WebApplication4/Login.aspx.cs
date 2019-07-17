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
                    Server.Transfer("DCfirstpg.aspx");

                }
                //checking if the entered credentials is admin login credentials 
                else if (emp_id.Text == (mr["user_id"].ToString()) && password.Text == (mr["user_password"].ToString()) && TextBox1.Text == "Admin")
                {
                    Server.Transfer("ADfirstpg.aspx");
                }
                //checking is the user has entered the correct login credentials
                else if (emp_id.Text == (mr["user_id"].ToString()) && password.Text == (mr["user_password"].ToString()))
                {
                    // Server.Transfer("OTfirstpg.aspx");
                    Response.Write("WELCOME");
                }
                //error message
                //if (emp_id.Text == null && password.Text == null && TextBox1.Text == null)

            }
            Response.Write("<span='color:red'>We couldn't identify you. Kindly recheck the login details</span>");

            con.Close();

        }
    }
}