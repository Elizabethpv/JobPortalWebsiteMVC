using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using JobPortalWebsiteMVC.Models;

namespace JobPortalWebsiteMVC.Controllers
{
    public class CompanyAccountController : Controller
    {
        JobportalEntities dbobj = new JobportalEntities();
        string connectionString = ConfigurationManager.ConnectionStrings["importdataconnection"].ConnectionString;
        // GET: CompanyAccount
        public ActionResult CompanyAccount_pageload()
        {
            var getjobs = PostedJobviewComIDView();
            return View(getjobs);
           
        }

        public ActionResult CompanyAccount_Deleteclick(int jobid)
        {
            dbobj.SP_DeletePostedJobWIthComID(jobid);
            return RedirectToAction("CompanyAccount_pageload");
        }
        public List<CompanyPostedjobView> PostedJobviewComIDView()
        {
            List<CompanyPostedjobView> getdata = new List<CompanyPostedjobView>();
            int comid = Convert.ToInt32(Session["uid"]); 
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_GetPostedJobWithComID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompanyId", comid);
                    con.Open();
                    SqlDataReader da = cmd.ExecuteReader();
                    while (da.Read())
                    {
                        var job = new CompanyPostedjobView
                        {
                            job_id = Convert.ToInt32(da["Job_id"]),
                            Job_Tittle = da["Job_Tittle"].ToString(),
                            Job_description = da["Job_description"].ToString(),
                            Job_Experience = da["Job_Experience"].ToString(),
                            Job_Skills = da["Job_Skills"].ToString(),
                            Job_Salary = da["Job_Salary"].ToString(),
                            Job_enddate = Convert.ToDateTime(da["Job_enddate"]),
                            Job_Location = da["Job_Location"].ToString(),
                            //jobtype_name = da["jobtype_name"].ToString()
                        };                      
                        getdata.Add(job);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {                   
                    throw new Exception("Error retrieving posted jobs", ex);
                }
            }
            return getdata;
        }


    }
}