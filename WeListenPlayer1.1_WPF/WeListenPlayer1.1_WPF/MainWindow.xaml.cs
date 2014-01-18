using Microsoft.Win32;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WeListenPlayer1._1_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //create timer to track song position
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += OnTimerTick;
            EnableControls();
            PopulateCboDevices();
        }

        //Declare Variables
        //for wasapiOut
        private WasapiOut wasapiOut;
        private AudioFileReader reader;
        private DispatcherTimer timer;
        private String isPlaying;

        //These variables are string array lists to store song locations.
        ArrayList files = new ArrayList();
        ArrayList paths = new ArrayList();


        ///////////////////
        //Control Methods//
        ///////////////////

        //////////////////////////////
        //Audio play control methods//
        //////////////////////////////

        //Method for when the play button is clicked
        private void OnPlayClick(object sender, RoutedEventArgs e)
        {
            //Check to see if the buffer is loaded.
            if (wasapiOut != null)
            {
                //If buffer is loaded
                //Check to see if playback is paused.
                if (wasapiOut.PlaybackState == PlaybackState.Paused)
                {
                    //Mark continuous play
                    chkContinuousPlay.IsChecked = true;
                    //Play the song from current position
                    wasapiOut.Play();
                    //enable the appropriate controls
                    EnableControls();
                }
            }
            else
            {
                //Check continuous
                chkContinuousPlay.IsChecked = true;
                PlaySelectedSong();
            }
        }

        //Method for when the stop button is clicked
        private void OnStopClicked(object sender, RoutedEventArgs e)
        {
            //if stop button is pushed, uncheck continuous 
            chkContinuousPlay.IsChecked = false;
            //for wasapiOut
            wasapiOut.Stop();
        }

        //Method for when the pause button is clicked
        private void OnPauseClicked(object sender, RoutedEventArgs e)
        {
            wasapiOut.Pause();
            EnableControls();
        }

        //Method for back button
        private void OnBackClick(object sender, RoutedEventArgs e)
        {
            // call stop and then call play.
            chkContinuousPlay.IsChecked = false;
            wasapiOut.Stop();
            PlaySelectedSong();
        }

        //Method for forward button
        private void OnForwardClick(object sender, RoutedEventArgs e)
        {
            //If list is not empty, stop and delete the playing song and start the next.
            if (!lbxPlayList.Items.IsEmpty)
            {
                wasapiOut.Stop();
            }
            else
            {
                //A new method needs to be called to grab a random song.
            }
        }

        //Method for position slider drag complete
        private void SldrPositionOnDragCompleted(object sender, EventArgs e)
        {
            //If the buffer is not null allow the position to be moved
            if (wasapiOut != null)
            {
                reader.CurrentTime = TimeSpan.FromSeconds(sldrPosition.Value + 2.5);
            }
        }

        //Method for volume slider change
        private void OnSldrVolumeChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //for wasapiOut
            if (wasapiOut != null)
            {
                //simple way of controling volume - Glitchy
                //var device = (MMDevice)cboDevices.SelectedItem;
                //device.AudioEndpointVolume.MasterVolumeLevelScalar = (float)sldrVolume.Value;
                //wasapiOut.Volume = sldrVolume.Value

                reader.Volume = (float)sldrVolume.Value;
            }
        }



        ////////////////////////////
        //Playlist Control Methods//
        ////////////////////////////

        //Method for Adding songs to playList
        private void OnAddSongClick(object sender, RoutedEventArgs e)
        {
            //Create arrayLists for new files to add
            //These variables are string array lists to store song locations.
            ArrayList newFiles = new ArrayList();
            ArrayList newPaths = new ArrayList();

            //Open file dialog to select tracks and add them to the play list
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "MP3 File (*.mp3)|*.mp3;";
            open.DefaultExt = ".mp3";
            open.Multiselect = true;

            //Show open
            Nullable<bool> result = open.ShowDialog();

            //Process open file dialog box result
            if (result == true)
            {
                //add files to arrays
                newFiles.AddRange(open.SafeFileNames); //Saves only the names
                newPaths.AddRange(open.FileNames); //Saves the full paths
            }
            //Call addSong Method
            AddSongsToPlaylist(newFiles, newPaths);
        }

        //method for starting to receive the requests
        private void OnRecieveRequestClick(object sender, RoutedEventArgs e)
        {
            //code for timed database calls goes here.  It will add songs to playlists and arrays.
        }

        //Method for moving items up in playlist
        private void OnMoveUpClick(object sender, RoutedEventArgs e)
        {
            var movement = -1;


            if (wasapiOut != null)
            {

                //If its playing or paused you can not move the item into the playing position of the list.
                if (lbxPlayList.SelectedIndex > 1 && lbxPlayList.SelectedIndex != -1)
                {
                    //Move the item up the playlist
                    MoveItemInPlaylist(movement);
                }

            }
            else
            {
                //If the player is stopped you can move the item into the play position of the list.
                if (lbxPlayList.SelectedIndex > 0 && lbxPlayList.SelectedIndex != -1)
                {
                    MoveItemInPlaylist(movement);
                }
            }
        }

        //Method for moving items down in playlist
        private void OnMoveDownClick(object sender, RoutedEventArgs e)
        {
            var movement = 2;
            //If its playing or paused you can not move the item in the play position of the list.
            if (wasapiOut != null)
            {
                if (lbxPlayList.SelectedIndex > 0 && lbxPlayList.SelectedIndex != lbxPlayList.Items.Count - 1)
                {
                    MoveItemInPlaylist(movement);
                }
            }
            else if (lbxPlayList.SelectedIndex != -1 && lbxPlayList.SelectedIndex != lbxPlayList.Items.Count - 1)
            {
                MoveItemInPlaylist(movement);
            }
        }

        //Method for removing song from playlist
        private void OnRemoveSongClick(object sender, RoutedEventArgs e)
        {
            //If song is playing or paused you can not remove the item in the play position of the list.
            if (wasapiOut != null)
            {
                if (lbxPlayList.SelectedIndex > 0 && lbxPlayList.SelectedIndex != lbxPlayList.Items.Count - 1)
                {
                    removeSongFromPlayList(lbxPlayList.SelectedIndex);
                }
            }
            else if (lbxPlayList.SelectedIndex != -1 && lbxPlayList.SelectedIndex != lbxPlayList.Items.Count - 1)
            {
                removeSongFromPlayList(lbxPlayList.SelectedIndex);
            }
        }



        ////////////////////////////////////////
        //methods for background audio control//
        ////////////////////////////////////////

        //method for adding song to playlist
        private void AddSongsToPlaylist(ArrayList newFiles, ArrayList newPaths)
        {
            //Add new files to playList and arrayLists
            foreach (string i in newFiles)
            {
                //add new files
                files.Add(i);
                lbxPlayList.Items.Add(i);
            }
            foreach (string n in newPaths)
            {
                //add new paths
                paths.Add(n);
            }
        }

        //Method for when stop is called
        void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            timer.Stop();
            sldrPosition.Value = 0;
            txtPosition.Text = "0:0:0";

            DisposeStream();

            EnableControls();
            if (chkContinuousPlay.IsChecked == true)
            {
                //If continuous is checked play next song.
                removeSongFromPlayList(0);
                PlaySelectedSong();
            }

            if (e.Exception != null)
            {
                MessageBox.Show(e.Exception.Message);
            }
        }

        //Method for enabling and disabling controls
        private void EnableControls()
        {
            if (wasapiOut == null)
            {
                btnPlay.IsEnabled = true;
                btnPause.IsEnabled = false;
                btnStop.IsEnabled = false;
                sldrPosition.IsEnabled = false;
            }
            else
            {
                if (wasapiOut.PlaybackState == PlaybackState.Playing)
                {
                    btnPlay.IsEnabled = false;
                    btnPause.IsEnabled = true;
                    btnStop.IsEnabled = true;
                    sldrPosition.IsEnabled = true;
                }
                else if (wasapiOut.PlaybackState == PlaybackState.Paused)
                {
                    btnPlay.IsEnabled = true;
                    btnPause.IsEnabled = false;
                    btnStop.IsEnabled = true;
                    sldrPosition.IsEnabled = true;
                }
            }
            //If a song is not playing enable the following
            //btnPlay.IsEnabled = !isPlaying;

            //If a song is playing enable the following
            //btnStop.IsEnabled = isPlaying;
            //sldrPosition.IsEnabled = isPlaying;
            //btnPause.IsEnabled = isPlaying;

            //note that volume is always enabled
        }

        //Method for each tick of the timer
        void OnTimerTick(object sender, EventArgs e)
        {
            if (wasapiOut != null)
            {
                TimeSpan currentTime = (wasapiOut.PlaybackState == PlaybackState.Stopped) ? TimeSpan.Zero : reader.CurrentTime;
                sldrPosition.Value = reader.CurrentTime.TotalSeconds;
                //sldrPosition.Value = Math.Min(sldrPosition.Maximum, (int)(100 * currentTime.TotalSeconds / reader.TotalTime.TotalSeconds));
                txtPosition.Text = String.Format("{0:00}:{1:00}", (int)currentTime.TotalMinutes, currentTime.Seconds);
            }
            else
            {
                sldrPosition.Value = 0;
            }
        }

        //Method for populating Devices combo box
        private void PopulateCboDevices()
        {
            //for wasapiOut
            var deviceEnumerator = new MMDeviceEnumerator();
            var devices = deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);
            deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            foreach (var device in devices)
            {
                cboDevices.Items.Add(device);
            }
            //Select default automatically
            cboDevices.SelectedIndex = 0;
        }

        // Clear the output - Remove playing song
        private void DisposeStream()
        {
            if (wasapiOut != null)
            {
                if (wasapiOut.PlaybackState == NAudio.Wave.PlaybackState.Playing) wasapiOut.Stop();
                wasapiOut.Dispose();
                wasapiOut = null;
            }
            if (wasapiOut != null)
            {
                reader.Dispose();
                reader = null;
            }
        }

        //Method to start playing the selected song
        private void PlaySelectedSong()
        {

            if (!lbxPlayList.Items.IsEmpty)
            {
                //populate string with the song in the first position of the path arrayList
                string path = paths[0].ToString();
                isPlaying = files[0].ToString();

                //For WasapiOut
                var device = (MMDevice)cboDevices.SelectedItem;
                AudioClientShareMode shareMode = AudioClientShareMode.Shared;
                int latency = 20;
                bool useEventSync = false;
                wasapiOut = new WasapiOut(device, shareMode, useEventSync, latency);
                device.AudioEndpointVolume.MasterVolumeLevelScalar = (float)sldrVolume.Value;

                wasapiOut.PlaybackStopped += OnPlaybackStopped;

                reader = new AudioFileReader(path);

                //TimeSpan currentTime = (wasapiOut.PlaybackState == PlaybackState.Stopped) ? TimeSpan.Zero : reader.CurrentTime;
                //sldrPosition.Maximum = Math.Min(sldrPosition.Maximum, (int)(100 * currentTime.TotalSeconds /reader.TotalTime.TotalSeconds));
                //txtPosition.Text = String.Format("{0:00}:{1:00}", (int)currentTime.TotalMinutes,
                //    currentTime.Seconds);

                txtDurration.Text = String.Format("{0:00}:{1:00}", (int)reader.TotalTime.TotalMinutes, reader.TotalTime.Seconds);
                txtPosition.Text = reader.CurrentTime.ToString();
                sldrPosition.Maximum = reader.TotalTime.TotalSeconds;
                sldrPosition.Value = 0;
                timer.Start();

                reader.Volume = (float)sldrVolume.Value;

                //for wasapiOut
                wasapiOut.Init(reader);
                wasapiOut.Play();

                //enable controls
                EnableControls();
            }
            else
            {
                EnableControls();
                //Method to call random song needs to be called
            }
        }


        //Method to remove songs from playlist
        private void removeSongFromPlayList(int index)
        {
            lbxPlayList.Items.RemoveAt(index);
            files.RemoveAt(index);
            paths.RemoveAt(index);
        }

        //method to move items in playlist and arrayLists
        private void MoveItemInPlaylist(int movement)
        {
            //Store the value of the selected song
            var selectedIndex = lbxPlayList.SelectedIndex;

            //Copy the item in the playlist
            var itemToMove = lbxPlayList.SelectedItem;
            lbxPlayList.Items.Insert(selectedIndex + movement, itemToMove);


            //Copy the file name in the files ArrayList
            var fileItemToMove = files[selectedIndex].ToString();
            files.Insert(selectedIndex + movement, fileItemToMove);

            //Copy the path in the paths ArrayList
            var pathItemToMove = paths[selectedIndex].ToString();
            paths.Insert(selectedIndex + movement, pathItemToMove);
            if (movement != 2)
            {
                selectedIndex++;
            }

            //remove the song from the original position
            removeSongFromPlayList(selectedIndex);

            //Change the selected index to the new position
            lbxPlayList.SelectedItem = itemToMove;
        }

        // Dispose if the window is closed
        private void Window_Closed(object sender, EventArgs e)
        {
            DisposeStream();
        }
    }
}
