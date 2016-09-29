using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Test
    {
        public string majorPairName
        {
            get;
            set;
        }
        public string minorPairName
        {
            get;
            set;
        }
    }
    public partial class TeacherArea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserID"] == null)
            {
                Response.Redirect("Main.aspx");
            }
            if(!IsPostBack)
            {
                GridView1.DataSource = GetDataToBind();
                GridView1.DataBind();
            }
            TestInfoDataContext db = new TestInfoDataContext(GlobalVariables.DbPath);
            if (HttpContext.Current.Session["isTeacher"] == null || (bool)HttpContext.Current.Session["isTeacher"]==false)
            {
                LinkButton1.Visible = false;
                LinkButton2.Visible = false;
                UserReg.Visible = false;
                
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pair addage.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Test Creation.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string test = GridView1.SelectedRow.Cells[1].Text;
            Response.Redirect("WebForm1.aspx?TestID=" + GridView1.SelectedRow.Cells[1].Text);
        }
        private List<Test> GetDataToBind()
        {
            TestInfoDataContext db = new TestInfoDataContext();

            List<Test> lstLecturers = db.Tests.OrderBy(x => x.Id).ToList();
            foreach (Test lecturer in lstLecturers)
            {                
                
                lecturer.majorPairName = lecturer.Pair.pairname;
                lecturer.minorPairName = lecturer.Pair1.pairname;
            }

            return lstLecturers;
        }

        protected void UserReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }
    }
}