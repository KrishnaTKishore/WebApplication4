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
        //establishing connection
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DMSdb.mdf;Integrated Security=True");
        //before any button is clicked, the first load page properties
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
            Hide.Visible = false;
            //the text box type is made into password via code so that the values are not encrypted
            usrpass_tb.Attributes["type"] = "password";
            
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //clears notify
            if (IsPostBack)
            {
                notify.Text = "";
            }
            if (!IsPostBack)
            {

                Disp();
                //new fields adding in ddl is hidden
                PlaceHolder1.Visible = false;
                addnewdesbtn.Visible = false;
                PlaceHolder2.Visible = false;
                addnewcompbtn.Visible = false;
                newcomptb.Visible = false;
                newusrdesgtb.Visible = false;
                //all different designations are displayed from the database
                String strQuery = "select  desg_name from Desg";
                SqlCommand cmd = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = strQuery,
                    Connection = con
                };
                try
                {
                    //all the unique designations are shown in the drop down box in add/update part
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                   /* if (usrddldes_tb.Items.Count > 0)
                    {
                        usrddldes_tb.Items.Clear();
                    }*/
                    usrddldes_tb.DataSource = cmd.ExecuteReader();
                    usrddldes_tb.DataTextField = "desg_name";
                    usrddldes_tb.DataValueField = "desg_name";
                    usrddldes_tb.DataBind(); con.Close();
                    //all the unique designations are shown in the drop down box in search part
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                   /* if (seausrdesgtb.Items.Count > 0)
                    {
                        seausrdesgtb.Items.Clear();
                    }*/
                    seausrdesgtb.DataSource = cmd.ExecuteReader();
                    seausrdesgtb.DataTextField = "desg_name";
                    seausrdesgtb.DataValueField = "desg_name";
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
                    usrddlprj.DataSource = cmd1.ExecuteReader();
                    usrddlprj.DataTextField = "prj_name";
                    usrddlprj.DataValueField = "prj_id";
                    usrddlprj.DataBind();
                    con.Close();
                    //all the unique projects are shown in the drop down box in search part
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    /*
                    if (ddlseaprj.Items.Count > 0)
                    {
                        ddlseaprj.Items.Clear();
                    }*/
                    ddlseaprj.DataSource = cmd1.ExecuteReader();
                    ddlseaprj.DataTextField = "prj_name";
                    ddlseaprj.DataValueField = "prj_id";
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
                //all unique company names are retrieved from the database
                String strQuery2 = "select comp_name from comp";
                SqlCommand cmd2 = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = strQuery2,
                    Connection = con
                };
                try
                {
                    //all the unique company names are shown in the drop down box in add/update part
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    /*
                    if (usrddlcmpny.Items.Count > 0)
                    {
                        usrddlprj.Items.Clear();
                    }*/
                    usrddlcmpny.DataSource = cmd2.ExecuteReader();
                    usrddlcmpny.DataTextField = "comp_name";
                    usrddlcmpny.DataValueField = "comp_name";
                    usrddlcmpny.DataBind();
                    con.Close();
                    //all the unique company names are shown in the drop down box in select part
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    /*
                    if (ddlseaprj.Items.Count > 0)
                    {
                        ddlseaprj.Items.Clear();
                    }*/
                    ddlseacomp.DataSource = cmd2.ExecuteReader();
                    ddlseacomp.DataTextField = "comp_name";
                    ddlseacomp.DataValueField = "comp_name";
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
        //this function helps in displaying the record based on the user_id 
        public void Disp_id()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //details except password is diplayed in the gridview
            cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no ,user_id,first_name,middle_name,last_name,company_name,user_designation,user_email,mobile_no from users where user_id ='" + usrid_tb.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            //counting the number of records displayed
            TextBox1.Text = Convert.ToString(dt.Rows.Count);
            con.Close();

        }
        //this function helps in displaying th record 
        public void Disp()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,user_id,first_name,middle_name,last_name,company_name,user_designation,user_email,mobile_no from users ";

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
            //usrddlprj.SelectedValue = "";
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
        //this helps in adding new record to the database
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
                cmd.CommandText = "insert into users(user_id,first_name,middle_name,last_name,company_name,user_designation,user_email,mobile_no,user_password) values ('" + usrid_tb.Text + "','" + usrfname_tb.Text + "','" + usrmname_tb.Text + "','" + usrlname_tb.Text + "','" + usrddlcmpny.Text + "','" + usrddldes_tb.Text + "','" + usremail_tb.Text + "','" + usrmobnotb.Text + "','" + usrpass_tb.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();                
                foreach (ListItem li in usrddlprj.Items)
                {                   
                    // If the list item is selected
                    if (li.Selected)
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        SqlCommand cmd1 = con.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = "insert into usrprj(user_id,prj_id) values ('" + usrid_tb.Text + "','" + li.Value + "')";
                        cmd1.ExecuteNonQuery();
                        // Clear_Click(this, new EventArgs());
                        con.Close();
                    }                   
                    /*
                    // Retrieve the text of the selected list item
                    Response.Write("Text = " + li.Text + ", ");
                    // Retrieve the value of the selected list item
                    Response.Write("Value = " + li.Value + ", ");
                    // Retrieve the index of the selected list item
                    Response.Write("Index = " + checkboxListEducation.Items.IndexOf(li).ToString());
                    Response.Write("<br/>");*/                
                }         
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
               // cmd.CommandText = "insert into usrprj(user_id,prj_id) values ('"+usrid_tb.Text+"',(select prj_id from project where prj_name='"+usrddlprj.Text+"'))";
                 //   cmd.ExecuteNonQuery();
                //Clear_Click(this, new EventArgs());
               // con.Close();
                notify.Text = "<span style= 'color:green' >\n \nUser details added successfully</span> ";
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

        }
        //adding a new designation to the dropdownllist
        protected void addnewdesbtn_Click(object sender, EventArgs e)
        {
            if ((newusrdesgtb.Text == "") || (newusrdesgtb.Text == " "))
            {
                notify.Text = "<span style= 'color:red'>enter a valid designation</span>";
            }
            else
            {
                //usrddldes_tb.Items.Insert(usrddldes_tb.Items.Count - 1, ((TextBox)PlaceHolder1.FindControl("newusrdesgtb")).Text);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //adding new user details into the database
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Desg(des_name) values ('" + newusrdesgtb.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                notify.Text = "<span style= 'color:green'>the designation is successfully inserted into designation menu</span>";
                usrddldes_tb.SelectedValue = newusrdesgtb.Text;
                PlaceHolder1.Visible = false;
                newusrdesgtb.Visible = false;
                addnewdesbtn.Visible = false;
                usrddldes_tb.Visible = true;
            }
        }
        //adding a new company to the dropdownlist
        protected void addnewcompbtn_Click(object sender, EventArgs e)
        {
            if (newcomptb.Text != " ")
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //adding new user details into the database
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into comp(comp_name) values ('" + newcomptb.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                // usrddlcmpny.Items.Insert(usrddlcmpny.Items.Count - 1, ((TextBox)PlaceHolder2.FindControl("newcomptb")).Text);

                notify.Text = "<span style= 'color:green'>the company name is successfully inserted into dropdown menu</span>";
                usrddlcmpny.SelectedValue = newcomptb.Text;
                PlaceHolder2.Visible = false;
                newcomptb.Visible = false;

                addnewcompbtn.Visible = false;
                usrddlcmpny.Visible = true;
            }
            else
                notify.Text = "<span style= 'color:red'>you can not add invalid company names into the column</span>";
        }
        //selecting the gridview row and the details pops up in the respective textboxes
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
            PlaceHolder1.Visible = false;
            PlaceHolder2.Visible = false;
            usrddldes_tb.SelectedValue = GridView1.SelectedRow.Cells[7].Text;
            usremail_tb.Text = GridView1.SelectedRow.Cells[8].Text;
            usrmobnotb.Text = GridView1.SelectedRow.Cells[9].Text;
        }
        //deleting records from database by taking id as reference
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
                notify.Text = "\n<span style='color:red'> the record with ID = " + usrid_tb.Text + " is not found..deleting is not possible if the id does not match any record</span>";
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
               // cmd.CommandText = "delete from usrprj where user_id ='" + usrid_tb.Text + "'";
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "delete from usrprj where user_id ='" + usrid_tb.Text + "'";
                // cmd.CommandText = "delete from usrprj where user_id ='" + usrid_tb.Text + "'";
                cmd.ExecuteNonQuery();
                Disp_id();
                if (TextBox1.Text == "0")
                {
                    notify.Text = "<span style= 'color:green'>\n user details deleted </span>";
                }
                Disp();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            Clear_Click(this, new EventArgs());
            usrid_tb.Focus();
            con.Close();
        }
        //clear all the textboxes and display the database in gridview
        protected void Clear_Click(object sender, EventArgs e)
        {
            //displays data in gridview
            Disp();
            //clears the textboxes
            Revert();
        }
        //updates the database by taking the id as the primary key
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
                cmd.CommandText = " UPDATE users SET first_name = '" + usrfname_tb.Text + "', middle_name ='" + usrmname_tb.Text + "',last_name='" + usrlname_tb.Text + "',company_name='" + usrddlcmpny.Text + "',user_designation='" + usrddldes_tb.Text + "',user_email='" + usremail_tb.Text + "',user_password='" + usrpass_tb.Text + "'WHERE user_id='" + usrid_tb.Text + "'";
                //cmd.CommandText = "UPDATE users SET prj_id =(select prj_id from project where prj_name='"+ usrddlprj.Text+"') WHERE user_id = '" + usrid_tb.Text + "'";
                cmd.ExecuteNonQuery();
                foreach (ListItem li in usrddlprj.Items)
                {
                    // If the list item is selected
                    if (li.Selected)
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        SqlCommand cmd1 = con.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                       // cmd1.CommandText = "insert into usrprj(user_id,prj_id) values ('" + usrid_tb.Text + "','" + li.Value + "')";
                        cmd1.CommandText = " UPDATE usrprj SET prj_id = '" + li.Value + "'WHERE user_id='" + usrid_tb.Text + "'";
                        cmd1.ExecuteNonQuery();
                        // Clear_Click(this, new EventArgs());
                        con.Close();
                    }
                }
                Clear_Click(this, new EventArgs());
                if (con.State == ConnectionState.Open)
                    con.Close();
                Clear_Click(this, new EventArgs());
            }            
            usrid_tb.Focus();
        }
        //if the company drop down list's 'other option' is selected, textbox for entering a new company name and add to ddl btn pops up 
        protected void usrddlcmpny_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if the selected option is 'other'
            if (usrddlcmpny.SelectedValue == "other")
            {
                PlaceHolder2.Visible = true;
                //textbox for entering the new company's name is visible
                newcomptb.Visible = true;
                //add new company btn is visible
                addnewcompbtn.Visible = true;
            }
            //if the selected option is not other
            if (usrddlcmpny.SelectedValue != "other")
            {
                PlaceHolder2.Visible = false;
                // usrddlcmpny.Visible = true;
                newcomptb.Visible = false;
                //add new company btn is invisible
                addnewcompbtn.Visible = false;
            }
        }
        //if the designation's ddl's 'other' option is selected, textbox for entering a new designation name is added
        protected void usrddldes_tb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //when other option is selected, the textbox and btn is made visible
            if (usrddldes_tb.SelectedValue == "other")
            {
                PlaceHolder1.Visible = true;
                newusrdesgtb.Visible = true;
                addnewdesbtn.Visible = true;
            }
            //when any other option other than 'other' is selcted, the textbox and btn is made invisible
            if (usrddldes_tb.SelectedValue != "other")
            {
                PlaceHolder1.Visible = false;
                newusrdesgtb.Visible = false;
                addnewdesbtn.Visible = false;
            }
        }
        
        protected void Search_Click(object sender, EventArgs e)
        {
           //this variable will keep the count of search text we provided
            int c = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //if search text is not provided, it should show an appropriate message.
            if ((seausrIDtb.Text == "") && (seausrFNtb.Text == "") && (seausrLNtb.Text == "") && (seausrdesgtb.SelectedIndex == 0) && (ddlseaprj.SelectedIndex == 0) && (ddlseacomp.SelectedIndex == 0))
            {
                notify.Text = "<span style= 'color:red'>\n Please enter valid data for searching...no values entered for searching </span>";                
            }
            else { 
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
                if (c == 0)
                {//when id is entered
                    if (seausrIDtb.Text != "")
                    {
                        c++;
                        //id + first name
                        if (seausrFNtb.Text != "")
                        {
                            c++;
                            cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where first_name='" + seausrFNtb.Text + "' and user_id='" + seausrIDtb.Text + "' ";
                        }
                        //id + last name
                        if (seausrLNtb.Text != "")
                        {
                            c++;
                            cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where last_name='" + seausrLNtb.Text + "' and user_id='" + seausrIDtb.Text + "'";
                        }
                       //id + designation
                        if (seausrdesgtb.SelectedIndex != 0)
                        {
                            c++;
                            cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where user_designation='" + seausrdesgtb.SelectedValue + "' and user_id='" + seausrIDtb.Text + "'";
                        }
                      /*  if (ddlseaprj.SelectedIndex != 0)
                        {
                            c++;
                            cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where project_name='" + ddlseaprj.SelectedValue + "' and user_id='" + seausrIDtb.Text + "'";

                        }*/
                        //id + company
                        if (ddlseacomp.SelectedIndex != 0)
                        {
                            c++;
                            cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where company_name='" + ddlseacomp.SelectedValue + "' and user_id='" + seausrIDtb.Text + "'";
                        }
                        cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where user_id='" + seausrIDtb.Text + "'";

                        //if more than two values are entered
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
                        /*
                        if (ddlseaprj.SelectedIndex != 0)
                        {
                            c++;
                            cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where project_name='" + ddlseaprj.SelectedValue + "' and first_name='" + seausrFNtb.Text + "'";

                        }*/
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
                        /*
                        if (ddlseaprj.SelectedIndex != 0)
                        {
                            c++;
                            cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where project_name='" + ddlseaprj.SelectedValue + "' and last_name='" + seausrLNtb.Text + "'";

                        }*/
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
                      /*  if (ddlseaprj.SelectedIndex != 0)
                        {
                            c++;
                            cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY user_id) AS sl_no,* from users where project_name='" + ddlseaprj.SelectedValue + "'and user_designation='" + seausrdesgtb.SelectedValue + "'";

                        }*/
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
                    /*
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
                    }*/
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
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    showpass.Visible = true;
                }
            }
        }
        
        public void Filllab()
    {
            this.GridView1.SelectedIndex = 0;
            lab_id.Text = GridView1.SelectedRow.Cells[2].Text;
            Labfnm.Text = GridView1.SelectedRow.Cells[3].Text;
            Labmnm.Text = GridView1.SelectedRow.Cells[4].Text;
            Lablnm.Text = GridView1.SelectedRow.Cells[5].Text;
            Labcmpy.Text = GridView1.SelectedRow.Cells[6].Text;
            Labdesg.Text = GridView1.SelectedRow.Cells[7].Text;
            Labmail.Text = GridView1.SelectedRow.Cells[8].Text;
            Labmob.Text = GridView1.SelectedRow.Cells[9].Text;
           TextBox2.Text = GridView1.SelectedRow.Cells[10].Text;
                Labpass.Text = "*****";
                Disp();
      
    }
        //show the password 
        protected void showpass_Click(object sender, EventArgs e)
        {
            Labpass.Text = TextBox2.Text;
            showpass.Visible = false;
            Hide.Visible = true;
        }
        //
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
            Labdesg.Text = "";
            Labmail.Text = "";
            Labmob.Text = "";
            Labpass.Text = "";
            seausrIDtb.Text = "";
            seausrFNtb.Text = "";
            seausrLNtb.Text = "";
            seausrdesgtb.SelectedIndex = 0;
            ddlseacomp.SelectedIndex = 0;
            ddlseaprj.SelectedIndex = 0;
        }

        protected void ddlseacomp_SelectedIndexChanged(object sender, EventArgs e)
        {
      
        }

        protected void Hide_Click(object sender, EventArgs e)
        {
            Labpass.Text = "*****";
            Hide.Visible = false;
            showpass.Visible = true;
        }

      
    }

    }