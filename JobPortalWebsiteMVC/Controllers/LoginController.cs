using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalWebsiteMVC.Models;

namespace JobPortalWebsiteMVC.Controllers
{
    public class LoginController : Controller
    {
        JobportalEntities dbobj = new JobportalEntities();
        // GET: Login
        public ActionResult Login_Pageload()
        {
            return View();
        }
        public ActionResult Login_click(Logincls lgobj)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                dbobj.SP_GetLoginIDCount(lgobj.Username, lgobj.Password, op);
                int value = Convert.ToInt32(op.Value);
                if (value == 1)
                {
                    var id = dbobj.SP_GetLoginpesonID(lgobj.Username, lgobj.Password).FirstOrDefault();
                    Session["uid"] = id;
                    var type = dbobj.SP_GetLoginpersonType(lgobj.Username, lgobj.Password).FirstOrDefault();
                    Session["logintype"] = type;
                    if (type == "admin")
                    {
                        return RedirectToAction("Company_homepage");
                    }
                    else if(type == "user")
                    {
                        return RedirectToAction("jobview_pageload", "JobView");
                    }
                    
                }
                else
                {
                    ViewBag.Message = "Invalid username and password";
                }
                return View("Login_Pageload", lgobj);
            }
            else
            {
                ModelState.Clear();
                return View("Login_Pageload", lgobj);
            }
        }
        public ActionResult Company_homepage()
        {
            return View();
        }
        public ActionResult user_homepage()
        {
            return View();
        }
    }
}