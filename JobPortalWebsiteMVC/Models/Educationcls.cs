using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortalWebsiteMVC.Models
{
    public class Educationcls
    {
        public int Education_Id { get; set; }
        public int user_id { get; set; }
        [Required(ErrorMessage = "Enter the Name")]
        public string Course_Name { get; set; }
        [Required(ErrorMessage = "Enter the University")]
        public string Institute_university { get; set; }
        [Required(ErrorMessage = "Enter the Department")]
        public string Department { get; set; }
        [Required(ErrorMessage = "Enter the Board")]
        public string Board { get; set; }
        [Required(ErrorMessage = "Please Select Start Date")]
        public System.DateTime Start_Date { get; set; }
        [Required(ErrorMessage = "Please Select End Date")]
        public System.DateTime End_Date { get; set; }
        [Required(ErrorMessage = "Enter percentage")]
        public long percentage { get; set; }

        public List<Educationcls> educationinfo { get; set; }
    }
}