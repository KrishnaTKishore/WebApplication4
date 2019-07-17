using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class ADcmppg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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