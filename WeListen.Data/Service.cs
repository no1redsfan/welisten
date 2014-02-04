using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.IO;
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

        public List<LocationPlaylist> GetPlaylistByLocationId(int locationId)
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
            Location location = GetLocation(locationName);
            return GetPlaylistByLocation(location.LocationId);
        }

        /// <summary>
        ///     Gets a location.
        /// </summary>
        /// <param name="name">The name of the location.</param>
        /// <returns>A <see cref="Location" /> object, or it throws an exception.</returns>
        public Location GetLocation(string name)
        {
            return (from l in _context.Locations where l.Name == name select l).Single();
        }

        public Location GetLocationWithId(int locationId)
        {
            return (from l in _context.Locations where l.LocationId == locationId select l).Single();
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
        ///     Gets the songs.
        /// </summary>
        /// <returns>All songs in the database.</returns>
        public ICollection<Song> GetSongs()
        {
            return (from s in _context.Songs select s).ToList();
        }

        public ICollection<Song> GetTopPlayedSongs()
        {
            return
                (from p in _context.LocationPlaylists where p.PlayedDateTime != null select p.LocationCatalog.Song)
                    .ToList();
        }


        /// <summary>
        ///     Gets the songs for a location.
        /// </summary>
        /// <param name="locationName">The location name.</param>
        /// <returns>The songs available for a location.</returns>
        public ICollection<Song> GetSongsByLocation(string locationName)
        {
            Location location = GetLocation(locationName);
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
        ///     Authenticates the user.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The password.</param>
        /// <returns><c>true</c> if the credentials are valid; otherwise, <c>false</c>.</returns>
        public bool AuthenticateUser(string userName, string password)
        {
            return
                ((from u in _context.Users where u.UserName == userName && u.Password == password select u)
                    .FirstOrDefault() != null);
        }

        public bool SaveUserRole(UserRole userRole)
        {
            _context.Entry(userRole).State = userRole.UserId == 0 ? EntityState.Added : EntityState.Modified;
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
        ///     Saves the location.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <returns><c>true</c> if the save was successful; otherwise, <c>false</c>.</returns>
        public bool SaveLocation(Location location)
        {
            _context.Entry(location).State = location.LocationId == 0 ? EntityState.Added : EntityState.Modified;
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
        ///     Updates the song in a playlist when it has been played.
        /// </summary>
        /// <param name="locationId">The location id.</param>
        /// <param name="songId">The song id.</param>
        /// <returns><c>true</c> if the save was successful; otherwise, <c>false</c>.</returns>
        public bool UpdateSongInPlaylist(int locationId, int songId)
        {
            LocationPlaylist recordToUpdate = (from p in _context.LocationPlaylists
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
            catch (DbEntityValidationException e)
            {
                return false;
            }
            catch (Exception e)
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

        /// <summary>
        ///     Gets the artists.
        /// </summary>
        /// <returns>All the artists in the database.</returns>
        public ICollection<Artist> GetArtists()
        {
            return (from a in _context.Artists select a).ToList();
        }

        /// <summary>
        ///     Gets the genres.
        /// </summary>
        /// <returns>All the genres in the database.</returns>
        public ICollection<Genre> GetGenres()
        {
            return (from g in _context.Genres orderby g.Genre1 select g).ToList();
        }

        /// <summary>
        ///     Gets the albums.
        /// </summary>
        /// <returns>All the albums in the database.</returns>
        public ICollection<Album> GetAlbums()
        {
            return (from a in _context.Albums select a).ToList();
        }

        /// <summary>
        ///     Gets the locations.
        /// </summary>
        /// <returns>All the locations in the database</returns>
        public ICollection<Location> GetLocations()
        {
            return (from l in _context.Locations select l).ToList();
        }

        /// <summary>
        ///     Gets the users.
        /// </summary>
        /// <returns>Collection of users</returns>
        public ICollection<User> GetUsers()
        {
            return (from u in _context.Users select u).ToList();
        }

        public ICollection<Role> GetRoles()
        {
            return (from r in _context.Roles select r).ToList();
        }

        /// <summary>
        ///     Gets the users that have the user role.
        /// </summary>
        /// <returns>Collection of users who have the user role of 'User'</returns>
        public ICollection<User> GetUsersWithUserRole()
        {
            return (from c in _context.UserRoles where c.UserId == '3' select c.User).ToList();
                //recheck this, i was getting tired
        }

        /// <summary>
        ///     Gets the songs queued by user.
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>Collection of songs queue by user</returns>
        public ICollection<Song> GetSongsQueuedByUser(int userId)
        {
            return
                (from c in _context.LocationPlaylists where c.RequestedByUserId == userId select c.LocationCatalog.Song)
                    .ToList();
        }

        /// <summary>
        /// Gets the djs for a certain location.
        /// </summary>
        /// <param name="locationId">The location identifier.</param>
        /// <returns></returns>
        public ICollection<User> GetLocationDjs(int locationId)
        {
            return
                (from c in _context.LocationDjs where c.LocationId == locationId select c.User).ToList();
        }

        /// <summary>
        ///     Gets the songs queued by user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>Collection of songs queued by user</returns>
        public ICollection<Song> GetSongsQueuedByUser(string username)
        {
            User user = GetUserByUsername(username);

            return (from c in _context.LocationPlaylists
                where
                    c.RequestedByUserId == user.UserId
                select c.LocationCatalog.Song).ToList();
        }

        /// <summary>
        ///     Gets the user by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>User object</returns>
        public User GetUserByUsername(string username)
        {
            return (from u in _context.Users where u.UserName == username select u).SingleOrDefault();
        }


        /// <summary>
        ///     Gets the user role by role identifier.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>The userrole</returns>
        public UserRole GetUserRoleByRoleId(int roleId)
        {
            return (from u in _context.UserRoles where u.RoleId == roleId select u).Single();
        }

        /// <summary>
        /// Get the role of the user by the ID of the user
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Role id</returns>
        public int GetUserRoleIdByUserId(int userId)
        {
            return (from u in _context.UserRoles where u.UserId == userId select u.RoleId).Single();
        }

        /*public int GetNumOf()
        {
                IQueryable<User> result = (from u in _context. select u);
                int count = Enumerable.Count(result);

                return count;
            
        }*/

        //not a dataservice method but wanted to add this here anyway for now
        public string GetFileName(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            return fileName;
        }

        public List<User> GetDjsLike(string djname)
        {
            return (from u in _context.Users where u.UserName.Contains(djname) select u).ToList();
        }

        /// <summary>
        /// Saves the location dj. This allows a DJ to dj at a certain location.
        /// </summary>
        /// <param name="locationId">The location identifier.</param>
        /// <param name="DjId">The dj identifier.</param>
        /// <returns>True if save was succesfull, false otherwise</returns>
        public bool SaveLocationDj(int locationId, int DjId)
        {
            LocationDj recordToInsert = new LocationDj
            {
                LocationId = locationId, 
                UserId = DjId
            };

            
            try
            {
                _context.LocationDjs.Add(recordToInsert);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Gets the locations/events that a user created.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>A list of locations/events that a certain user created.</returns>
        public ICollection<Location> GetLocationsForUser(int userId)
        {
            return (from c in _context.Locations where c.CreatedByUserId == userId
                    select c).ToList();
        }


        /// <summary>
        /// Gets the user by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>User object</returns>
        public User GetUserByUserId(int userId)
        {
            return (from u in _context.Users where u.UserId == userId select u).SingleOrDefault();
        }

        /// <summary>
        /// Gets the user role by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>A Role object</returns>
        public Role GetUserRoleByUserId(int userId)
        {
            return (from u in _context.UserRoles where u.UserId == userId select u.Role).Single();
        }


        public string GetSongPathWithLocationId(int locationId)
        {
            return (from u in _context.LocationCatalogs where u.LocationId == locationId select u.Songs.FilePath).Single();
        }
    }
}