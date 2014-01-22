using System.Collections.Generic;
using System.Data.Entity;
using WeListen.Data;
using WeListen.Web.Models;


namespace WeListen.Web.Viewmodels.Account
{
    public class Register
    {
        public IEnumerable<Role> Roles { get; set; }

        public WebAccount Account { get; set; }
    }
}