using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Cluster_Creation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserID"] == null)
            {
                Response.Redirect("Main.aspx");
            }
            if (!IsPostBack)
            //check if the webpage is loaded for the first time. 
            {
                ViewState["PreviousPage"] =  Request.UrlReferrer;//Saves the Previous page url in ViewState 
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TestInfoDataContext db = new TestInfoDataContext(GlobalVariables.DbPath);
            bool validity = true;
            if ( majorPair.SelectedIndex == minorPair.SelectedIndex || nameTB.Text == String.Empty || desTB.Text == String.Empty)
                validity = false;
            if (validity == true)
            {
                var major = (from t in db.Pairs
                            where t.pairname == majorPair.SelectedItem.Value
                             orderby t.testId descending
                            select t.testId).Take(1);
                var minor = (from t in db.Pairs
                            where t.pairname == minorPair.SelectedItem.Value
                             orderby t.testId descending
                             select t.testId).Take(1);
                var testTable = db.GetTable<Test>();
                testTable.InsertOnSubmit(new Test
                {
                    Id = (db.Tests.Any()) ? db.Tests.Max(x => x.Id) + 1 : 11111,
                    testName = nameTB.Text.Trim(),
                    description = desTB.Text.Trim(),
                    majorPairId = major.FirstOrDefault(),
                    minorPairId = minor.FirstOrDefault()
                });
                db.SubmitChanges();
                if (ViewState["PreviousPage"] != null) //Check if the ViewState  
                //contains Previous page URL       
                {
                    Response.Redirect(ViewState["PreviousPage"].ToString());
                    //Redirect to
                    //Previous page by retrieving the PreviousPage Url from ViewState. 
                }
                Response.Redirect(Request.UrlReferrer.ToString());
            }
            else
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}