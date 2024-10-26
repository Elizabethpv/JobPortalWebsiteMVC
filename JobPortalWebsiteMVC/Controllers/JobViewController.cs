using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalWebsiteMVC.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace JobPortalWebsiteMVC.Controllers
{
    public class JobViewController : Controller
    {
        JobportalEntities dbobj = new JobportalEntities();
        // GET: JobView
        public ActionResult jobview_pageload()
        {
            return View(GetJobList());
        }
        private Jobsearch GetJobList()
        {
            var joblists = new Jobsearch();
            List<string> lst = new List<string>();
            var job = dbobj.JP_JobpostTB.ToList();
            foreach(var j in job)
            {
                var jobobj = new jobList();

                jobobj.Job_id = j.Job_id;
                jobobj.Company_id = j.Company_id;
                jobobj.Job_Tittle = j.Job_Tittle;
                jobobj.Job_description = j.Job_description;
                jobobj.jobtype_name = j.Job_Type;
                jobobj.Job_Experience = j.Job_Experience;
                jobobj.Job_Skills = j.Job_Skills;
                jobobj.Job_Salary = j.Job_Salary;
                jobobj.Job_enddate = j.Job_enddate;
                jobobj.Job_Location = j.Job_Location;

                joblists.selectjob.Add(jobobj);
            }
            return joblists;
        }
        public ActionResult searchjob_click(Jobsearch clsobj)
        {
            string qry = "";
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.Job_Experience))
            {
                qry += " and Job_Experience like '%" + clsobj.insertse.Job_Experience+ "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.Job_Skills))
            {
                qry += " and Job_Skills like '%" + clsobj.insertse.Job_Skills + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.Job_Location))
            {
                qry += " and Job_Location like '%" + clsobj.insertse.Job_Location + "%'";
            }
            return View("jobview_pageload", getdata(clsobj, qry));
            
        }

        private Jobsearch getdata(Jobsearch clsobj, string qry)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["importdataconnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_Jobsearches", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new Jobsearch();
                while (dr.Read())
                {
                    var jobcls = new jobList();
                    jobcls.Job_id = Convert.ToInt32(dr["Job_id"].ToString());
                    jobcls.Company_id=Convert.ToInt32(dr["Company_id"].ToString());
                    jobcls.Job_Tittle = dr["Job_Tittle"].ToString();
                    jobcls.Job_description = dr["Job_description"].ToString();
                    jobcls.jobtype_name = dr["Job_Type"].ToString();
                    jobcls.Job_Experience = dr["Job_Experience"].ToString();
                    jobcls.Job_Skills = dr["Job_Skills"].ToString();
                    jobcls.Job_Salary = dr["Job_Salary"].ToString();
                    jobcls.Job_enddate =Convert.ToDateTime(dr["Job_enddate"].ToString());
                    jobcls.Job_Location = dr["Job_Location"].ToString();

                    joblist.selectjob.Add(jobcls);
                }
                con.Close();
                return joblist;
            }
        }

    }
}