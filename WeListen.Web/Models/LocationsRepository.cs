using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeListen.Data;

namespace WeListen.Web.Models
{
    public class LocationsRepository
    {
        //private readonly WeListenEntityModel _dbContext;
        private readonly WeListenEntityModel _dbContext = new WeListenEntityModel();

        //public LocationsRepository(WeListenEntityModel dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        public IEnumerable<LocationPlaylist> GetAll()
        {
            return _dbContext.LocationPlaylists;
        }

        /// <summary>
        /// don't forget this returns a collection
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<LocationPlaylist> GetById(int id)
        {
            return _dbContext.LocationPlaylists.Where(l => l.LocationCatalog.LocationCatalogId == id);
        }


    }
}