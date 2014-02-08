using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeListen.Web.Models.API
{
    public class PlayListSong
    {
        public int LocationPlayistId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string FilePath { get; set; }
        public int Duration { get; set; }
        public int SongId { get; set; }
        public string Album { get; set; }


    }
}