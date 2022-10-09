using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using VideoLibrary;
using NReco.VideoConverter;

namespace YoutubeDownloader
{
    public partial class Form1 : Form
    {
        public string save_path = $@"C:\Users\{Environment.UserName}\Downloads\";
        public YouTube youtube = YouTube.Default    ;
        public Form1()
        {
            InitializeComponent();
        }

        private void downmp3_button_Click(object sender, EventArgs e)
        {
            downloadAudio();
        }

        private void downmp4_button_Click(object sender, EventArgs e)
        {
            downloadVideo();
        }

        public void AskFile()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
            }
        }
        public void downloadVideo()
        {
            try
            {
                YouTubeVideo video = youtube.GetVideo(videourl_textbox.Text);
                File.WriteAllBytes(save_path + video.FullName, video.GetBytes());
                MessageBox.Show($"Video successfully downloaded!", "Success!", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void downloadAudio()
        {
            try
            {
                YouTubeVideo video = youtube.GetVideo(videourl_textbox.Text);
                File.WriteAllBytes(save_path + video.FullName, video.GetBytes());
                FFMpegConverter convert = new FFMpegConverter();

                string video_path = save_path + video.FullName;
                string audio_path = video_path.Remove(video_path.Length - 1, 1) + "3"; // changes extension to mp3

                convert.ConvertMedia(video_path, audio_path, "mp3");

                File.Delete(video_path);
                MessageBox.Show("Audio successfully downloaded!", "Success!", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
