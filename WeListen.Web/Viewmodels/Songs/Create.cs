using System.Collections.Generic;
using WeListen.Data;

namespace WeListen.Web.Viewmodels.Songs
{
    /// <summary>
    ///     The create view model for the songs controller.
    /// </summary>
    public class Create
    {
        /// <summary>
        ///     Gets or sets the song.
        /// </summary>
        /// <value>
        ///     The song.
        /// </value>
        public Song Song { get; set; }

        /// <summary>
        ///     Gets or sets the artists.
        /// </summary>
        /// <value>
        ///     The artists.
        /// </value>
        public IEnumerable<Artist> Artists { get; set; }

        /// <summary>
        ///     Gets or sets the genres.
        /// </summary>
        /// <value>
        ///     The genres.
        /// </value>
        public IEnumerable<Genre> Genres { get; set; }

        /// <summary>
        /// Gets or sets the albums.
        /// </summary>
        /// <value>
        /// The albums.
        /// </value>
        public IEnumerable<Album> Albums { get; set; }
    }
}