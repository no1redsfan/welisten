using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeListen.Data;
using WeListen.Web.Models;

namespace WeListen.Web.Viewmodels.User
{
    public class UserIndexViewModel
    {
        /// <summary>
        /// Gets or sets the web user.
        /// </summary>
        /// <value>
        /// The web user.
        /// </value>
        public WebUser WebUser { get; set; }

        /// <summary>
        /// Gets or sets the locations.
        /// </summary>
        /// <value>
        /// The locations/events.
        /// </value>
        public ICollection<Data.Location> Locations { get; set; } 


    }
}