using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace WeListen.Data
{
    /// <summary>
    ///     A utility class for data access.
    /// </summary>
    public class Service : IDisposable
    {
        private readonly WeListenEntityModel _context;
        private bool _isDisposed;

        /// <summary>
        ///     Creates a new instance of the <see cref="Service" /> class.
        /// </summary>
        public Service()
        {
            _context = new WeListenEntityModel();
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Gets the favorite songs for a user.
        /// </summary>
        /// <param name="userName">The user name of the user.</param>
        /// <returns>All the favorite songs for a user, or <c>null</c> if none are found.</returns>
        public ICollection<FavoriteSong> GetFavoriteSongsForUser(string userName)
        {
            return (from u in _context.Users where u.UserName == userName select u).Single().FavoriteSongs;
        }

        /// <summary>
        ///     Gets the playlist for a location using the location id.
        /// </summary>
        /// <param name="locationId">The location id.</param>
        /// <returns>The playlist for the location id.</returns>
        public ICollection<LocationPlaylist> GetPlaylistByLocation(int locationId)
        {
            return
                (from p in _context.LocationPlaylists where p.LocationCatalog.LocationId == locationId select p).ToList();
        }

        /// <summary>
        ///     Gets the playlist for a location using the location name.
        /// </summary>
        /// <param name="locationName">The location name.</param>
        /// <returns>The playlist for the location name.</returns>
        public ICollection<LocationPlaylist> GetPlaylistByLocation(string locationName)
        {
            var location = GetLocation(locationName);
            return GetPlaylistByLocation(location.LocationId);
        }

        /// <summary>
        /// Gets a location.
        /// </summary>
        /// <param name="name">The name of the location.</param>
        /// <returns>A <see cref="Location"/> object, or it throws an exception.</returns>
        public Location GetLocation(string name)
        {
            return (from l in _context.Locations where l.Name == name select l).Single();
        }

        /// <summary>
        ///     Gets the songs for a location.
        /// </summary>
        /// <param name="locationId">The location id.</param>
        /// <returns>The songs available for a location.</returns>
        public ICollection<Song> GetSongsByLocation(int locationId)
        {
            return (from c in _context.LocationCatalogs where c.LocationId == locationId select c.Song).ToList();
        }

        /// <summary>
        ///     Gets the songs for a location.
        /// </summary>
        /// <param name="locationName">The location name.</param>
        /// <returns>The songs available for a location.</returns>
        public ICollection<Song> GetSongsByLocation(string locationName)
        {
            var location = GetLocation(locationName);
            return GetSongsByLocation(location.LocationId);
        }

        /// <summary>
        ///     Adds a song to a playlist.
        /// </summary>
        /// <param name="locationId">The location id.</param>
        /// <param name="songId">The song id.</param>
        /// <param name="requestorUserId">The requestor user id.</param>
        /// <returns><c>true</c> if the save was successful; otherwise, <c>false</c>.</returns>
        public bool AddSongToPlaylist(int locationId, int songId, int requestorUserId)
        {
            LocationCatalog catalogRecord = (from c in _context.LocationCatalogs
                where c.LocationId == locationId && c.SongId == songId
                select c).SingleOrDefault();

            if (catalogRecord == null)
            {
                return false;
            }

            var recordToInsert = new LocationPlaylist
            {
                RequestedDateTime = DateTime.Now,
                RequestedByUserId = requestorUserId,
                LocationCatalogId = catalogRecord.LocationCatalogId
            };


            try
            {
                _context.LocationPlaylists.Add(recordToInsert);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        ///     Saves the user.
        /// </summary>
        /// <param name="user">The user to save.</param>
        /// <returns><c>true</c> if the save was successful; otherwise, <c>false</c>.</returns>
        public bool SaveUser(User user)
        {
            _context.Entry(user).State = user.UserId == 0 ? EntityState.Added : EntityState.Modified;
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Updates the song in a playlist when it has been played.
        /// </summary>
        /// <param name="locationId">The location id.</param>
        /// <param name="songId">The song id.</param>
        /// <returns><c>true</c> if the save was successful; otherwise, <c>false</c>.</returns>
        public bool UpdateSongInPlaylist(int locationId, int songId)
        {
            var recordToUpdate = (from p in _context.LocationPlaylists
                where
                    p.LocationCatalog.LocationId == locationId && p.LocationCatalog.SongId == songId &&
                    p.PlayedDateTime == null
                select p).SingleOrDefault();

            if (recordToUpdate == null)
            {
                return false;
            }

            try
            {
                recordToUpdate.PlayedDateTime = DateTime.Now;
                _context.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///     Saves the song.
        /// </summary>
        /// <param name="song">The song to save.</param>
        /// <returns><c>true</c> if the save was successful; otherwise, <c>false</c>.</returns>
        public bool SaveSong(Song song)
        {
            _context.Entry(song).State = song.SongId == 0 ? EntityState.Added : EntityState.Modified;
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="isDisposing">
        ///     <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only
        ///     unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (_isDisposed)
            {
                return;
            }

            if (isDisposing)
            {
                // release managed resources
                if (_context != null)
                {
                    _context.Dispose();
                }
            }

            _isDisposed = true;
        }
    }
}