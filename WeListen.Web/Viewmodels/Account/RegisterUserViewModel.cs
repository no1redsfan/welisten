using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeListen.Data;
using WeListen.Web.Models;

namespace WeListen.Web.Viewmodels.Account
{
    public class RegisterUserViewModel
    {
        public IEnumerable<Role> Roles { get; set; }

        public WebUser WebUser { get; set; }
    }
}