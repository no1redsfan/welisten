using System;
using System.Windows.Forms;

namespace WeListenPlayer
{
    public partial class WeListenPlayer : Form
    {
        public WeListenPlayer()
        {
            InitializeComponent();
        }

        //Declare variables 
        private NAudio.Wave.BlockAlignReductionStream stream = null;
        private NAudio.Wave.DirectSoundOut output = null;

        //Playlist Variables
        string[] files, paths;

        //Method to populate Play List and files and paths arrays
        private void btnAddToPlayList_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "MP3 File (*.mp3)|*.mp3;";
            open.Multiselect = true;
            if (open.ShowDialog() == DialogResult.OK)
            {
                files = open.SafeFileNames; //Saves only the names
                paths = open.FileNames; //Saves the full paths

                for (int i = 0; i < files.Length; i++)
                {
                    lbxPlayList.Items.Add(files[i]); //Add songs to the playlist.
                }
            }
            btnPlayPause.Enabled = true;
        }


        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            //pause or Play music that is already playing or play first track in play list
            if (output != null)
            {
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing)
                {
                    output.Pause();
                    btnPlayPause.Text = "Play";
                }
                else if (output.PlaybackState == NAudio.Wave.PlaybackState.Paused)
                {
                    output.Play();
                    btnPlayPause.Text = "Pause";
                }

            }
            else
            {
                lbxPlayList.SelectedIndex = 0;
            }

        }

        //Stop music that is playing.
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (output != null)
            {
                output.Stop();
                DisposeStream();
                //lbxPlayList.SetSelected(lbxPlayList.SelectedIndex, false);
            }
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

        private void WeListenPlayer_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisposeStream();
        }

        private void lbxPlayList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisposeStream();
            try
            {
                NAudio.Wave.WaveStream pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(paths[lbxPlayList.SelectedIndex]));
                SetStreamAndOutPut(pcm);
            }
            catch (Exception x)
            {
                lblMessage.Text = " Cannot Move Song.";
            }
        }

        //Method to start playing track
        private void SetStreamAndOutPut(NAudio.Wave.WaveStream pcm)
        {
            stream = new NAudio.Wave.BlockAlignReductionStream(pcm);
            output = new NAudio.Wave.DirectSoundOut();
            output.Init(stream);
            output.Play();
        }

        //Method to move song up the play list
        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            MoveItem(-1);
        }

        //Method to move song down the play list
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            MoveItem(1);
        }

        //Method to move songs in Play List
        public void MoveItem(int direction)
        {
            // Checking selected item
            if (lbxPlayList.SelectedItem == null || lbxPlayList.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = lbxPlayList.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= lbxPlayList.Items.Count)
                return; // Index out of range - nothing to do

            object selected = lbxPlayList.SelectedItem;

            // Removing removable element
            lbxPlayList.Items.Remove(selected);
            // Insert it in new position
            lbxPlayList.Items.Insert(newIndex, selected);
            // Restore selection
            lbxPlayList.SetSelected(newIndex, true);

        }


    }
}
