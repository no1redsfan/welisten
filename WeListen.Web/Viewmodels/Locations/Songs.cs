using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeListen.Data;

namespace WeListen.Web.Viewmodels.Locations
{
    public class Songs
    {
        /// <summary>
        /// Gets or sets the song.
        /// </summary>
        /// <value>
        /// The song.
        /// </value>
        public IEnumerable<Song> Song { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        public int Role { get; set; }
    }
}