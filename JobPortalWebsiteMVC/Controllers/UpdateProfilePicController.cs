using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalWebsiteMVC.Models;

namespace JobPortalWebsiteMVC.Controllers
{
    public class UpdateProfilePicController : Controller
    {
        JobportalEntities dbobj = new JobportalEntities();
        // GET: UpdateProfilePic
        public ActionResult profilepic_Load(int id)
        {
            var getdata = dbobj.SP_UserDataID(id).FirstOrDefault();

            return View(new Userregcls
            {
                image = getdata.image,
            }
            );
        }
        public ActionResult profilepic_Click(HttpPostedFileBase file, Userregcls uobj)
        {
            if (file.ContentLength > 0)
            {
                string filename = Path.GetFileName(file.FileName);
                var filepath = Server.MapPath("~/UserProfilePic");
                string pathconnection = Path.Combine(filepath, filename);
                file.SaveAs(pathconnection);

                var profilepic = Path.Combine("~/UserProfilePic", filename);
                uobj.image = profilepic;
            }
            int user_id = Convert.ToInt32(Session["uid"]);

            dbobj.SP_UpdateUSerRegProfilepic(user_id,uobj.image);

            var getdata = dbobj.SP_UserDataID(user_id).FirstOrDefault();

            return View("profilepic_Load", new Userregcls
            {
                image = getdata.image,
            }
            );
        }
    }
}