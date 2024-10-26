using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalWebsiteMVC.Models;

namespace JobPortalWebsiteMVC.Controllers
{
    public class ResumeController : Controller
    {
        JobportalEntities dbobj = new JobportalEntities();
        // GET: Resume
        public ActionResult ResumeLoad()
        {
            return View();
        }
        public ActionResult Resume_click(HttpPostedFileBase file,Resumecls robj)
        {
            string filename = Path.GetFileName(file.FileName);
            var s = Server.MapPath("~/UserResume");
            string connectionnpath = Path.Combine(s, filename);
            file.SaveAs(connectionnpath);

             var resumepath = Path.Combine("~/UserResume", filename);
            robj.Resume = resumepath;

            int userid = Convert.ToInt32(Session["uid"]);
            dbobj.SP_PostResume(userid, robj.Resume);
            
            return RedirectToAction("Accountpageload", "UserAccount");
        }
    }
}