using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{

    public partial class ResultsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserID"] == null)
            {
                Response.Redirect("Main.aspx");
            }
            if (!IsPostBack)
            {
                //GridView1.DataSource = GetDataToBind();
                //GridView1.DataBind();

            }
            TestInfoDataContext db = new TestInfoDataContext(GlobalVariables.DbPath);


        }


        //private List<TestResult> GetDataToBind()
        //{
        //    TestInfoDataContext db = new TestInfoDataContext();

        //    List<TestResult> lstLecturers = db.TestResults.OrderBy(x => x.Id).ToList();


        //    return lstLecturers;
        //}

        protected void BackButton_Click(object sender, EventArgs e)
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