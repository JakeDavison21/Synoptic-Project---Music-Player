
namespace Synoptic_Project___Music_Player
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.clmIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddToPlaylist = new System.Windows.Forms.Button();
            this.btnRemoveFromPlaylist = new System.Windows.Forms.Button();
            this.btnClearPlaylist = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSkipForward = new System.Windows.Forms.Button();
            this.btnSkipBack = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ofdBrowse = new System.Windows.Forms.OpenFileDialog();
            this.txtMediaFile = new System.Windows.Forms.TextBox();
            this.btnShuffle = new System.Windows.Forms.Button();
            this.pbCoverArt = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCreatePlaylist = new System.Windows.Forms.Button();
            this.btnLoadPlaylist = new System.Windows.Forms.Button();
            this.btnDbSearch = new System.Windows.Forms.Button();
            this.ofdBrowsePlaylists = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbCoverArt)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmIndex,
            this.clmFileName});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(482, 10);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(306, 295);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // clmIndex
            // 
            this.clmIndex.Text = "#";
            this.clmIndex.Width = 31;
            // 
            // clmFileName
            // 
            this.clmFileName.Text = "Name";
            this.clmFileName.Width = 270;
            // 
            // btnAddToPlaylist
            // 
            this.btnAddToPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddToPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToPlaylist.Location = new System.Drawing.Point(381, 120);
            this.btnAddToPlaylist.Name = "btnAddToPlaylist";
            this.btnAddToPlaylist.Size = new System.Drawing.Size(95, 31);
            this.btnAddToPlaylist.TabIndex = 2;
            this.btnAddToPlaylist.Text = "Add";
            this.btnAddToPlaylist.UseVisualStyleBackColor = true;
            this.btnAddToPlaylist.Click += new System.EventHandler(this.btnAddToPlaylist_Click);
            // 
            // btnRemoveFromPlaylist
            // 
            this.btnRemoveFromPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRemoveFromPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveFromPlaylist.Location = new System.Drawing.Point(381, 149);
            this.btnRemoveFromPlaylist.Name = "btnRemoveFromPlaylist";
            this.btnRemoveFromPlaylist.Size = new System.Drawing.Size(95, 31);
            this.btnRemoveFromPlaylist.TabIndex = 3;
            this.btnRemoveFromPlaylist.Text = "Remove";
            this.btnRemoveFromPlaylist.UseVisualStyleBackColor = true;
            this.btnRemoveFromPlaylist.Click += new System.EventHandler(this.btnRemoveFromPlaylist_Click);
            // 
            // btnClearPlaylist
            // 
            this.btnClearPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClearPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearPlaylist.Location = new System.Drawing.Point(381, 237);
            this.btnClearPlaylist.Name = "btnClearPlaylist";
            this.btnClearPlaylist.Size = new System.Drawing.Size(95, 31);
            this.btnClearPlaylist.TabIndex = 4;
            this.btnClearPlaylist.Text = "Clear";
            this.btnClearPlaylist.UseVisualStyleBackColor = true;
            this.btnClearPlaylist.Click += new System.EventHandler(this.btnClearPlaylist_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(381, 274);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(95, 31);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(12, 359);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(95, 31);
            this.btnPlay.TabIndex = 6;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.Enabled = false;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(330, 359);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(95, 31);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSkipForward
            // 
            this.btnSkipForward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSkipForward.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSkipForward.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSkipForward.Location = new System.Drawing.Point(220, 359);
            this.btnSkipForward.Name = "btnSkipForward";
            this.btnSkipForward.Size = new System.Drawing.Size(95, 31);
            this.btnSkipForward.TabIndex = 9;
            this.btnSkipForward.Text = "Skip >>";
            this.btnSkipForward.UseVisualStyleBackColor = true;
            this.btnSkipForward.Click += new System.EventHandler(this.btnSkipForward_Click);
            // 
            // btnSkipBack
            // 
            this.btnSkipBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSkipBack.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSkipBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSkipBack.Location = new System.Drawing.Point(119, 359);
            this.btnSkipBack.Name = "btnSkipBack";
            this.btnSkipBack.Size = new System.Drawing.Size(95, 31);
            this.btnSkipBack.TabIndex = 8;
            this.btnSkipBack.Text = "Skip <<";
            this.btnSkipBack.UseVisualStyleBackColor = true;
            this.btnSkipBack.Click += new System.EventHandler(this.btnSkipBack_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(693, 359);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 31);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ofdBrowse
            // 
            this.ofdBrowse.FileName = "openFileDialog1";
            // 
            // txtMediaFile
            // 
            this.txtMediaFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMediaFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMediaFile.Location = new System.Drawing.Point(482, 311);
            this.txtMediaFile.Name = "txtMediaFile";
            this.txtMediaFile.Size = new System.Drawing.Size(286, 22);
            this.txtMediaFile.TabIndex = 11;
            // 
            // btnShuffle
            // 
            this.btnShuffle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShuffle.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnShuffle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShuffle.Location = new System.Drawing.Point(448, 359);
            this.btnShuffle.Name = "btnShuffle";
            this.btnShuffle.Size = new System.Drawing.Size(95, 31);
            this.btnShuffle.TabIndex = 12;
            this.btnShuffle.Text = "Shuffle";
            this.btnShuffle.UseVisualStyleBackColor = true;
            this.btnShuffle.Click += new System.EventHandler(this.btnShuffle_Click);
            // 
            // pbCoverArt
            // 
            this.pbCoverArt.Location = new System.Drawing.Point(12, 10);
            this.pbCoverArt.Name = "pbCoverArt";
            this.pbCoverArt.Size = new System.Drawing.Size(363, 295);
            this.pbCoverArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbCoverArt.TabIndex = 13;
            this.pbCoverArt.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(767, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(21, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnCreatePlaylist
            // 
            this.btnCreatePlaylist.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCreatePlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreatePlaylist.Location = new System.Drawing.Point(381, 37);
            this.btnCreatePlaylist.Name = "btnCreatePlaylist";
            this.btnCreatePlaylist.Size = new System.Drawing.Size(95, 31);
            this.btnCreatePlaylist.TabIndex = 15;
            this.btnCreatePlaylist.Text = "Save Playlist";
            this.btnCreatePlaylist.UseVisualStyleBackColor = true;
            this.btnCreatePlaylist.Click += new System.EventHandler(this.btnCreatePlaylist_Click);
            // 
            // btnLoadPlaylist
            // 
            this.btnLoadPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLoadPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadPlaylist.Location = new System.Drawing.Point(381, 66);
            this.btnLoadPlaylist.Name = "btnLoadPlaylist";
            this.btnLoadPlaylist.Size = new System.Drawing.Size(95, 31);
            this.btnLoadPlaylist.TabIndex = 16;
            this.btnLoadPlaylist.Text = "Load Playlist";
            this.btnLoadPlaylist.UseVisualStyleBackColor = true;
            this.btnLoadPlaylist.Click += new System.EventHandler(this.btnLoadPlaylist_Click);
            // 
            // btnDbSearch
            // 
            this.btnDbSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDbSearch.Location = new System.Drawing.Point(381, 186);
            this.btnDbSearch.Name = "btnDbSearch";
            this.btnDbSearch.Size = new System.Drawing.Size(95, 45);
            this.btnDbSearch.TabIndex = 17;
            this.btnDbSearch.Text = "Search Database";
            this.btnDbSearch.UseVisualStyleBackColor = true;
            this.btnDbSearch.Click += new System.EventHandler(this.btnDbSearch_Click);
            // 
            // ofdBrowsePlaylists
            // 
            this.ofdBrowsePlaylists.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 402);
            this.Controls.Add(this.btnDbSearch);
            this.Controls.Add(this.btnLoadPlaylist);
            this.Controls.Add(this.btnCreatePlaylist);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pbCoverArt);
            this.Controls.Add(this.btnShuffle);
            this.Controls.Add(this.txtMediaFile);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSkipForward);
            this.Controls.Add(this.btnSkipBack);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnClearPlaylist);
            this.Controls.Add(this.btnRemoveFromPlaylist);
            this.Controls.Add(this.btnAddToPlaylist);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Media Player";
            ((System.ComponentModel.ISupportInitialize)(this.pbCoverArt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnAddToPlaylist;
        private System.Windows.Forms.Button btnRemoveFromPlaylist;
        private System.Windows.Forms.Button btnClearPlaylist;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSkipForward;
        private System.Windows.Forms.Button btnSkipBack;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.OpenFileDialog ofdBrowse;
        private System.Windows.Forms.TextBox txtMediaFile;
        private System.Windows.Forms.ColumnHeader clmIndex;
        private System.Windows.Forms.ColumnHeader clmFileName;
        private System.Windows.Forms.Button btnShuffle;
        private System.Windows.Forms.PictureBox pbCoverArt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCreatePlaylist;
        private System.Windows.Forms.Button btnLoadPlaylist;
        private System.Windows.Forms.Button btnDbSearch;
        private System.Windows.Forms.OpenFileDialog ofdBrowsePlaylists;
    }
}

