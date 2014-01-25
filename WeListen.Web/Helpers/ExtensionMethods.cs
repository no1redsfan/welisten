using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeListen.Data;
using WeListen.Web.Models;

namespace WeListen.Web.Helpers
{
    /// <summary>
    /// Contains useful extension methods.
    /// </summary>
    public static class ExtensionMethods
    {

        /// <summary>
        /// Converts a <see cref="User"/> object to a <see cref="WebAccount"/> object.
        /// </summary>
        /// <param name="user">The user object to convert.</param>
        /// <returns>A <see cref="WebAccount"/> object.</returns>
        /*public static WebAccount ToWebAccount(this User user)
        {
            WebAccount result = new WebAccount
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                UserId = user.UserId,
                UserName = user.UserName
            };

            // TODO - maybe hash the password, and also DjPassword and Zipcode are not being stored...

            return result;
        }*/

        public static WebUser ToWebUser(this User user)
        {
            WebUser result = new WebUser
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                UserId = user.UserId,
                UserName = user.UserName
            };

            // TODO - maybe hash the password, and also DjPassword and Zipcode are not being stored...

            return result;
        }
    }
}