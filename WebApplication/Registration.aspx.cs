using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WebApplication
{
    public partial class Registration : System.Web.UI.Page
    {
        TestInfoDataContext db;
        string connectionstring;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserID"] == null)
            {
                Response.Redirect("Main.aspx");
            }
             // 1.
            // Get the current ImportantData.
            connectionstring = GlobalVariables.DbPath;

            // 2.
            // If we don't have the data yet, initialize it.
            if (connectionstring == null)
            {
                // Example code.
                connectionstring = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\USERS\USER\DOWNLOADS\SCHOOL WORK\CSHARP\PROJECT\WEBAPPLICATION\WEBAPPLICATION\APP_DATA\TESTS.MDF;Integrated Security=True;Connect Timeout=30";
                GlobalVariables.DbPath = connectionstring;
            }

             //3.
            // Render the important data.
            if (!IsPostBack)
            //check if the webpage is loaded for the first time. 
            {
                ViewState["PreviousPage"] = Request.UrlReferrer;//Saves the Previous page url in ViewState 
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            db = new TestInfoDataContext(GlobalVariables.DbPath);



            if (!db.DatabaseExists())
            {
                db.CreateDatabase();
            }

            login l = new login
            {
                username = UsrName.Text.Trim(),
                pwd = PwdText.Text.Trim(),
                isTeacher = IsTeacher.Checked

            };
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM [login] WHERE ([username] = @user)", conn);
            check_User_Name.Parameters.AddWithValue("@user", l.username);
            int UserExist = (int)check_User_Name.ExecuteScalar();
            if (UserExist > 0)
            {
                warningLabel.Visible=true;
                UsrName.Text = null;
                PwdText.Text = null;
                IsTeacher.Checked = false;

            }
            else
            {
                db.logins.InsertOnSubmit(l);
                db.SubmitChanges();
                if (ViewState["PreviousPage"] != null) //Check if the ViewState  
                //contains Previous page URL       
                {
                    Response.Redirect(ViewState["PreviousPage"].ToString());
                }
                else
                {
                    warningLabel.Visible=false;
                    UsrName.Text = null;
                    PwdText.Text = null;
                    IsTeacher.Checked = false;
                }

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (ViewState["PreviousPage"] != null) //Check if the ViewState  
            //contains Previous page URL       
            {
                Response.Redirect(ViewState["PreviousPage"].ToString());
                //Redirect to
                //Previous page by retrieving the PreviousPage Url from ViewState. 
            }
        }
    }
}