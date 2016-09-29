using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;
namespace WebApplication
{
    public partial class Pair_addage : System.Web.UI.Page
    {
        // DataContext takes a connection string. 
        TestInfoDataContext db;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserID"] == null)
            {
                Response.Redirect("Main.aspx");
            }
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
            Pair p = new Pair
            {

                pairname = TextBox1.Text.Trim() + "-" + TextBox2.Text.Trim(),
                
                testId= (db.Pairs.Any()) ?db.Pairs.Max(x=>x.testId)+1 : 0
                
            };
            db.Pairs.InsertOnSubmit(p);
            db.SubmitChanges();

            int id = p.testId;
            List<string> Tags00 = TextBox3.Text.Trim().Split(',').ToList();
            List<string> Tags01 = TextBox4.Text.Trim().Split(',').ToList();
            var wordTable = db.GetTable<Word>();

            for (int i = 0; i < Tags00.Count; i++)
            {

                wordTable.InsertOnSubmit(new Word
                {
                    testId = id,
                    words = Tags00[i].Trim(),
                    isImg = false,
                    groups = false
                });


            }
            for (int i = 0; i < Tags01.Count; i++)
            {
                wordTable.InsertOnSubmit(new Word
                {
                    testId = id,
                    words = Tags01[i].Trim(),
                    isImg = false,
                    groups = true
                });


            }

            db.SubmitChanges();
            TextBox1.Text = null;
            TextBox2.Text = null;
            TextBox3.Text = null;
            TextBox4.Text = null;
            //reload the page and save the last page
            StringBuilder sbScript = new StringBuilder();

            sbScript.Append("<script language='JavaScript' type='text/javascript'>\n");
            sbScript.Append("<!--\n");
            sbScript.Append(this.GetPostBackEventReference(this, "PBArg") + ";\n");
            sbScript.Append("// -->\n");
            sbScript.Append("</script>\n");

            this.RegisterStartupScript("AutoPostBackScript", sbScript.ToString());

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