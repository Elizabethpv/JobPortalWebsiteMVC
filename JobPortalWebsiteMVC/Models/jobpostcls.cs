using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortalWebsiteMVC.Models
{
    public class jobpostcls
    {
        public int Company_id { get; set; }
        [Required(ErrorMessage = "Enter Jobtittle")]
        public string Job_Tittle { get; set; }
        [Required(ErrorMessage = "Enter Description")]
        public string Job_description { get; set; }
        //public string Job_Type { get; set; }
        [Required(ErrorMessage = "Enter Experience")]
        public string Job_Experience { get; set; }
        [Required(ErrorMessage = "Enter Skills")]
        public string Job_Skills { get; set; }
        [Required(ErrorMessage = "Enter Salary")]
        public string Job_Salary { get; set; }
        public System.DateTime Job_enddate { get; set; }
        public string Job_Location { get; set; }
        public string Job_Status { get; set; }
        public int jobype_Id { get; set; }
        public string jobtype_name { get; set; }

    }
    public class jobtype
    {
        public int jobype_Id { get; set; }
        public string jobtype_name { get; set; }
    }
}