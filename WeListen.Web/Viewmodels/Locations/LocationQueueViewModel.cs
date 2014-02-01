using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeListen.Data;

namespace WeListen.Web.Viewmodels.Locations
{
    public class LocationQueueViewModel
    {
        /// <summary>
        /// Gets or sets the playlist queue.
        /// </summary>
        /// <value>
        /// The playlist queue.
        /// </value>
        public ICollection<LocationPlaylist> PlaylistQueue { get; set; }
    }
}