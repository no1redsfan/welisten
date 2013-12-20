namespace WeListenPlayer
{
    partial class WeListenPlayer
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
            this.btnOpenMedia = new System.Windows.Forms.Button();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenMedia
            // 
            this.btnOpenMedia.Location = new System.Drawing.Point(12, 12);
            this.btnOpenMedia.Name = "btnOpenMedia";
            this.btnOpenMedia.Size = new System.Drawing.Size(260, 23);
            this.btnOpenMedia.TabIndex = 0;
            this.btnOpenMedia.Text = "Open MP3 File";
            this.btnOpenMedia.UseVisualStyleBackColor = true;
            this.btnOpenMedia.Click += new System.EventHandler(this.btnOpenMedia_Click);
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Enabled = false;
            this.btnPlayPause.Location = new System.Drawing.Point(13, 55);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(259, 23);
            this.btnPlayPause.TabIndex = 1;
            this.btnPlayPause.Text = "Play/Pause";
            this.btnPlayPause.UseVisualStyleBackColor = true;
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // WeListenPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 96);
            this.Controls.Add(this.btnPlayPause);
            this.Controls.Add(this.btnOpenMedia);
            this.Name = "WeListenPlayer";
            this.Text = "WEListen Player";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WeListenPlayer_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenMedia;
        private System.Windows.Forms.Button btnPlayPause;
    }
}

