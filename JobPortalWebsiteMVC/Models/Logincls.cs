using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortalWebsiteMVC.Models
{
    public class Logincls
    {
        [Required(ErrorMessage ="Enter Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; }
        public string message { get; set; }
    }
}