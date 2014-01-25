using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeListen.Web.Models
{
    public class WebLocation
    {
        public int LocationId { get; set; }

        [DisplayName("Name*")]
        [Required]
        public string Name { get; set; }


        public string Zipcode { get; set; }

        
    }
}