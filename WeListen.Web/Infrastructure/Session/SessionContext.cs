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

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionContext"/> class.
        /// </summary>
        public SessionContext()
        {
            this.Refresh();
        }

        /// <summary>
        /// Gets or sets the currently logged in <see cref="WebAccount"/> for the web site.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public WebAccount WebAccount
        {
            get
            {
                // ensure that a valid user object is always returned
                WebAccount result = HttpContext.Current.Session[WebAccountSessionKey] as WebAccount;
                if (result != null) return result;
                result = new WebAccount();
                this.WebAccount = result;
                return result;
            }

            set
            {
                // ensure that a valid user object is always stored
                if (value == null)
                {
                    value = new WebAccount();
                }

                HttpContext.Current.Session[WebAccountSessionKey] = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Clears the 
        /// </summary>
        public void Clear()
        {
            this.WebAccount = new WebAccount();
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