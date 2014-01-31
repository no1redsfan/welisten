using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeListen.Data;
using WeListen.Web.Infrastructure.Session;
using WeListen.Web.Models;
using WeListen.Web.Viewmodels.Locations;

namespace WeListen.Web.Controllers
{
    public class LocationController : BaseController
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
            WebUser webUser = ViewBag.User as WebUser;
            
            ViewBag.Location = _dataService.GetLocationWithId(locationId).Name;
            ViewBag.LocationId = locationId;
            if (webUser != null)
            {
                var model = new Songs
                {
                    Song = _dataService.GetSongsByLocation(locationId),
                    Role = _dataService.GetUserRoleIdByUserId(webUser.UserId),
                };
                return View(model);
            }
            else
            {
                var model = new Songs
                {
                    Song = _dataService.GetSongsByLocation(locationId)
                };
                return View(model);
            }
        }


        /// <summary>
        /// Home page for a location. 
        /// </summary>
        /// <param name="locationId">The location identifier.</param>
        /// <returns>Playqueue and available songs. View.</returns>
        public ActionResult Home(int locationId)
        {
            ViewBag.Location = _dataService.GetLocationWithId(locationId).Name;
            ViewBag.LocationId = locationId;
            var model = new LocationHomeViewModel
            {
                Song = _dataService.GetSongsByLocation(locationId),
                PlaylistQueue = _dataService.GetPlaylistByLocation(locationId),
                Djs = _dataService.GetLocationDjs(locationId)
            };
            return View(model);
        }


        public bool SubmitDj(int locationId, string djname)
        {
            var result = _dataService.GetUserByUsername(djname);
            if (result == null) return false;
            _dataService.SaveLocationDj(locationId, result.UserId);
            return true;
        }


        public ActionResult Edit(int locationId)
        {
            var model = _dataService.GetLocationWithId(locationId);
            return View(model);
        }
    }
}
