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
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DMSdb.mdf;Integrated Security=True");
        
        protected void Page_Load(object sender, EventArgs e)
        {
            usrpass_tb.Attributes["type"] = "password";
            //Disp();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (IsPostBack)
            {
                notify.Text = "";
            }
            if (!IsPostBack)
            {
                Disp();

                PlaceHolder1.Visible = false;
                addnewdesbtn.Visible = false;
                PlaceHolder2.Visible = false;
                addnewcompbtn.Visible = false;
                newcomptb.Visible = false;
                newusrdesgtb.Visible = false;


                //all different designations are displayed from the database
                String strQuery = "select distinct user_designation from users";
                SqlCommand cmd = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = strQuery,
                    Connection = con
                };
                try
                {
                    //all the unique designations are shown in the drop down box 
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    usrddldes_tb.DataSource = cmd.ExecuteReader();
                    usrddldes_tb.DataTextField = "user_designation";
                    usrddldes_tb.DataValueField = "user_designation";
                    usrddldes_tb.DataBind();con.Close();
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    seausrdesgtb.DataSource= cmd.ExecuteReader();
                    seausrdesgtb.DataTextField = "user_designation";
                    seausrdesgtb.DataValueField = "user_designation";
                    seausrdesgtb.DataBind();
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
                String strQuery1 = "select distinct prj_name from project";
                SqlCommand cmd1 = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = strQuery1,
                    Connection = con
                };
                try
                {
                    //all the unique designations are shown in the drop down box 
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    usrddlprj.DataSource = cmd1.ExecuteReader();
                    usrddlprj.DataTextField = "prj_name";
                    usrddlprj.DataValueField = "prj_name";
                    usrddlprj.DataBind();
                    con.Close();
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    ddlseaprj.DataSource = cmd1.ExecuteReader();
                    ddlseaprj.DataTextField = "prj_name";
                    ddlseaprj.DataValueField = "prj_name";
                    ddlseaprj.DataBind();
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
                String strQuery2 = "select distinct company_name from users";
                SqlCommand cmd2 = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = strQuery2,
                    Connection = con
                };
                try
                {
                    //all the unique designations are shown in the drop down box 
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    usrddlcmpny.DataSource = cmd2.ExecuteReader();
                    usrddlcmpny.DataTextField = "company_name";
                    usrddlcmpny.DataValueField = "company_name";
                    usrddlcmpny.DataBind();
                    con.Close();
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    ddlseacomp.DataSource = cmd2.ExecuteReader();
                    ddlseacomp.DataTextField = "company_name";
                    ddlseacomp.DataValueField = "company_name";
                    ddlseacomp.DataBind();
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
        public void Disp_id()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no ,user_id,first_name,middle_name,last_name,company_name,project_name,user_designation,user_email,mobile_no from users where user_id ='" + usrid_tb.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            //GridView1.Columns[9].Visible = false;
            TextBox1.Text = Convert.ToString(dt.Rows.Count);
            con.Close();

        }
        public void Disp()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,user_id,first_name,middle_name,last_name,company_name,project_name,user_designation,user_email,mobile_no from users ";

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            // GridView1.Columns[11].Visible = false;
            con.Close();

        }

        //revert back to the empty text boxes
        public void Revert()
        {
            usrid_tb.Text = "";
            usrfname_tb.Text = "";
            usrmname_tb.Text = "";
            usrlname_tb.Text = "";
            usrddldes_tb.SelectedValue = " ";
            usrddlcmpny.SelectedValue = " ";
            usrddlprj.SelectedValue = " ";
            usremail_tb.Text = "";
            usrmobnotb.Text = "";
            usrpass_tb.Text = "";
            PlaceHolder1.Visible = false;
            addnewdesbtn.Visible = false;
            usrddlcmpny.Visible = true;
            PlaceHolder2.Visible = false;
            addnewcompbtn.Visible = false;
            usrddldes_tb.Visible = true;
        }

        protected void Add_btn_Click(object sender, EventArgs e)
        {

            // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func()", true);
            Disp_id();

            if (TextBox1.Text == "1")
            {
                notify.Text = "<span style= 'color:red'>\n \nTwo employees can not share the same user ID...</span> Please use update to modify details or change the user id for a new user";
            }
            else
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //adding new user details into the database
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into users(user_id,first_name,middle_name,last_name,company_name,project_name,user_designation,user_email,mobile_no,user_password) values ('" + usrid_tb.Text + "','" + usrfname_tb.Text + "','" + usrmname_tb.Text + "','" + usrlname_tb.Text + "','" + usrddlcmpny.Text + "','" + usrddlprj.Text + "','" + usrddldes_tb.Text + "','" + usremail_tb.Text + "','" + usrmobnotb.Text + "','" + usrpass_tb.Text + "')";
                cmd.ExecuteNonQuery();
                Clear_Click(this, new EventArgs());
                notify.Text = "<span style= 'color:green' >\n \nUser details added successfully</span> ";
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

        }

        protected void addnewdesbtn_Click(object sender, EventArgs e)
        {
            if ((newusrdesgtb.Text == "") || (newusrdesgtb.Text == " "))
            {
                notify.Text = "<span style= 'color:green'>enter a valid designation</style>";

            }
            usrddldes_tb.Items.Insert(usrddldes_tb.Items.Count - 1, ((TextBox)PlaceHolder1.FindControl("newusrdesgtb")).Text);
            notify.Text = "<span style= 'color:green'>the designation is successfully inserted into dropdown menu</style>";
            usrddldes_tb.SelectedValue = newusrdesgtb.Text;
            PlaceHolder1.Visible = false;
            newusrdesgtb.Visible = false;
            addnewdesbtn.Visible = false;
            usrddldes_tb.Visible = true;
        }

        protected void addnewcompbtn_Click(object sender, EventArgs e)
        {
            if (newcomptb.Text != " ")
            {
                usrddlcmpny.Items.Insert(usrddlcmpny.Items.Count - 1, ((TextBox)PlaceHolder2.FindControl("newcomptb")).Text);
                notify.Text = "<span style= 'color:green'>the company name is successfully inserted into dropdown menu</style>";
                usrddlcmpny.SelectedValue = newcomptb.Text;
                PlaceHolder2.Visible = false;
                newcomptb.Visible = false;

                addnewcompbtn.Visible = false;
                usrddlcmpny.Visible = true;
            }
            else
                notify.Text = "you can not add invalid company names into the column";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            usrid_tb.Text = GridView1.SelectedRow.Cells[2].Text;
            usrfname_tb.Text = GridView1.SelectedRow.Cells[3].Text;
            //if the middle name column was empty
            if (GridView1.SelectedRow.Cells[4].Text == "&nbsp;")
            {
                usrmname_tb.Text = "";
            }
            else
            {
                usrmname_tb.Text = GridView1.SelectedRow.Cells[4].Text;
            }
            usrlname_tb.Text = GridView1.SelectedRow.Cells[5].Text;
            usrddlcmpny.SelectedValue = GridView1.SelectedRow.Cells[6].Text;
            usrddlprj.SelectedValue = GridView1.SelectedRow.Cells[7].Text;
            PlaceHolder1.Visible = false;
            PlaceHolder2.Visible = false;
            usrddldes_tb.SelectedValue = GridView1.SelectedRow.Cells[8].Text;
            usremail_tb.Text = GridView1.SelectedRow.Cells[9].Text;
            usrmobnotb.Text = GridView1.SelectedRow.Cells[10].Text;

        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            Disp_id();
            //if the id is not matching with any record, app. message is displayed
            if (TextBox1.Text == "0")
            {
                notify.Text = "\n<span color:'red'> the record with ID = " + usrid_tb.Text + " is not found..deleting is not possible if the id does not match</span>";
            }
            else
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from users where user_id ='" + usrid_tb.Text + "'";
                cmd.ExecuteNonQuery();
                Disp();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            Clear_Click(this, new EventArgs());

        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            Disp();
            Revert();
        }

        protected void Update_Click(object sender, EventArgs e)
        {

            Add_btn.OnClientClick = "return validation();";
            Disp_id();
            if (Convert.ToInt32(TextBox1.Text) != 1)
            {
                notify.Text = "<span style= 'color:red'>\n \nThe user with user id'" + usrid_tb + "' is not found";
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
                cmd.CommandText = " UPDATE users SET first_name = '" + usrfname_tb.Text + "', middle_name ='" + usrmname_tb.Text + "',last_name='" + usrlname_tb.Text + "',company_name='" + usrddlcmpny.Text + "',project_name='" + usrddlprj.Text + "',user_designation='" + usrddldes_tb.Text + "',user_email='" + usremail_tb.Text + "',user_password='" + usrpass_tb.Text + "'WHERE user_id='" + usrid_tb.Text + "'";
                cmd.ExecuteNonQuery();
                Clear_Click(this, new EventArgs());
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        protected void usrddlcmpny_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (usrddlcmpny.SelectedValue == "other")
            {
                PlaceHolder2.Visible = true;
                // usrddlcmpny.Visible = true;
                newcomptb.Visible = true;
                addnewcompbtn.Visible = true;
            }

        }

        protected void usrddldes_tb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (usrddldes_tb.SelectedValue == "other")
            {
                PlaceHolder1.Visible = true;
                // usrddldes_tb.Visible = true;
                newusrdesgtb.Visible = true;
                addnewdesbtn.Visible = true;
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            int count = 0;
            int c = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }


            if ((seausrIDtb.Text == "") && (seausrFNtb.Text == "") && (seausrLNtb.Text == "") && (seausrdesgtb.SelectedIndex == 0) && (ddlseaprj.SelectedIndex == 0) && (ddlseacomp.SelectedIndex == 0))
            {
                notify.Text = "<span style= 'color:red'>\n Please enter valid data for searching...no values entered for searching </span>";
                count++;
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (c == 0)
            {
                if (seausrIDtb.Text != "")
                {
                    c++;
                    if (seausrFNtb.Text != "")
                    {
                        c++;
                        cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where first_name='" + seausrFNtb.Text + "' and user_id='" + seausrIDtb.Text + "' ";
                    }
                    if (seausrLNtb.Text != "")
                    {
                        c++;
                        cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where last_name='" + seausrLNtb.Text + "' and user_id='" + seausrIDtb.Text + "'";

                    }
                    if (seausrLNtb.Text != "")
                    {
                        c++;
                        cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where last_name='" + seausrLNtb.Text + "' and user_id='" + seausrIDtb.Text + "'";

                    }
                    if (seausrdesgtb.SelectedIndex != 0)
                    {
                        c++;
                        cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where user_designation='" + seausrdesgtb.SelectedValue + "' and user_id='" + seausrIDtb.Text + "'";


                    }
                    if (ddlseaprj.SelectedIndex != 0)
                    {
                        c++;
                        cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where project_name='" + ddlseaprj.SelectedValue + "' and user_id='" + seausrIDtb.Text + "'";

                    }
                    if (ddlseacomp.SelectedIndex != 0)
                    {
                        c++;
                        cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where company_name='" + ddlseacomp.SelectedValue + "' and user_id='" + seausrIDtb.Text + "'";

                    }
                    cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where user_id='" + seausrIDtb.Text + "'";


                    if (c > 2)
                    {
                        notify.Text = "<span style= 'color:red'>\n Please enter not more than two values for searching </span>";
                        Disp();
                    }

                }
                else if ((c == 0) && (seausrFNtb.Text != ""))
                {

                    c++;
                    if (seausrLNtb.Text != "")
                    {
                        c++;
                        cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where last_name='" + seausrLNtb.Text + "' and first_name='" + seausrFNtb.Text + "'";

                    }
                    if (seausrdesgtb.SelectedIndex != 0)
                    {
                        c++;
                        cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where user_designation='" + seausrdesgtb.SelectedValue + "' and first_name='" + seausrFNtb.Text + "'";


                    }
                    if (ddlseaprj.SelectedIndex != 0)
                    {
                        c++;
                        cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where project_name='" + ddlseaprj.SelectedValue + "' and first_name='" + seausrFNtb.Text + "'";

                    }
                    if (ddlseacomp.SelectedIndex != 0)
                    {
                        c++;
                        cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where company_name='" + ddlseacomp.SelectedValue + "' and first_name='" + seausrFNtb.Text + "'";

                    }

                    cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where first_name='" + seausrFNtb.Text + "'";

                    if (c > 2)
                    {
                        notify.Text = "<span style= 'color:red'>\n Please enter not more than two values for searching </span>";
                        Disp();
                    }

                }

                if ((seausrLNtb.Text != "") && (c == 0))
                {
                    c++;
                    if (seausrdesgtb.SelectedIndex != 0)
                    {
                        c++;
                        cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where user_designation='" + seausrdesgtb.SelectedValue + "' and last_name='" + seausrLNtb.Text + "'";


                    }
                    if (ddlseaprj.SelectedIndex != 0)
                    {
                        c++;
                        cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where project_name='" + ddlseaprj.SelectedValue + "' and last_name='" + seausrLNtb.Text + "'";

                    }
                    if (ddlseacomp.SelectedIndex != 0)
                    {
                        c++;
                        cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where company_name='" + ddlseacomp.SelectedValue + "'and last_name='" + seausrLNtb.Text + "'";

                    }
                    if (c > 2)
                        cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where last_name='" + seausrLNtb.Text + "'";

                }
                if ((seausrdesgtb.SelectedIndex != 0) && (c == 0))
                {
                    c++;
                    if (ddlseaprj.SelectedIndex != 0)
                    {
                        c++;
                        cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where project_name='" + ddlseaprj.SelectedValue + "'and user_designation='" + seausrdesgtb.SelectedValue + "'";

                    }
                    if (ddlseacomp.SelectedIndex != 0)
                    {
                        c++;
                        cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where company_name='" + ddlseacomp.SelectedValue + "'and user_designation='" + seausrdesgtb.SelectedValue + "'";

                    }

                    cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where user_designation='" + seausrdesgtb.SelectedValue + "'";

                    if (c > 2)
                    {
                        notify.Text = "<span style= 'color:red'>\n Please enter not more than two values for searching </span>";
                        Disp();
                    }
                }
                if ((ddlseaprj.SelectedIndex != 0) && (c == 0))
                {
                    c++;
                    if (ddlseacomp.SelectedIndex != 0)
                    {
                        c++;
                        cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where company_name='" + ddlseacomp.SelectedValue + "'and project_name='" + ddlseaprj.SelectedValue + "'";

                    }

                    cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where project_name='" + ddlseaprj.SelectedValue + "'";

                    if (c > 2)
                    {
                        notify.Text = "<span style= 'color:red'>\n Please enter not more than two values for searching </span>";
                        Disp();
                    }
                }
                if ((ddlseacomp.SelectedIndex != 0) && (c == 0))
                {
                    c++;
                    cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where company_name='" + ddlseacomp.SelectedValue + "'";

                    if (c > 2)
                    {
                        notify.Text = "<span style= 'color:red'>\n Please enter not more than two values for searching </span>";
                        Disp();
                    }
                }
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                // GridView1.Columns[11].Visible = false;
                TextBox1.Text = Convert.ToString(dt.Rows.Count);
                if (Convert.ToInt32(TextBox1.Text) == 1)
                {

                    Filllab();
                }
                if (Convert.ToInt32(TextBox1.Text) == 0)
                {
                    notify.Text = "<span style= 'color:red'>\n\n Please enter valid data for searching..the values don't match any record</span>";
                    Disp();
                }

                con.Close();

            }
        }



            /*
                        if ((seausrFNtb.Text == "") && (seausrIDtb.Text != null))
                        {
                            count++;
                            if (con.State == ConnectionState.Closed)
                            {
                                con.Open();
                            }
                            SqlCommand cmd1 = con.CreateCommand();
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = " select ROW_NUMBER() OVER (ORDER BY user_id),* from users where user_id='" + seausrIDtb.Text + "'";
                            cmd1.ExecuteNonQuery();

                            DataTable dt = new DataTable();
                            SqlDataAdapter da = new SqlDataAdapter(cmd1);
                            da.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                            TextBox1.Text = Convert.ToString(dt.Rows.Count);
                            Filllab();
                            con.Close();
                        }
                        if ((seausrIDtb.Text == "") && (seausrFNtb.Text != null))
                        {

                            count++;

                            if (con.State == ConnectionState.Closed)
                            {
                                con.Open();
                            }
                            SqlCommand cmd1 = con.CreateCommand();
                            cmd1.CommandType = CommandType.Text;
                            if (seausrFNtb.Text[0] == ' ')
                            {
                                notify.Text="<span style= 'color:red'>Please enter a valid name</span>";
                                con.Close();
                            }
                            else
                            {
                                cmd1.CommandText = " select ROW_NUMBER() OVER (ORDER BY user_id),* from users where first_name like '%" + seausrFNtb.Text + "%'";
                                cmd1.ExecuteNonQuery();
                                DataTable dt = new DataTable();
                                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                                da.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                                TextBox1.Text = Convert.ToString(dt.Rows.Count);
                                Filllab();
                                con.Close();
                            }
                        }


                        if ((seausrIDtb.Text != null) && (seausrFNtb.Text != null))
                        {
                            if (count == 0)
                            {
                                if (con.State == ConnectionState.Closed)
                                {
                                    con.Open();
                                }
                                SqlCommand cmd1 = con.CreateCommand();
                                cmd1.CommandType = CommandType.Text;
                                cmd1.CommandText = " select ROW_NUMBER() OVER (ORDER BY user_id),* from users where user_id='" + seausrIDtb.Text + "' and first_name='" + seausrFNtb.Text + "'";

                cmd1.ExecuteNonQuery();
                                DataTable dt = new DataTable();
                                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                                da.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                                TextBox1.Text = Convert.ToString(dt.Rows.Count);
                                Filllab();
                                con.Close();

                            }
                            
      
        }

    */


        public void Filllab()
    {
           
       
       

            this.GridView1.SelectedIndex = 0;
            lab_id.Text = GridView1.SelectedRow.Cells[2].Text;
            Labfnm.Text = GridView1.SelectedRow.Cells[3].Text;
            Labmnm.Text = GridView1.SelectedRow.Cells[4].Text;
            Lablnm.Text = GridView1.SelectedRow.Cells[5].Text;
            Labcmpy.Text = GridView1.SelectedRow.Cells[6].Text;
            Labprj.Text = GridView1.SelectedRow.Cells[7].Text;
            Labdesg.Text = GridView1.SelectedRow.Cells[8].Text;
            Labmail.Text = GridView1.SelectedRow.Cells[9].Text;
            Labmob.Text = GridView1.SelectedRow.Cells[10].Text;
           // Labpass.Text = GridView1.SelectedRow.Cells[11].Text;
           TextBox2.Text = GridView1.SelectedRow.Cells[11].Text;
                Labpass.Text = "*****";
                Disp();
      
    }

        protected void showpass_Click(object sender, EventArgs e)
        {
            Labpass.Text = TextBox2.Text;
        }

        protected void Lodbtn_Click(object sender, EventArgs e)
        {
            usrid_tb.Text = lab_id.Text;
            usrfname_tb.Text = Labfnm.Text;
            //if the middle name column was empty
            if (Labmnm.Text == "&nbsp;")
            {
                usrmname_tb.Text = "";
            }
            else
            {
                usrmname_tb.Text = Labmnm.Text;
            }
            usrlname_tb.Text = Lablnm.Text;
            usrddlcmpny.SelectedValue = Labcmpy.Text;
            usrddlprj.SelectedValue = Labprj.Text;
            usrddldes_tb.SelectedValue =Labdesg.Text;
            usremail_tb.Text =Labmail.Text;
            if (Labmob.Text == "&nbsp;")
            {
                usrmobnotb.Text = "";
            }
            else
            {
                usrmobnotb.Text = Labmob.Text;
            }

        }

        protected void Clearsrch_Click(object sender, EventArgs e)
        {

            lab_id.Text = "";
            Labfnm.Text = "";
            Labmnm.Text = "";
            Lablnm.Text = "";
            Labcmpy.Text = "";
            Labprj.Text = "";
            Labdesg.Text = "";
            Labmail.Text = "";
            Labmob.Text = "";
            Labpass.Text = "";
            seausrIDtb.Text = "";
            seausrFNtb.Text = "";
            seausrLNtb.Text = "";
            seausrdesgtb.Text = "";
            ddlseacomp.SelectedIndex = 0;
            ddlseaprj.SelectedIndex = 0;
        }

        protected void ddlseacomp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    }