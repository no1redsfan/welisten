using System;
using System.Collections;
using System.Windows.Forms;

namespace WeListenPlayer1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Declare variables 
        private NAudio.Wave.BlockAlignReductionStream stream = null;
        private NAudio.Wave.DirectSoundOut output = null;

        //Playlist Variables
        //These variables are string array lists to store song locations.
        ArrayList files = new ArrayList();
        ArrayList paths = new ArrayList();
        //string[] files, paths;

        //Button Methods

        //Method to populate Play List and files and paths arrays
        private void btnAddToPlayList_Click(object sender, EventArgs e)
        {
            //Open file dialog to select tracks and add them to the 
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "MP3 File (*.mp3)|*.mp3;";
            open.Multiselect = true;

            //If result is correct, load the play list and location arrays
            if (open.ShowDialog() == DialogResult.OK)
            {
                files.AddRange(open.SafeFileNames); //Saves only the names
                paths.AddRange(open.FileNames); //Saves the full paths

                foreach (string i in files) 
                {
                    lbxPlayList.Items.Add(i); //Add songs to the playlist.
                }
            }

            //enalble all control buttons when songs are loaded in play list.
            changeButtonAccess();

        }

        //Method for removing a song from the play list and location arrays
        private void btnRemoveFromPlayList_Click(object sender, EventArgs e)
        {

            //Remove selected song forom array lists and list box
            files.RemoveAt(lbxPlayList.SelectedIndex);
            paths.RemoveAt(lbxPlayList.SelectedIndex);
            lbxPlayList.Items.Remove(lbxPlayList.SelectedItem);


            //disable all control buttons when play list is empty.
            changeButtonAccess();
        }

        private void btnClearPlayList_Click(object sender, EventArgs e)
        {
            //Stop the player
            output.Stop();
            // clear the output
            DisposeStream();

            //clear the listbox and array lists
            lbxPlayList.Items.Clear();
            files.Clear();
            paths.Clear();
        }

        //Method for play button
        private void btnPlay_Click(object sender, EventArgs e)
        {
            int pathIndex = 0;
            if (output != null)
            {
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Paused)
                {
                    output.Play();
                }
                else
                {
                    pathIndex = lbxPlayList.SelectedIndex;
                    PlaySelectedSong(pathIndex);
                }
            }
            else
            {
                lbxPlayList.SelectedIndex = 0;
                PlaySelectedSong(pathIndex);
            }
            
        }

        //Method for pause button
        private void btnPause_Click(object sender, EventArgs e)
        {
            if (output != null)
            {
            output.Pause();
            }
        }
        
        //Method for stop button
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (output != null)
            {
            output.Stop();

        }

        //Method for next button
        private void btnNext_Click(object sender, EventArgs e)
        {
            //Check that the is not the last item in the list.
            if (lbxPlayList.SelectedIndex < lbxPlayList.Items.Count - 1)
            {
                // stop the current song
                output.Stop();
                // clear the output
                DisposeStream();

                //select the next song
                lbxPlayList.SelectedIndex = lbxPlayList.SelectedIndex + 1;
                //play next song in list.
                PlaySelectedSong(lbxPlayList.SelectedIndex);
            }
            else
            {
                //If the playlist is at the last song of the list skip back to the first song and play
                lbxPlayList.SelectedIndex = 0;
                PlaySelectedSong(lbxPlayList.SelectedIndex);
            }
        }

        //Method for previous button
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            //Check that the is not the last item in the list.
            if (lbxPlayList.SelectedIndex != 0)
            {
                // stop the current song
                output.Stop();
                // clear the output
                DisposeStream();

                //select the previous song
                lbxPlayList.SelectedIndex = lbxPlayList.SelectedIndex - 1;
                //play next song in list.
                PlaySelectedSong(lbxPlayList.SelectedIndex);
            }
            else
            {
                //If the playlist is at the first song of the list skip to the last song and play
                lbxPlayList.SelectedIndex = lbxPlayList.Items.Count -1;
                PlaySelectedSong(lbxPlayList.SelectedIndex);
            }

        }

        //Method for playing song with a double click
        private void lbxPlayList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PlaySelectedSong(lbxPlayList.SelectedIndex);
        }






        //Methods for controling the functionality

        //method for disabling and enabling control buttons
        private void changeButtonAccess()
        {
            bool loadedSongs = false;
            if (lbxPlayList.Items.Count > 0)
            {
                loadedSongs = true;
            }
            else
            {
                loadedSongs = false;            
            }

            btnPlay.Enabled = loadedSongs;
            btnStop.Enabled = loadedSongs;
            btnPause.Enabled = loadedSongs;
            btnPrevious.Enabled = loadedSongs;
            btnNext.Enabled = loadedSongs;
        }

        //Method to start playing track
        private void PlaySelectedSong(int pathIndex)
        {
            //clear the playing song stream
            DisposeStream();
            //Play the selected song.
            string path = paths[pathIndex].ToString();
            NAudio.Wave.WaveStream pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(path));
            stream = new NAudio.Wave.BlockAlignReductionStream(pcm);
            output = new NAudio.Wave.DirectSoundOut();
            output.Init(stream);
            output.Play();
        }

        // Clear the output - Remove playing song
        private void DisposeStream()
        {
            if (output != null)
            {
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing) output.Stop();
                output.Dispose();
                output = null;
            }
            if (output != null)
            {
                stream.Dispose();
                stream = null;
            }
        }

        //method not used yet
        private void RemoveSong(int songIndex)
        {
            files.RemoveAt(songIndex);
            paths.RemoveAt(songIndex);
            lbxPlayList.Items.Remove(songIndex);
        }




    }
}
