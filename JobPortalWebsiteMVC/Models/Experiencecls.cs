using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortalWebsiteMVC.Models
{
    public class Experiencecls
    {
        public int Exp_id { get; set; }
        public int user_id { get; set; }
        [Required(ErrorMessage = "Enter the JobTittle")]
        public string Jobtittle { get; set; }
        [Required(ErrorMessage = "Enter the Company Name")]
        public string Company_Name { get; set; }
        [Required(ErrorMessage = "Enter the Location")]
        public string Job_location { get; set; }
        [Required(ErrorMessage = "Enter the Role")]
        public string Role { get; set; }
        [Required(ErrorMessage = "Select Start Date")]
        public System.DateTime Sart_Date { get; set; }
        [Required(ErrorMessage = "Select End Date")]
        public System.DateTime end_Date { get; set; }
        [Required(ErrorMessage = "Enter the PositionName")]
        public string Current_status { get; set; }
        [Required(ErrorMessage = "Enter the Skill")]
        public string Skills { get; set; }
        [Required(ErrorMessage = "Enter the Description")]
        public string Description { get; set; }
    }
}