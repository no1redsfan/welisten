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
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Gets the favorite songs for a user.
        /// </summary>
        /// <param name="userName">The user name of the user.</param>
        /// <returns>All the favorite songs for a user, or <c>null</c> if none are found.</returns>
        public ICollection<FavoriteSong> GetFavoriteSongsForUser(string userName)
        {
            return (from u in _context.Users where u.UserName == userName select u).Single().FavoriteSongs;
        }

        /// <summary>
        /// Saves the user.
        /// </summary>
        /// <param name="user">The user to save.</param>
        /// <returns><c>true</c> if the save was successful; otherwise, <c>false</c>.</returns>
        public bool SaveUser(User user)
        {
            this._context.Entry(user).State = user.UserId == 0 ? EntityState.Added : EntityState.Modified;
            try
            {
                this._context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="isDisposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
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