using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeListen.Data;
using WeListen.Web.Models;

namespace WeListen.Web.Viewmodels.Locations
{
    public class LocationHomeViewModel
    {
        public WebAccount Account { get; set; }

        public IEnumerable<Song> Song { get; set; }

        public ICollection<LocationPlaylist> PlaylistQueue { get; set; }


    }
}