//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeListen.Data
{
    using System;
    using System.Collections.Generic;
    
    using System.Runtime.Serialization;
    
    
            [KnownType(typeof(LocationCatalog))]
            [KnownType(typeof(LocationDj))]
            [KnownType(typeof(User))]
    public partial class Location
    {
        public Location()
        {
            this.LocationCatalogs = new HashSet<LocationCatalog>();
            this.LocationDjs = new HashSet<LocationDj>();
        }
    
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Zipcode { get; set; }
        public Nullable<int> CreatedByUserId { get; set; }
    
        public virtual ICollection<LocationCatalog> LocationCatalogs { get; set; }
        public virtual ICollection<LocationDj> LocationDjs { get; set; }
        public virtual User User { get; set; }
    }
}
