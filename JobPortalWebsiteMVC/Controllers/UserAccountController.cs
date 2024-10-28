using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalWebsiteMVC.Models;
using System.Data;
using System.Data.SqlClient;

namespace JobPortalWebsiteMVC.Controllers
{
    public class UserAccountController : Controller
    {
        JobportalEntities dbobj = new JobportalEntities();
        string connectionString = ConfigurationManager.ConnectionStrings["importdataconnection"].ConnectionString;
        // GET: UserAccount
        public ActionResult Accountpageload()
        {
            int userid = Convert.ToInt32(Session["uid"]);
            var multipleTableData = new MultipleTableData
            {
                educationss=EducationDetailsView(userid),
                experienceee=ExperienceDetailsView(userid),
                resumeees=ResumeDetailsView(userid),
                userdetailss=UserDetailsView(userid)
            };
            return View(multipleTableData);          
        }

        public ActionResult Account_click()
        {
            return View();
        }
        public IEnumerable<Educationcls> EducationDetailsView(int id)
        {
            List<Educationcls> getdata = new List<Educationcls>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_EducationDataID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid ", id);
                    con.Open();
                    SqlDataReader da = cmd.ExecuteReader();
                    while (da.Read())
                    {
                        var box=new Educationcls
                        {
                            Education_Id= Convert.ToInt32(da["Education_Id"]),
                            Course_Name = da["Course_Name"].ToString(),
                            Institute_university = da["Institute_university"].ToString(),
                            Department = da["Department"].ToString(),
                            Board = da["Board"].ToString(),
                            Start_Date = Convert.ToDateTime(da["Start_Date"].ToString()),
                            End_Date = Convert.ToDateTime(da["End_Date"].ToString()),
                            percentage = Convert.ToInt32(da["percentage"])
                        };
                        getdata.Add(box);
                    }
                    con.Close();
                    return getdata;
                }
                catch (Exception ex)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    throw;
                }
            }
        }
        public IEnumerable<Experiencecls> ExperienceDetailsView(int id)
        {
            List<Experiencecls> getdata = new List<Experiencecls>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_ExperienceDataID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid ", id);
                    con.Open();
                    SqlDataReader da = cmd.ExecuteReader();
                    while (da.Read())
                    {
                        var box = new Experiencecls
                        {
                            Exp_id=Convert.ToInt32(da["Exp_id"]),
                            Jobtittle = da["Jobtittle"].ToString(),
                            Company_Name = da["Company_Name"].ToString(),
                            Job_location = da["Job_location"].ToString(),
                            Role = da["Role"].ToString(),
                            Sart_Date = Convert.ToDateTime(da["Sart_Date"].ToString()),
                            end_Date = Convert.ToDateTime(da["end_Date"].ToString()),
                            Current_status = da["Current_status"].ToString(),
                            Skills = da["Skills"].ToString(),
                            Description = da["Description"].ToString()
                        };
                        getdata.Add(box);
                    }
                    con.Close();
                    return getdata;
                }
                catch (Exception ex)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    throw;
                }
            }
        }

        public IEnumerable<Resumecls> ResumeDetailsView(int id)
        {
            List<Resumecls> getdata = new List<Resumecls>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_ResumeDataID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid ", id);
                    con.Open();
                    SqlDataReader da = cmd.ExecuteReader();
                    while (da.Read())
                    {
                        var box = new Resumecls
                        {
                            Resume_Id = Convert.ToInt32(da["Resume_Id"]),
                            Resume = da["Resume"].ToString(),
                           
                        };
                        getdata.Add(box);
                    }
                    con.Close();
                    return getdata;
                }
                catch (Exception ex)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    throw;
                }
            }
        }
        public IEnumerable<Userregcls> UserDetailsView(int id)
        {
            List<Userregcls> getdata = new List<Userregcls>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_UserDataID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid ", id);
                    con.Open();
                    SqlDataReader da = cmd.ExecuteReader();
                    while (da.Read())
                    {
                        var box = new Userregcls
                        {
                            User_Id=Convert.ToInt32(da["User_Id"]),
                            Name = da["Name"].ToString(),
                            Address = da["Address"].ToString(),
                            Email = da["Email"].ToString(),
                            Gender = da["Gender"].ToString(),
                            DateOfBirth = Convert.ToDateTime(da["DateOfBirth"].ToString()).Date,
                            PhoneNumber = Convert.ToInt64(da["PhoneNumber"]),
                            image = da["image"].ToString()
                        };
                        getdata.Add(box);
                    }
                    con.Close();
                    return getdata;
                }
                catch (Exception ex)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    throw;
                }
            }
        }


        public ActionResult DeleteEducation(int id,MultipleTableData mobj)
        {
            mobj.record_id = id;
            dbobj.SP_DeleteEducationWithID(mobj.record_id);
            return RedirectToAction("Accountpageload");          
        }
        public ActionResult DeleteResume(int id, MultipleTableData mobj)
        {
            mobj.record_id = id;
            dbobj.SP_DeleteResumeWithID(mobj.record_id);
            return RedirectToAction("Accountpageload");
        }
        public ActionResult DeleteExperience(int id, MultipleTableData mobj)
        {
            mobj.record_id = id;
            dbobj.SP_DeleteExperienceWithID(mobj.record_id);
            return RedirectToAction("Accountpageload");
        }


        public ActionResult ViewPdf(string resumeFileName)
        {
            string filePath = Server.MapPath(resumeFileName);
            if (filePath != null)
            {              
                return File(filePath, "application/pdf");
            }
            else
            {
                ViewBag.Message = "Please upload Your CV";
            }
            return File(filePath, "application/pdf");
        }














    }
}