using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeListen.Data;

namespace WeListen.Trial
{
    class Program
    {
        static void Main(string[] args)
        {
            /*using (var dataService = new Service())
            {
                var favoriteSongs = dataService.GetFavoriteSongsForUser("Jimmy");
                foreach (var favoriteSong in favoriteSongs)
                {
                    Console.WriteLine("{0} by {1}", favoriteSong.Song.Title, favoriteSong.Song.Artist.Name);
                }


                dataService.SaveUser(new User
                {
                    Email = "bjorg.prodan@uc.edu",
                    FirstName = "Bjorg",
                    LastName = "Prodan",
                    Password = "password",
                    UserName = "bjorg"
                });
            }*/

            /*using (var dataService = new Service())
            {
                var songsAvailableInUHall = dataService.GetSongsByLocation(1);
                foreach (var song in songsAvailableInUHall)
                {
                    Console.WriteLine("{0} by {1}", song.Title, song.Artist.Name);
                }

                // dataService.AddSongToPlaylist(1, 1, 1); // this is how you add a song to a playlist (one way anyway)

                Console.WriteLine("This is the playlist for U-Hall at the moment:");
                var requestedSongs = dataService.GetPlaylistByLocation(1); // get the playlist for U-Hall
                foreach (var song in requestedSongs)
                {
                    Console.WriteLine("{0} by {1}", song.LocationCatalog.Song.Title, song.LocationCatalog.Song.Artist.Name);
                }

                dataService.UpdateSongInPlaylist(1, 1); // this is how you would mark a song as played in a playlist
            }*/



            Console.ReadLine();

        }
    }
}
