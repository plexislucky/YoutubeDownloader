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
using System.Security.Cryptography.X509Certificates;

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
            ActiveForm.Text = "Downloading";
            try
            {
                downloadAudio(videourl_textbox.Text);
                MessageBox.Show("Audio successfully downloaded!", "Success!", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ActiveForm.Text = "Youtube Downloader";
        }

        private void downmp4_button_Click(object sender, EventArgs e)
        {
            ActiveForm.Text = "Downloading";
            try
            {
                downloadVideo(videourl_textbox.Text);
                MessageBox.Show("Audio successfully downloaded!", "Success!", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ActiveForm.Text = "Youtube Downloader";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = AskFile();
            if (path != null)
            {
                UseListFile(path);
            }
        }
        public string AskFile()
        {
            string path = null;
            yt_file_dialog.Filter = "All files|*.*";

            if (yt_file_dialog.ShowDialog() == DialogResult.OK)
            {
                path = yt_file_dialog.FileName;
            }

            return path;
        }
        public void UseListFile(string path)
        {
            try
            {
                string[] lines = File.ReadAllLines(path);
                List<string> links = new List<string> { };
                short found = 0;
                foreach (string l in lines)
                {
                    if (l.Contains("youtube.com/watch?v=") || l.Contains("youtu.be/"))
                    {
                        found++;
                        links.Add(l);
                    }
                }

                var msgBox = MessageBox.Show(
                    $"{found} possible links found, convert to MP3? (Choosing no will simply download the MP4s)",
                    "Links found", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                short countDone = 0;
                ActiveForm.Text = $"Downloading (0/{found})";
                switch (msgBox)
                {
                    case DialogResult.Yes:
                        foreach (string link in links)
                        {
                            try 
                            {
                                downloadAudio(link);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Exception occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            countDone += 1;
                            ActiveForm.Text = $"Downloading ({countDone}/{found})";
                        }

                        MessageBox.Show("Audios successfully downloaded!", "Success!", MessageBoxButtons.OK);
                        ActiveForm.Text = "Youtube Downloader";
                        break;

                    case DialogResult.No:
                        foreach (string link in links)
                        {
                            try
                            {
                                downloadVideo(link);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Exception occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            countDone += 1;
                            ActiveForm.Text = $"Downloading ({countDone.ToString()}/{found})";
                        }

                        MessageBox.Show("Videos successfully downloaded!", "Success!", MessageBoxButtons.OK);
                        ActiveForm.Text = "Youtube Downloader";
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void downloadVideo(string url)
        {
            YouTubeVideo video = youtube.GetVideo(url);
            File.WriteAllBytes(save_path + video.FullName, video.GetBytes());
        }

        public void downloadAudio(string url)
        {
            YouTubeVideo video = youtube.GetVideo(url);
            File.WriteAllBytes(save_path + video.FullName, video.GetBytes());
            FFMpegConverter convert = new FFMpegConverter();

            string video_path = save_path + video.FullName;
            string audio_path = video_path.Remove(video_path.Length - 1, 1) + "3"; // changes extension to mp3

            convert.ConvertMedia(video_path, audio_path, "mp3");

            File.Delete(video_path);
            File.Delete("ffmpeg.exe");
        }
    }
}
