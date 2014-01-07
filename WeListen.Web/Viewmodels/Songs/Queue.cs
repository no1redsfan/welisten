using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeListen.Data;

namespace WeListen.Web.Viewmodels.Songs
{
    public class Queue
    {
        /// <summary>
        /// Gets or sets the songs.
        /// </summary>
        /// <value>
        /// The songs.
        /// </value>
        public ICollection<LocationPlaylist> PlaylistQueue { get; set; }
        
    }
}