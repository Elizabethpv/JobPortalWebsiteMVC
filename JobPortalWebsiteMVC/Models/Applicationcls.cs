using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortalWebsiteMVC.Models
{
    public class Applicationcls
    {
        public int User_id { get; set; }
        public int Company_id { get; set; }
        public int Job_Id { get; set; }
        public string Resume { get; set; }
        public System.DateTime App_Date { get; set; }
        public string App_Status { get; set; }
        public Applicationcls()
        {
            selectjobdetails = new List<jobdetails>();        
        }
        public List<jobdetails> selectjobdetails { set; get; }
    }
    public class jobdetails
    {
        public int Company_idFK { get; set; }

        public string Job_Tittle { get; set; }

        public string Job_description { get; set; }

        public string Job_Experience { get; set; }

        public string Job_Skills { get; set; }

        public string Job_Salary { get; set; }
        public System.DateTime Job_enddate { get; set; }
        public string Job_Location { get; set; }
        public string Job_Status { get; set; }
        public int jobype_Id { get; set; }
        public string jobtype_name { get; set; }
    }
}