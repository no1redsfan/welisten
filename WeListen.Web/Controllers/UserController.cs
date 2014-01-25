using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeListen.Data;
using WeListen.Web.Infrastructure.Session;

namespace WeListen.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly Service _dataService;
        //
        // GET: /User/

        public UserController()
        {
            _dataService = new Service();
        }


        public ActionResult Index()
        {
            return View();
        }

    }
}
