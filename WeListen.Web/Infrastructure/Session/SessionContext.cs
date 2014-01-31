using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeListen.Data;
using WeListen.Web.Models;

namespace WeListen.Web.Infrastructure.Session
{
    /// <summary>
    /// A utility class to handle storage via a session.
    /// </summary>
    public class SessionContext
    {
        /// <summary>
        /// The key for storing a <see cref="WebAccount"/> in a session.
        /// </summary>
        private const string WebAccountSessionKey = "WebAccount";
        private const string WebUserSessionKey = "WebUser";
        //private const string WebLocationSessionKey = "WebLocation";
        //private const string WebUserRoleSessionKey = "WebUserRole"; not sure if or how to do this


        /// <summary>
        /// Initializes a new instance of the <see cref="SessionContext"/> class.
        /// </summary>
        public SessionContext()
        {
            this.Refresh();
        }

        /// <summary>
        /// Gets or sets the currently logged in <see cref="WebUser"/> for the web site.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public WebUser WebUser
        {
            get
            {
                // ensure that a valid user object is always returned
                WebUser result = HttpContext.Current.Session[WebUserSessionKey] as WebUser;
                if (result != null) return result;
                result = new WebUser();
                this.WebUser = result;
                return result;
            }

            set
            {
                // ensure that a valid user object is always stored
                if (value == null)
                {
                    value = new WebUser();
                }

                HttpContext.Current.Session[WebUserSessionKey] = value;
                this.Refresh();
            }
        }

        /*public WebLocation WebLocation
        {
            get
            {
                // ensure that a valid user object is always returned
                WebLocation result = HttpContext.Current.Session[WebLocationSessionKey] as WebLocation;
                if (result != null) return result;
                result = new WebLocation();
                this.WebLocation = result;
                return result;
            }

            set
            {
                // ensure that a valid user object is always stored
                if (value == null)
                {
                    value = new WebLocation();
                }

                HttpContext.Current.Session[WebLocationSessionKey] = value;
                this.Refresh();
            }
        }*/

        /// <summary>
        /// Clears the 
        /// </summary>
        public void Clear()
        {
            this.WebUser = new WebUser();
            //this.WebLocation = new WebLocation();
            // TODO - add any code to clear out what is being stored in the session
        }

        /// <summary>
        /// Refreshes the data.
        /// </summary>
        public void Refresh()
        {
            // TODO - add any code in here that needs to be called in order to refresh what is being stored in the session
        }
    }
}