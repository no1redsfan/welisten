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
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.lbxPlayList = new System.Windows.Forms.ListBox();
            this.btnAddToPlayList = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Enabled = false;
            this.btnPlayPause.Location = new System.Drawing.Point(203, 336);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(67, 23);
            this.btnPlayPause.TabIndex = 1;
            this.btnPlayPause.Text = "Play";
            this.btnPlayPause.UseVisualStyleBackColor = true;
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // lbxPlayList
            // 
            this.lbxPlayList.FormattingEnabled = true;
            this.lbxPlayList.Location = new System.Drawing.Point(12, 41);
            this.lbxPlayList.Name = "lbxPlayList";
            this.lbxPlayList.Size = new System.Drawing.Size(258, 290);
            this.lbxPlayList.TabIndex = 2;
            this.lbxPlayList.SelectedIndexChanged += new System.EventHandler(this.lbxPlayList_SelectedIndexChanged);
            // 
            // btnAddToPlayList
            // 
            this.btnAddToPlayList.Location = new System.Drawing.Point(13, 12);
            this.btnAddToPlayList.Name = "btnAddToPlayList";
            this.btnAddToPlayList.Size = new System.Drawing.Size(125, 23);
            this.btnAddToPlayList.TabIndex = 3;
            this.btnAddToPlayList.Text = "Add MP3 to Play List";
            this.btnAddToPlayList.UseVisualStyleBackColor = true;
            this.btnAddToPlayList.Click += new System.EventHandler(this.btnAddToPlayList_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(12, 336);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(277, 41);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(75, 23);
            this.btnMoveUp.TabIndex = 5;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(277, 307);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(75, 23);
            this.btnMoveDown.TabIndex = 6;
            this.btnMoveDown.Text = "Move Down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(12, 366);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 7;
            // 
            // WeListenPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 381);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnAddToPlayList);
            this.Controls.Add(this.lbxPlayList);
            this.Controls.Add(this.btnPlayPause);
            this.Name = "WeListenPlayer";
            this.Text = "WEListen Player";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WeListenPlayer_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.ListBox lbxPlayList;
        private System.Windows.Forms.Button btnAddToPlayList;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Label lblMessage;
    }
}

