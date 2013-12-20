namespace WeListenPlayer1._0
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
            this.lbxPlayList = new System.Windows.Forms.ListBox();
            this.btnAddToPlayList = new System.Windows.Forms.Button();
            this.btnRemoveFromPlayList = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnClearPlayList = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxPlayList
            // 
            this.lbxPlayList.FormattingEnabled = true;
            this.lbxPlayList.Location = new System.Drawing.Point(13, 34);
            this.lbxPlayList.Name = "lbxPlayList";
            this.lbxPlayList.Size = new System.Drawing.Size(163, 290);
            this.lbxPlayList.TabIndex = 0;
            this.lbxPlayList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxPlayList_MouseDoubleClick);
            // 
            // btnAddToPlayList
            // 
            this.btnAddToPlayList.Location = new System.Drawing.Point(13, 5);
            this.btnAddToPlayList.Name = "btnAddToPlayList";
            this.btnAddToPlayList.Size = new System.Drawing.Size(163, 23);
            this.btnAddToPlayList.TabIndex = 1;
            this.btnAddToPlayList.Text = "Add to PlayList";
            this.btnAddToPlayList.UseVisualStyleBackColor = true;
            this.btnAddToPlayList.Click += new System.EventHandler(this.btnAddToPlayList_Click);
            // 
            // btnRemoveFromPlayList
            // 
            this.btnRemoveFromPlayList.Location = new System.Drawing.Point(12, 330);
            this.btnRemoveFromPlayList.Name = "btnRemoveFromPlayList";
            this.btnRemoveFromPlayList.Size = new System.Drawing.Size(163, 23);
            this.btnRemoveFromPlayList.TabIndex = 2;
            this.btnRemoveFromPlayList.Text = "Remove from Play List";
            this.btnRemoveFromPlayList.UseVisualStyleBackColor = true;
            this.btnRemoveFromPlayList.Click += new System.EventHandler(this.btnRemoveFromPlayList_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Enabled = false;
            this.btnPrevious.Location = new System.Drawing.Point(214, 357);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(34, 23);
            this.btnPrevious.TabIndex = 3;
            this.btnPrevious.Text = "<<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Enabled = false;
            this.btnPlay.Location = new System.Drawing.Point(335, 357);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 4;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(416, 357);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 5;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(497, 357);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(33, 23);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnClearPlayList
            // 
            this.btnClearPlayList.Location = new System.Drawing.Point(13, 361);
            this.btnClearPlayList.Name = "btnClearPlayList";
            this.btnClearPlayList.Size = new System.Drawing.Size(163, 23);
            this.btnClearPlayList.TabIndex = 7;
            this.btnClearPlayList.Text = "Clear Play List";
            this.btnClearPlayList.UseVisualStyleBackColor = true;
            this.btnClearPlayList.Click += new System.EventHandler(this.btnClearPlayList_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(254, 357);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 396);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnClearPlayList);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnRemoveFromPlayList);
            this.Controls.Add(this.btnAddToPlayList);
            this.Controls.Add(this.lbxPlayList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxPlayList;
        private System.Windows.Forms.Button btnAddToPlayList;
        private System.Windows.Forms.Button btnRemoveFromPlayList;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClearPlayList;
        private System.Windows.Forms.Button btnStop;
    }
}

