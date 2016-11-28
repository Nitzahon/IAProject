using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication
{

    public partial class Main : System.Web.UI.Page
    {

        string connectionstring;
        
        protected void Page_Load(object sender, EventArgs e)
        {
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
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from login where username='" + txtusername.Text +"' and pwd ='" + txtpassword.Text +"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                HttpContext.Current.Session["UserID"] = dt.Rows[0][0].ToString();
                HttpContext.Current.Session["isTeacher"] = (bool)dt.Rows[0][3];
                Response.Redirect("TeacherArea.aspx");
            }
            else
            {
                Response.Write("<script>alert('Please enter valid Username and Password')</script>");
            }
        }

    }
}