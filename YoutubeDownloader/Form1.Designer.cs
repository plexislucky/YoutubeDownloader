namespace YoutubeDownloader
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.videourl_textbox = new System.Windows.Forms.TextBox();
            this.downmp4_button = new System.Windows.Forms.Button();
            this.downmp3_button = new System.Windows.Forms.Button();
            this.yt_file_dialog = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // videourl_textbox
            // 
            this.videourl_textbox.Location = new System.Drawing.Point(13, 12);
            this.videourl_textbox.Name = "videourl_textbox";
            this.videourl_textbox.Size = new System.Drawing.Size(287, 20);
            this.videourl_textbox.TabIndex = 0;
            // 
            // downmp4_button
            // 
            this.downmp4_button.Location = new System.Drawing.Point(159, 38);
            this.downmp4_button.Name = "downmp4_button";
            this.downmp4_button.Size = new System.Drawing.Size(141, 23);
            this.downmp4_button.TabIndex = 1;
            this.downmp4_button.Text = "Download MP4";
            this.downmp4_button.UseVisualStyleBackColor = true;
            this.downmp4_button.Click += new System.EventHandler(this.downmp4_button_Click);
            // 
            // downmp3_button
            // 
            this.downmp3_button.Location = new System.Drawing.Point(12, 38);
            this.downmp3_button.Name = "downmp3_button";
            this.downmp3_button.Size = new System.Drawing.Size(141, 23);
            this.downmp3_button.TabIndex = 2;
            this.downmp3_button.Text = "Download MP3";
            this.downmp3_button.UseVisualStyleBackColor = true;
            this.downmp3_button.Click += new System.EventHandler(this.downmp3_button_Click);
            // 
            // yt_file_dialog
            // 
            this.yt_file_dialog.InitialDirectory = "C:\\";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(288, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Import list of YT links";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 95);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.downmp3_button);
            this.Controls.Add(this.downmp4_button);
            this.Controls.Add(this.videourl_textbox);
            this.Name = "Form1";
            this.Text = "Youtube Downloader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox videourl_textbox;
        private System.Windows.Forms.Button downmp4_button;
        private System.Windows.Forms.Button downmp3_button;
        private System.Windows.Forms.OpenFileDialog yt_file_dialog;
        private System.Windows.Forms.Button button1;
    }
}

