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
    
    public partial class Song
    {
        public Song()
        {
            this.FavoriteSongs = new HashSet<FavoriteSong>();
            this.LocationCatalogs = new HashSet<LocationCatalog>();
        }
    
        public int SongId { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
        public string FilePath { get; set; }
        public int PurchasedByUserId { get; set; }
    
        public virtual Album Album { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual ICollection<FavoriteSong> FavoriteSongs { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<LocationCatalog> LocationCatalogs { get; set; }
        public virtual User User { get; set; }
    }
}
