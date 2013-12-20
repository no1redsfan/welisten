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

        private NAudio.Wave.BlockAlignReductionStream stream = null;

        private NAudio.Wave.DirectSoundOut output = null;

        private void btnOpenMedia_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "MP3 File (*.mp3)|*.mp3;";
            if (open.ShowDialog() != DialogResult.OK) return;

            DisposeStream();

            NAudio.Wave.WaveStream pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(open.FileName));
            stream = new NAudio.Wave.BlockAlignReductionStream(pcm);
            output = new NAudio.Wave.DirectSoundOut();
            output.Init(stream);
            output.Play();

            btnPlayPause.Enabled = true;
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (output != null) 
            {
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing) output.Pause();
                else if (output.PlaybackState == NAudio.Wave.PlaybackState.Paused) output.Play();

            }

        }

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
    }
}
