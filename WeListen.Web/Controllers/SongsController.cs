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
    public class SongsController : Controller
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

        [HttpGet]
        public ActionResult Create()
        {
            var model = new Create
            {
                Song = new Song(),
                Artists = _dataService.GetArtists(),
                // Genres = _dataService.GetGenres().OrderBy(g => g.Genre1),
                Genres = _dataService.GetGenres(),
                Albums = _dataService.GetAlbums()
            };
            return View(model);
        }

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
    }
}
