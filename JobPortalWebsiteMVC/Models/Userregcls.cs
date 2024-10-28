using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortalWebsiteMVC.Models
{
    public class Userregcls
    {
        public int User_Id { get; set; }
        [Required(ErrorMessage ="Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }
        [EmailAddress(ErrorMessage = "Enter valid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Select Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please Select DOB")]
        public System.DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Enter the Phone")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Enter valid number")]
        public long PhoneNumber { get; set; }
        
        public string image { get; set; }
        [Required(ErrorMessage = "Enter UserName")]
        public string username { get; set; }

        public string password { get; set; }

        [Compare("password", ErrorMessage = "Password mismatch")]
        public string cpassword { get; set; }
        public string Status { get; set; }
    }
}