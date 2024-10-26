using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalWebsiteMVC.Models;

namespace JobPortalWebsiteMVC.Controllers
{
    public class JobpostHomeController : Controller
    {
        JobportalEntities dbobj = new JobportalEntities();
        public ActionResult Jobpost_Pageload()
        {
            List<jobtype> jtype = new List<jobtype>()
            {
                new jobtype {jobype_Id=1,jobtype_name="Full-Time"},
                new jobtype {jobype_Id=2,jobtype_name="Part-Time"},
                new jobtype {jobype_Id=3,jobtype_name="Contract"},
                new jobtype {jobype_Id=4,jobtype_name="Internship"}
            };
            ViewBag.selectjobtype = new SelectList(jtype, "jobype_Id", "jobtype_name");
            return View();
        }
        public ActionResult jobpost_click(jobpostcls jobj,int selectedjobtype,FormCollection form)
        {
            if (ModelState.IsValid)
            {
                List<jobtype> jtype = new List<jobtype>()
                {
                new jobtype {jobype_Id=1,jobtype_name="Full-Time"},
                new jobtype {jobype_Id=2,jobtype_name="Part-Time"},
                new jobtype {jobype_Id=3,jobtype_name="Contract"},
                new jobtype {jobype_Id=4,jobtype_name="Internship"}
                };         
                var selectjobtype = jtype.FirstOrDefault(m => m.jobype_Id == selectedjobtype);
                jobj.jobype_Id = selectjobtype.jobype_Id;
                jobj.jobtype_name = selectjobtype.jobtype_name;
                ViewBag.selectjobtype = new SelectList(jtype, "jobype_Id", "jobtype_name");
                int companyid = Convert.ToInt32(Session["uid"]);
                dbobj.SP_CompanyJobPst(companyid, jobj.Job_Tittle, jobj.Job_description,
                    jobj.jobtype_name, jobj.Job_Experience, jobj.Job_Skills, jobj.Job_Salary,
                    jobj.Job_enddate,jobj.Job_Location, "active");
                ViewBag.Message = "Inserted Succussfully";
                jobpostcls clear = new jobpostcls
                {
                    Job_Tittle = string.Empty,
                    Job_description = string.Empty,
                    jobtype_name = string.Empty,
                    Job_Experience = string.Empty,
                    Job_Skills = string.Empty,
                    Job_Salary = string.Empty,
                    Job_Location = string.Empty,
                };
                return View("Jobpost_Pageload", clear);
            }
            else
            {
                List<jobtype> jtype = new List<jobtype>()
                {
                    new jobtype {jobype_Id=1,jobtype_name="Full-Time"},
                    new jobtype {jobype_Id=2,jobtype_name="Part-Time"},
                    new jobtype {jobype_Id=3,jobtype_name="Contract"},
                    new jobtype {jobype_Id=4,jobtype_name="Internship"}
                };
                ViewBag.selectjobtype = new SelectList(jtype, "jobype_Id", "jobtype_name");
                ViewBag.Message = "Insertion is not possible";
                return View("Jobpost_Pageload", jobj);
            }
        }
    }
}