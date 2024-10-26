using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalWebsiteMVC.Models;

namespace JobPortalWebsiteMVC.Controllers
{
    public class UserRegController : Controller
    {
        JobportalEntities dbobj = new JobportalEntities();
        // GET: UserReg
        public ActionResult userreg_load()
        {
            return View();
        }
        public ActionResult userreg_click(Userregcls urobj,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var getmaxid = dbobj.SP_GetMaxRegid().FirstOrDefault();
                int max = Convert.ToInt32(getmaxid);
                int Regid = 0;
                if (max == 0)
                {
                    Regid = 1;
                }
                else
                {
                    Regid = max + 1;
                }
                if (file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    var filepath = Server.MapPath("~/UserProfilePic");
                    string pathconnection = Path.Combine(filepath, filename);
                    file.SaveAs(pathconnection);

                    var profilepic = Path.Combine("~/UserProfilePic", filename);
                    urobj.image = profilepic;
                }
                dbobj.SP_UserRegistration(Regid, urobj.Name, urobj.Address, urobj.Email,
                    urobj.Gender, urobj.DateOfBirth, urobj.PhoneNumber, urobj.image, "active");
                dbobj.SP_LoginRegistration(Regid, urobj.username, urobj.password, "user");
                ViewBag.Message = "Inserted Succussfully";
                ModelState.Clear();
                Userregcls clear = new Userregcls
                {
                    Name = string.Empty,
                    Address = string.Empty,
                    Email = string.Empty,
                    Gender = string.Empty,
                    DateOfBirth = DateTime.MinValue,
                    PhoneNumber = 0L, 
                };
                return View("userreg_load", clear);
            }
            else
            {
                ViewBag.Message = "Oops Insertion is not Possible";
               
                return View("userreg_load", urobj);
            }
        }
    }
}