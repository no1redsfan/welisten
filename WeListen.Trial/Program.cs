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
            using (var dataService = new Service())
            {
                
                //Get favorite songs
//                 Console.WriteLine("Getting favorite songs for user jimmy...");
//                var favoriteSongs = dataService.GetFavoriteSongsForUser("Jimmy");
//                foreach (var favoriteSong in favoriteSongs)
//                {
//                    Console.WriteLine("{0} by {1}", favoriteSong.Song.Title, favoriteSong.Song.Artist.Name);
//                }

                //Save new user
//                dataService.SaveUser(new User
//                {
//                    Email = "bjorg.prodan@uc.edu",
//                    FirstName = "Bjorg",
//                    LastName = "Prodan",
//                    Password = "password",
//                    UserName = "bjorg"
//                });

                //Get songs by location
//                Console.WriteLine("Getting songs by location...");
//                var songsAvailableInUHall = dataService.GetSongsByLocation(1);
//                foreach (var song in songsAvailableInUHall)
//                {
//                    Console.WriteLine("{0} by {1}", song.Title, song.Artist.Name);
//                }

                //Update song in playlist, aka mark as played
//                Console.WriteLine("Updating song in playlist...");
//                dataService.UpdateSongInPlaylist(1, 1); // this is how you would mark a song as played in a playlist

                //Add song to playlist
//                Console.WriteLine("Adding song to playlist...");
//                dataService.AddSongToPlaylist(1, 1, 1); // this is how you add a song to a playlist (one way anyway)

                //Get playlist by location with id
//                                Console.WriteLine("Getting playlist by location at uhall, locatioid 1...");
//                                var requestedSongs = dataService.GetPlaylistByLocation(1); // get the playlist for U-Hall
//                                foreach (var song in requestedSongs)
//                                {
//                                    Console.WriteLine("{0} by {1}", song.LocationCatalog.Song.Title, song.LocationCatalog.Song.Artist.Name);
//                                }

                //Get songs queued by user
//                var songsq = dataService.GetSongsQueuedByUser(1);
//                foreach (var song in songsq)
//                {
//                    Console.WriteLine(song.Title);
//                }



            }
            Console.ReadLine();
        }
    }
}
