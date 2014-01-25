using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeListen.Web.Models
{
    public class WebUser
    {
        public int UserId { get; set; }

        [DisplayName("User Name*")]
        [Required]
        public string UserName { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Email*")]
        [Required]
        public string Email { get; set; }

        [DisplayName("Password*")]
        [Required]
        public string Password { get; set; }

    }
}