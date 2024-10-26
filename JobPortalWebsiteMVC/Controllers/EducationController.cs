using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalWebsiteMVC.Models;

namespace JobPortalWebsiteMVC.Controllers
{
    public class EducationController : Controller
    {
        JobportalEntities dbobj = new JobportalEntities();
        // GET: Education
        public ActionResult educationload()
        {
            return View();
        }
        public ActionResult education_click(Educationcls edobj)
        {
            if(ModelState.IsValid)
            {
                int userid = Convert.ToInt32(Session["uid"]);
                dbobj.SP_Education(userid, edobj.Course_Name, edobj.Institute_university,
                    edobj.Department, edobj.Board, edobj.Start_Date, edobj.End_Date, edobj.percentage);
                return RedirectToAction("Accountpageload", "UserAccount");
            }
            else
            {
                return View("educationload", edobj);
            }
            
        }
    }
}