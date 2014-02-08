using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeListen.Data;
using WeListen.Web.Models;

namespace WeListen.Web.Controllers.API
{
    public class LocalController : ApiController
    {
        //private readonly WeListenEntityModel _context = new WeListenEntityModel();
        LocationsRepository lr = new LocationsRepository();

        // GET api/local
        public IEnumerable<LocationPlaylist> Get()
        {
            return lr.GetAll(); //_context.LocationPlaylists;
        }

        // GET api/local/5
        public IEnumerable<LocationPlaylist> Get(int id)
        {
            return lr.GetById(id); //_context.LocationPlaylists.Where(l => l.LocationCatalog.LocationCatalogId == id);
        }

        // POST api/local
        public void Post([FromBody]string value)
        {
        }

        // PUT api/local/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/local/5
        public void Delete(int id)
        {
        }
    }
}
