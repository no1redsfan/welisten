using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeListen.Data;
using WeListen.Web.Infrastructure.Session;
using WeListen.Web.Viewmodels.Locations;
using WeListen.Web.Viewmodels.User;

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

        /// <summary>
        /// Releases unmanaged resources and optionally releases managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dataService.Dispose();
            }

            base.Dispose(disposing);
        }


        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>User index view model with the webuser and their locations/events</returns>
        public ActionResult Index()
        {
            if (Context.WebUser != null)
            {
                var model = new UserIndexViewModel
                {
                    WebUser = Context.WebUser,
                    Locations = _dataService.GetLocationsForUser(Context.WebUser.UserId)
                    
                };
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
