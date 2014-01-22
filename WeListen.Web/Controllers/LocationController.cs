using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeListen.Data;
using WeListen.Web.Viewmodels.Locations;

namespace WeListen.Web.Controllers
{
    public class LocationController : Controller
    {
        //
        // GET: /Location/

        private readonly Service _dataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SongsController"/> class.
        /// </summary>
        public LocationController()
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

        
        public ActionResult Index()
        {
            var model = new Index { Locations = _dataService.GetLocations() };
            return View(model);
        }


        /// <summary>
        /// All available songs at a location
        /// </summary>
        /// <param name="locationId">The location id.</param>
        /// <returns>View</returns>
        public ActionResult Songs(int locationId)
        {
            ViewBag.Location = _dataService.GetLocationNameWithId(locationId).Name;
            ViewBag.LocationId = locationId;
            var model = new Songs { Song = _dataService.GetSongsByLocation(locationId) };
            return View(model);
        }


        /// <summary>
        /// Home page for a location. 
        /// </summary>
        /// <param name="locationId">The location identifier.</param>
        /// <returns>Playqueue and available songs. View.</returns>
        public ActionResult Home(int locationId)
        {
            ViewBag.Location = _dataService.GetLocationNameWithId(locationId).Name;
            ViewBag.LocationId = locationId;
            var model = new LocationHomeViewModel
            {
                Song = _dataService.GetSongsByLocation(locationId),
                PlaylistQueue = _dataService.GetPlaylistByLocation(locationId)
            };
            return View(model);
        }

    }
}
