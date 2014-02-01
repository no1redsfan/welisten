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
        public int CreatedByUserId { get; set; }

        [DisplayName("Name*")]
        [StringLength(50, ErrorMessage = "The username cannot exceed 50 characters.")]
        [Required]
        public string UserName { get; set; }

        [DisplayName("Zipcode")]
        public string Zipcode { get; set; }

        /*[DisplayName("Password*")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }*/
    }
}