using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace JobPortalWebsiteMVC.Models
{
    public class SQLDataAccessDB
    {
        string connectionString = ConfigurationManager.ConnectionStrings["importdataconnection"].ConnectionString;
        SqlConnection con;
        public SQLDataAccessDB()
        {
            con = new SqlConnection(connectionString);
        }
        public List<Educationcls> EducationDetailsView(int id)
        {
            List<Educationcls> getdata = new List<Educationcls>();
            //var getdata = new Educationcls();
            try
            {

                SqlCommand cmd = new SqlCommand("SP_EducationDataID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid ",id);
                con.Open();
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    //getdata = new Educationcls
                    getdata.Add(new Educationcls
                    {

                        Course_Name = da["Course_Name"].ToString(),
                        Institute_university = da["Institute_university"].ToString(),
                        Department = da["Department"].ToString(),
                        Board = da["Board"].ToString(),
                        Start_Date = Convert.ToDateTime(da["Start_Date"].ToString()),
                        End_Date = Convert.ToDateTime(da["End_Date"].ToString()),
                        percentage = Convert.ToInt32(da["[percentage"])              
                    });                              
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
    
}