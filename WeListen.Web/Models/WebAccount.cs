using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WeListen.Web.Models
{
    public class WebAccount
    {
        public int UserId { get; set; }
        [DisplayName("User Name*")]
        public string UserName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Zipcode { get; set; }

        [DisplayName("Dj Password")]
        public string DjPassword { get; set; }
    }
}