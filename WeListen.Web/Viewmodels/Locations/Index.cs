using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeListen.Data;
using WeListen.Web.Models;

namespace WeListen.Web.Viewmodels.Locations
{
    public class Index
    {


        /// <summary>
        /// Gets or sets the locations.
        /// </summary>
        /// <value>
        /// The locations.
        /// </value>
        public IEnumerable<Location> Locations { get; set; }

        

    }
}