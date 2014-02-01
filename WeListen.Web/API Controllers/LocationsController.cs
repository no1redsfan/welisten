using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using System.Web.Routing;
using WeListen.Data;

namespace WeListen.Web.API_Controllers
{
    public class LocationsController : ApiController
    {

        private readonly Service _dataService = new Service();

        // GET api/locations
        public ICollection<Location> GetLocations()
        {
            return (_dataService.GetLocations());
        }

        // GET api/locations/5
        
        public ICollection<LocationPlaylist> Get(int id)
        {
            return (_dataService.GetPlaylistByLocation(id));
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
