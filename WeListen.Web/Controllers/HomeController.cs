using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeListen.Data;
using WeListen.Web.Infrastructure.Session;

namespace WeListen.Web.Controllers
{
    /// <summary>
    /// The home controller for the application.
    /// </summary>
    public class HomeController : BaseController
    {
        private readonly Service _dataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController" /> class.
        /// </summary>
        /// <param name="context">The storage context.</param>
        public HomeController()
        {
            _dataService = new Service();
        }
        
        public ActionResult Index()
        {
            ViewBag.Message = "WeListen";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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
    }
}
