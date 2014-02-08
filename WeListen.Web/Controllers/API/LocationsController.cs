using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Elmah.ContentSyndication;
using WeListen.Data;
using WeListen.Web.Models.API;

namespace WeListen.Web.Controllers.API
{
    public class LocationsController : ApiController
    {

        private readonly Service _dataService = new Service();
        private readonly WeListenEntityModel _context = new WeListenEntityModel();


        // GET api/locations
        public ICollection<Location> GetLocations()
        {
            return (_dataService.GetLocations());
        }

        // GET api/locations/5

        /// <summary>
        /// Gets the location playlists songs.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>List of songs</returns>
        public IEnumerable<PlayListSong> GetLocationPlaylistsSongs(int id)
        {
            var result = _context.LocationPlaylists.Where(l => l.LocationCatalog.LocationId == id)
                .Select(l => new PlayListSong
                {
                    Artist = l.LocationCatalog.Song.Artist.Name,
                    Duration = l.LocationCatalog.Song.Duration,
                    FilePath = l.LocationCatalog.Song.FilePath,
                    LocationPlayistId = l.LocationPlaylistId,
                    SongId = l.LocationCatalog.SongId,
                    Title = l.LocationCatalog.Song.Title,
                    Album = l.LocationCatalog.Song.Album.Title
                }).ToList();
            
            return (result);
        }


        // POST api/locations
        public void Post([FromBody]string value)
        {
        }

        // PUT api/locations/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/locations/5
        public void Delete(int id)
        {
        }
    }
}
