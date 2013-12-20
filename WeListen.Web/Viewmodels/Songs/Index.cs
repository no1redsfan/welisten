using System.Collections.Generic;
using WeListen.Data;

namespace WeListen.Web.Viewmodels.Songs
{
    /// <summary>
    ///     The index view model for the Songs controller.
    /// </summary>
    public class Index
    {
        /// <summary>
        ///     Gets or sets the songs.
        /// </summary>
        /// <value>
        ///     The songs.
        /// </value>
        public IEnumerable<Song> Songs { get; set; }

    }
}