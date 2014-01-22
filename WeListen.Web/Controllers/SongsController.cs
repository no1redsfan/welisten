using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using WeListen.Data;
using WeListen.Web.Viewmodels.Songs;

namespace WeListen.Web.Controllers
{
    /// <summary>
    /// The songs controller for the application.
    /// </summary>
    public class SongsController : BaseController
    {
        private readonly Service _dataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SongsController"/> class.
        /// </summary>
        public SongsController()
        {
            _dataService = new Service();
        }

        /// <summary>
        /// The index action of the song controller.
        /// </summary>
        /// <returns>A view that is rendered in a browser.</returns>
        public ActionResult Index()
        {
            var model = new Index {Songs = _dataService.GetSongs()};
            return View(model);
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
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            var model = new Create
            {
                Song = new Song(),
                Artists = _dataService.GetArtists(),
                // Genres = _dataService.GetGenres().OrderBy(g => g.Genre1), // order by here or in the data service layer
                Genres = _dataService.GetGenres(),
                Albums = _dataService.GetAlbums()
            };
            return View(model);
        }

        /// <summary>
        /// Creates the specified new song.
        /// </summary>
        /// <param name="newSong">The new song.</param>
        /// <returns>View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Song newSong)
        {
            if (!ModelState.IsValid)
            {
                var model = new Create
                {
                    Song = newSong,
                    Artists = _dataService.GetArtists(),
                    Genres = _dataService.GetGenres(),
                    Albums = _dataService.GetAlbums()
                };
                return View(model);
            }

            newSong.PurchasedByUserId = 1;
            newSong.Duration = 230;
            newSong.FilePath = "c:/temp/dummy.mp3";
            _dataService.SaveSong(newSong);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Get the queue/playlist by location
        /// </summary>
        /// <returns>List of the queue</returns>
        [HttpGet]
        public ActionResult Queue(int locationId)  //need to find a way to allow the passing of a string location as well
        {
            ViewBag.Location = _dataService.GetLocationNameWithId(locationId).Name;
            ViewBag.LocationId = locationId;
            var model = new Queue { PlaylistQueue = _dataService.GetPlaylistByLocation(locationId) };
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
            _dataService.AddSongToPlaylist(locationId, songId, requestedByUserId); //fake locationId for now
            return RedirectToAction("Queue", new {locationId = locationId});
        }

        //couldnt get it to do the post with queue, the method above, so i just copied it and named it different
        public ActionResult AddToQueue(int locationId, int songId, int requestedByUserId)  //int locationId, int songId, int requestedByUserId
        {
            _dataService.AddSongToPlaylist(locationId, songId, requestedByUserId); 
            return RedirectToAction("Queue", new { locationId = locationId });
        }
       

    }
}
