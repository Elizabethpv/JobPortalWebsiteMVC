using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using JobPortalWebsiteMVC.Models;
using System.Configuration;
using System.IO;

namespace JobPortalWebsiteMVC.Controllers
{
    public class AddApplicationController : Controller
    {
        JobportalEntities dbobj = new JobportalEntities();
        // GET: AddApplication
        public ActionResult Apllication_load(int cid,int jid)
        {
            TempData["cid"] = cid;
            Session["Jid"] = jid;
            TempData["jid"] = jid;
            return View(getdata());
        }
        public ActionResult Application_click(HttpPostedFileBase file,Applicationcls clsobj)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/ApplicationResume");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);

                    var fullpath = Path.Combine("~/ApplicationResume", fname);
                    clsobj.Resume = fullpath;
                }

                DateTime currentDate = DateTime.Today;
                clsobj.App_Date = currentDate;
                clsobj.User_id = Convert.ToInt32(Session["uid"]);
                clsobj.Company_id = Convert.ToInt32(TempData["cid"]);
                int jobid = Convert.ToInt32(Session["Jid"]);
                dbobj.SP_PostApplication(clsobj.User_id, clsobj.Company_id, jobid, clsobj.Resume, clsobj.App_Date, "apply");
              
                return RedirectToAction("jobview_pageload", "JobView");
            }
            else
            {
                return View("Apllication_load",clsobj);
            }
        }
        private Applicationcls getdata()
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["importdataconnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetJobDatawithID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@jobid", TempData["jid"]);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new Applicationcls();
                while (dr.Read())
                {
                    var jobcls = new jobdetails();
                    jobcls.Company_idFK = Convert.ToInt32(dr["Company_id"].ToString());
                    jobcls.Job_Tittle = dr["Job_Tittle"].ToString();
                    jobcls.Job_description = dr["Job_description"].ToString();
                    jobcls.jobtype_name = dr["Job_Type"].ToString();
                    jobcls.Job_Experience = dr["Job_Experience"].ToString();
                    jobcls.Job_Skills = dr["Job_Skills"].ToString();
                    jobcls.Job_Salary = dr["Job_Salary"].ToString();
                    jobcls.Job_enddate = Convert.ToDateTime(dr["Job_enddate"].ToString());
                    jobcls.Job_Location = dr["Job_Location"].ToString();

                    joblist.selectjobdetails.Add(jobcls);
                }
                con.Close();
                return joblist;
            }
        }
    }
}