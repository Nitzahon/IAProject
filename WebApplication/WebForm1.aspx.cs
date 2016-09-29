using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Diagnostics;
using System.Web.Script.Serialization;
using IATest;

namespace WebApplication
{

    public partial class WebForm1 : System.Web.UI.Page
    { 
       IATest.IATest demotest;
       public string data; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserID"] == null)
            {
                Response.Redirect("Main.aspx");
            }
            ClientScript.GetPostBackEventReference(this, string.Empty);
            if (!IsPostBack)
            {
                TestInfoDataContext db = new TestInfoDataContext(GlobalVariables.DbPath);
                int id = Convert.ToInt32(Request.QueryString["TestID"]);
                var query = (from t in db.Tests
                             where t.Id == id
                             from w in db.Pairs
                             where (w.testId == t.majorPairId)
                             select new
                             {
                                 w.testId,
                                 w.pairname
                             }).Take(1);

                List<string> Titles = query.FirstOrDefault().pairname.Split('-').ToList(); 
                //ExtenMethods.Populate<bool>(b1, false);
                //ExtenMethods.Populate<bool>(b2, false);
                //b1[0] = true;
                //b1[1] = true;

                var left = from w in db.Words
                           where ((w.testId == query.FirstOrDefault().testId) && (w.groups == false))
                           select new
                           {
                               w.words,
                               w.isImg
                           };

                var right = from w in db.Words
                           where ((w.testId == query.FirstOrDefault().testId) && (w.groups == true))
                           select new
                           {
                               w.words,
                               w.isImg
                           };
                DualList input1 = new DualList(new Lister(Titles[0], left.Select(a => a.words).ToList(), left.Select(a => a.isImg).ToList()),new Lister(Titles[1], right.Select(a => a.words).ToList(), right.Select(a => a.isImg).ToList()));
                
                query = (from t in db.Tests
                             where t.Id == id
                             from w in db.Pairs
                             where (w.testId == t.minorPairId)
                             select new
                             {
                                 w.testId,
                                 w.pairname
                             }).Take(1);

                Titles = query.FirstOrDefault().pairname.Split('-').ToList();


                left = from w in db.Words
                           where ((w.testId == query.FirstOrDefault().testId) && (w.groups == false))
                           select new
                           {
                               w.words,
                               w.isImg
                           };

                right = from w in db.Words
                            where ((w.testId == query.FirstOrDefault().testId) && (w.groups == true))
                            select new
                            {
                                w.words,
                                w.isImg
                            };
                DualList input2 = new DualList(new Lister(Titles[0], left.Select(a => a.words).ToList(), left.Select(a => a.isImg).ToList()), new Lister(Titles[1], right.Select(a => a.words).ToList(), right.Select(a => a.isImg).ToList()));
                demotest = new IATest.IATest(input1, input2, 20);
                
                data = new JavaScriptSerializer().Serialize(demotest);
                Console.WriteLine(data);

            }

            
        }

        
        
        

    }

}
