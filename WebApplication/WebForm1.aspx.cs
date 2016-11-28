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
using System.Data.Sql;
using System.Data.SqlClient;

namespace WebApplication
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        IATest.IATest demotest;
        public string data;
        string connectionstring = GlobalVariables.DbPath;
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
                DualList input1 = new DualList(new Lister(Titles[0], left.Select(a => a.words).ToList(), left.Select(a => a.isImg).ToList()), new Lister(Titles[1], right.Select(a => a.words).ToList(), right.Select(a => a.isImg).ToList()));

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

        [WebMethod]
        public static void Done(string[] ftms, string[] stms, string[] ftts, string[] stts)
        {
            string connectionstring = GlobalVariables.DbPath;
            String[] ftM = ftms;
            String[] stM = stms;
            String[] ftT = ftts;
            String[] stT = stts;
            TestInfoDataContext db = new TestInfoDataContext(GlobalVariables.DbPath);



            if (!db.DatabaseExists())
            {
                db.CreateDatabase();
            }
            TestResult tes = new TestResult
            {
                Id = (db.TestResults.Any()) ? db.TestResults.Max(x => x.Id) + 1 : 0,
                user_id = Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString()),
                test_Id = Convert.ToInt32(HttpContext.Current.Session["TestID"].ToString()),
                MistakesA = string.Join(",", ftM),
                MistakesB = string.Join(",", stM),
                TimesA = string.Join(",", ftT),
                TimesB = string.Join(",", stT)

            };
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            db.TestResults.InsertOnSubmit(tes);
            db.SubmitChanges();


            // Do whatever processing you want
            // However, you cannot access server controls
            // in a static web method.
        }



    }
}

