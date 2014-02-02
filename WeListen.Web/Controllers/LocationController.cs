using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeListen.Data;
using WeListen.Web.Helpers;
using WeListen.Web.Infrastructure.Session;
using WeListen.Web.Models;
using WeListen.Web.Viewmodels.Locations;
using WeListen.Web.Viewmodels.Songs;
using Index = WeListen.Web.Viewmodels.Locations.Index;

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


        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult Index()
        {
            Index model = new Index { Locations = _dataService.GetLocations() };
            return View(model);
        }


        
        /*public ActionResult Index(int locationId) // cant name it index for some reason
        {

            Location currentLocation = _dataService.GetLocationWithId(locationId);
            //is there a webuser or not
            if (Context.WebUser != null)
            {
                Context.WebLocation = currentLocation.ToWebLocation(Context.WebUser.UserId);
                RedirectToAction("Home", "Location");
            }
            else
            {
                Context.WebLocation = currentLocation.ToWebLocation(1);
                RedirectToAction("Home", "Location");
            }

            return RedirectToAction("Index");

        }*/
        
        private bool SetWebLocation(int locationId) // cant name it index for some reason
        {
           
                Location currentLocation = _dataService.GetLocationWithId(locationId);
                //is there a webuser or not
                if (Context.WebUser != null)
                {
                    Context.WebLocation = currentLocation.ToWebLocation(Context.WebUser.UserId);
                }
                else
                {
                    Context.WebLocation = currentLocation.ToWebLocation(1); 
                }

            return true;

        }

        /// <summary>
        /// All available songs at a location
        /// </summary>
        /// <param name="locationId">The location id.</param>
        /// <returns>View</returns>
        public ActionResult Songs()
        {
            var locationId = Context.WebLocation.LocationId;
            
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
        /// <returns>Playqueue and available songs. View.</returns>
        public ActionResult Home(int locationId)
        {
            SetWebLocation(locationId);
            //var locationId = Context.WebLocation.LocationId;
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
            LocationEditViewModel model = new LocationEditViewModel
            {
                Location = _dataService.GetLocationWithId(locationId)
            };

            return View(model);
        }

        /// <summary>
        /// Add song to the queue/playlist for a specific location
        /// </summary>
        /// <param name="locationId">The location identifier.</param>
        /// <param name="songId"></param>
        /// <param name="requestedByUserId"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Queue(int locationId, int songId, int requestedByUserId)  //int locationId, int songId, int requestedByUserId
        {
            try
            {
                _dataService.AddSongToPlaylist(locationId, songId, requestedByUserId);
            }
            catch
            {
            }


            return RedirectToAction("Queue", new { locationId = locationId });
        }

        [HttpGet]
        public ActionResult Queue(int locationId)  //need to find a way to allow the passing of a string location as well
        {
            ViewBag.Location = _dataService.GetLocationWithId(locationId).Name;
            ViewBag.LocationId = locationId;
            var model = new LocationQueueViewModel { PlaylistQueue = _dataService.GetPlaylistByLocation(locationId) };
            return View(model);
        }
    }
}
