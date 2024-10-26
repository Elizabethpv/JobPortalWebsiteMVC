using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalWebsiteMVC.Models;

namespace JobPortalWebsiteMVC.Controllers
{
    public class ExperienceController : Controller
    {
        JobportalEntities dbobj = new JobportalEntities();
        // GET: Experience
        public ActionResult Experienceload()
        {
            return View();
        }
        public ActionResult Experience_click(Experiencecls exobj)
        {
            if(ModelState.IsValid)
            {
                int userid = Convert.ToInt32(Session["uid"]);

                dbobj.SP_Experience(userid, exobj.Jobtittle, exobj.Company_Name, exobj.Job_location,
                    exobj.Role, exobj.Sart_Date, exobj.end_Date, exobj.Current_status, exobj.Skills, exobj.Description);
                return RedirectToAction("Accountpageload", "UserAccount");
            }
            else
            {
                return View("Experienceload", exobj);
            }
            
        }
    }
}