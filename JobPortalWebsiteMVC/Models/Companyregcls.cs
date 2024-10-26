using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortalWebsiteMVC.Models
{
    public class Companyregcls
    {
        [Required(ErrorMessage = "Enter Company Name")]
        public string company_Name { get; set; }
        [Required(ErrorMessage = "Enter Company Address")]
        public string company_Address { get; set; }
        [EmailAddress(ErrorMessage ="Enter valid email")]
        public string company_Email { get; set; }
        [Required(ErrorMessage = "Enter the Phone")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Enter valid number")]
        public long company_Number { get; set; }
        [Required(ErrorMessage = "Enter Company  WebsiteURL")]
        public string company_website { get; set; }
        [Required(ErrorMessage = "Enter UserName")]
        public string username { get; set; }

        public string password { get; set; }

        [Compare("password", ErrorMessage = "Password mismatch")]
        public string cpassword { get; set; }
    }
}