using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalWebsiteMVC.Models;

namespace JobPortalWebsiteMVC.Controllers
{
    public class CompanyRegController : Controller
    {
        JobportalEntities dbobj = new JobportalEntities();
        // GET: CompanyReg
        public ActionResult companyreg_pageload()
        {
            return View();
        }
        public ActionResult Companyreg_click(Companyregcls cmobj)
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
                dbobj.SP_CompanyRegistration(Regid, cmobj.company_Name, cmobj.company_Address,
                    cmobj.company_Email, cmobj.company_Number, cmobj.company_website);
                dbobj.SP_LoginRegistration(Regid, cmobj.username, cmobj.password, "admin");
                ViewBag.Message = "Insert Succussfully";
                ModelState.Clear();
                Companyregcls clear = new Companyregcls
                {
                    company_Name = string.Empty,
                    company_Address = string.Empty,
                    company_Email = string.Empty,
                    company_Number = 0L,
                    company_website = string.Empty,
                    username = string.Empty,
                    password = string.Empty
                };
                return View("companyreg_pageload", clear);           
            }
            else
            {
                ViewBag.Message = "Insertion is not Possible";
                return View("companyreg_pageload", cmobj);
            }
            
        }

    }
}