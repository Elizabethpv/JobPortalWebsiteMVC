using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalWebsiteMVC.Models;

namespace JobPortalWebsiteMVC.Controllers
{
    public class EditUserRegController : Controller
    {
        JobportalEntities dbobj = new JobportalEntities();
        // GET: EditUserReg
        public ActionResult EditUserReg_load(int id)
        { 
            var getdata = dbobj.SP_UserDataID(id).FirstOrDefault();

            return View(new Userregcls
            {
               Name = getdata.Name,
               Address = getdata.Address,
               Email = getdata.Email,
               PhoneNumber = getdata.PhoneNumber
            }
            );
            
        }

        public ActionResult EditUserReg_Click(HttpPostedFileBase file,Userregcls uobj)
        {
            int user_id = Convert.ToInt32(Session["uid"]);
           
            dbobj.SP_UpdateUSerRegData(user_id, uobj.Name, uobj.Address, uobj.Email, uobj.PhoneNumber);

            var getdata = dbobj.SP_UserDataID(user_id).FirstOrDefault();

            return View("EditUserReg_load", new Userregcls
            {
                Name = getdata.Name,
                Address = getdata.Address,
                Email = getdata.Email,
                PhoneNumber = getdata.PhoneNumber
               
            }
            );
           
        }
    }
}