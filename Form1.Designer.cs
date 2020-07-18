namespace MusicPlayer
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
            this.btnAbout = new System.Windows.Forms.Button();
            this.panelCard = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelCurrentPlaying = new System.Windows.Forms.Panel();
            this.btnFavouritePlaylists = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelPlaylistsSubMenu = new System.Windows.Forms.Panel();
            this.btnShowAllPlaylists = new System.Windows.Forms.Button();
            this.btnCreatePlaylist = new System.Windows.Forms.Button();
            this.btnPlaylists = new System.Windows.Forms.Button();
            this.panelMediaSubMenu = new System.Windows.Forms.Panel();
            this.btnOpenedMusic = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnOpenFiles = new System.Windows.Forms.Button();
            this.btnMedia = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelMainDesktop = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelCard.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelPlaylistsSubMenu.SuspendLayout();
            this.panelMediaSubMenu.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAbout
            // 
            this.btnAbout.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Monospac821 BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAbout.Location = new System.Drawing.Point(0, 394);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(200, 60);
            this.btnAbout.TabIndex = 3;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelCard.Controls.Add(this.lblTitle);
            this.panelCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCard.Location = new System.Drawing.Point(200, 0);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(628, 50);
            this.panelCard.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Monospac821 BT", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblTitle.Location = new System.Drawing.Point(296, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(54, 22);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Home";
            // 
            // panelCurrentPlaying
            // 
            this.panelCurrentPlaying.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.panelCurrentPlaying.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCurrentPlaying.Location = new System.Drawing.Point(200, 394);
            this.panelCurrentPlaying.Name = "panelCurrentPlaying";
            this.panelCurrentPlaying.Size = new System.Drawing.Size(628, 96);
            this.panelCurrentPlaying.TabIndex = 2;
            // 
            // btnFavouritePlaylists
            // 
            this.btnFavouritePlaylists.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFavouritePlaylists.FlatAppearance.BorderSize = 0;
            this.btnFavouritePlaylists.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFavouritePlaylists.Font = new System.Drawing.Font("Monospac821 BT", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFavouritePlaylists.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnFavouritePlaylists.Location = new System.Drawing.Point(0, 35);
            this.btnFavouritePlaylists.Name = "btnFavouritePlaylists";
            this.btnFavouritePlaylists.Size = new System.Drawing.Size(200, 35);
            this.btnFavouritePlaylists.TabIndex = 2;
            this.btnFavouritePlaylists.Text = "Favourite playlists";
            this.btnFavouritePlaylists.UseVisualStyleBackColor = true;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(200, 50);
            this.panelLogo.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelPlaylistsSubMenu);
            this.panel1.Controls.Add(this.btnPlaylists);
            this.panel1.Controls.Add(this.panelMediaSubMenu);
            this.panel1.Controls.Add(this.btnMedia);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 344);
            this.panel1.TabIndex = 2;
            // 
            // panelPlaylistsSubMenu
            // 
            this.panelPlaylistsSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(65)))));
            this.panelPlaylistsSubMenu.Controls.Add(this.btnShowAllPlaylists);
            this.panelPlaylistsSubMenu.Controls.Add(this.btnFavouritePlaylists);
            this.panelPlaylistsSubMenu.Controls.Add(this.btnCreatePlaylist);
            this.panelPlaylistsSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPlaylistsSubMenu.Location = new System.Drawing.Point(0, 235);
            this.panelPlaylistsSubMenu.Name = "panelPlaylistsSubMenu";
            this.panelPlaylistsSubMenu.Size = new System.Drawing.Size(200, 113);
            this.panelPlaylistsSubMenu.TabIndex = 3;
            // 
            // btnShowAllPlaylists
            // 
            this.btnShowAllPlaylists.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShowAllPlaylists.FlatAppearance.BorderSize = 0;
            this.btnShowAllPlaylists.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAllPlaylists.Font = new System.Drawing.Font("Monospac821 BT", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAllPlaylists.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnShowAllPlaylists.Location = new System.Drawing.Point(0, 70);
            this.btnShowAllPlaylists.Name = "btnShowAllPlaylists";
            this.btnShowAllPlaylists.Size = new System.Drawing.Size(200, 35);
            this.btnShowAllPlaylists.TabIndex = 1;
            this.btnShowAllPlaylists.Text = "Show all playlists";
            this.btnShowAllPlaylists.UseVisualStyleBackColor = true;
            // 
            // btnCreatePlaylist
            // 
            this.btnCreatePlaylist.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCreatePlaylist.FlatAppearance.BorderSize = 0;
            this.btnCreatePlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatePlaylist.Font = new System.Drawing.Font("Monospac821 BT", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreatePlaylist.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnCreatePlaylist.Location = new System.Drawing.Point(0, 0);
            this.btnCreatePlaylist.Name = "btnCreatePlaylist";
            this.btnCreatePlaylist.Size = new System.Drawing.Size(200, 35);
            this.btnCreatePlaylist.TabIndex = 0;
            this.btnCreatePlaylist.Text = "Create playlist";
            this.btnCreatePlaylist.UseVisualStyleBackColor = true;
            // 
            // btnPlaylists
            // 
            this.btnPlaylists.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPlaylists.FlatAppearance.BorderSize = 0;
            this.btnPlaylists.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlaylists.Font = new System.Drawing.Font("Monospac821 BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlaylists.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPlaylists.Location = new System.Drawing.Point(0, 175);
            this.btnPlaylists.Name = "btnPlaylists";
            this.btnPlaylists.Size = new System.Drawing.Size(200, 60);
            this.btnPlaylists.TabIndex = 2;
            this.btnPlaylists.Text = "Playlists";
            this.btnPlaylists.UseVisualStyleBackColor = true;
            this.btnPlaylists.Click += new System.EventHandler(this.btnPlaylists_Click);
            // 
            // panelMediaSubMenu
            // 
            this.panelMediaSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(65)))));
            this.panelMediaSubMenu.Controls.Add(this.btnOpenedMusic);
            this.panelMediaSubMenu.Controls.Add(this.btnOpenFolder);
            this.panelMediaSubMenu.Controls.Add(this.btnOpenFiles);
            this.panelMediaSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMediaSubMenu.Location = new System.Drawing.Point(0, 60);
            this.panelMediaSubMenu.Name = "panelMediaSubMenu";
            this.panelMediaSubMenu.Size = new System.Drawing.Size(200, 115);
            this.panelMediaSubMenu.TabIndex = 1;
            // 
            // btnOpenedMusic
            // 
            this.btnOpenedMusic.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOpenedMusic.FlatAppearance.BorderSize = 0;
            this.btnOpenedMusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenedMusic.Font = new System.Drawing.Font("Monospac821 BT", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenedMusic.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnOpenedMusic.Location = new System.Drawing.Point(0, 70);
            this.btnOpenedMusic.Name = "btnOpenedMusic";
            this.btnOpenedMusic.Size = new System.Drawing.Size(200, 35);
            this.btnOpenedMusic.TabIndex = 2;
            this.btnOpenedMusic.Text = "Opened music";
            this.btnOpenedMusic.UseVisualStyleBackColor = true;
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOpenFolder.FlatAppearance.BorderSize = 0;
            this.btnOpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFolder.Font = new System.Drawing.Font("Monospac821 BT", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFolder.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnOpenFolder.Location = new System.Drawing.Point(0, 35);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(200, 35);
            this.btnOpenFolder.TabIndex = 1;
            this.btnOpenFolder.Text = "Open folder";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            // 
            // btnOpenFiles
            // 
            this.btnOpenFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOpenFiles.FlatAppearance.BorderSize = 0;
            this.btnOpenFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFiles.Font = new System.Drawing.Font("Monospac821 BT", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFiles.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnOpenFiles.Location = new System.Drawing.Point(0, 0);
            this.btnOpenFiles.Name = "btnOpenFiles";
            this.btnOpenFiles.Size = new System.Drawing.Size(200, 35);
            this.btnOpenFiles.TabIndex = 0;
            this.btnOpenFiles.Text = "Open files";
            this.btnOpenFiles.UseVisualStyleBackColor = true;
            // 
            // btnMedia
            // 
            this.btnMedia.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMedia.FlatAppearance.BorderSize = 0;
            this.btnMedia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedia.Font = new System.Drawing.Font("Monospac821 BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedia.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMedia.Location = new System.Drawing.Point(0, 0);
            this.btnMedia.Name = "btnMedia";
            this.btnMedia.Size = new System.Drawing.Size(200, 60);
            this.btnMedia.TabIndex = 0;
            this.btnMedia.Text = "Media";
            this.btnMedia.UseVisualStyleBackColor = true;
            this.btnMedia.Click += new System.EventHandler(this.btnMedia_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btnAbout);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 490);
            this.panelMenu.TabIndex = 0;
            // 
            // panelMainDesktop
            // 
            this.panelMainDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainDesktop.Location = new System.Drawing.Point(200, 50);
            this.panelMainDesktop.Name = "panelMainDesktop";
            this.panelMainDesktop.Size = new System.Drawing.Size(628, 344);
            this.panelMainDesktop.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MusicPlayer.Properties.Resources.cat_no_bg;
            this.pictureBox1.Location = new System.Drawing.Point(3, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 490);
            this.Controls.Add(this.panelMainDesktop);
            this.Controls.Add(this.panelCurrentPlaying);
            this.Controls.Add(this.panelCard);
            this.Controls.Add(this.panelMenu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.panelLogo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelPlaylistsSubMenu.ResumeLayout(false);
            this.panelMediaSubMenu.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelCurrentPlaying;
        private System.Windows.Forms.Button btnFavouritePlaylists;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelPlaylistsSubMenu;
        private System.Windows.Forms.Button btnShowAllPlaylists;
        private System.Windows.Forms.Button btnCreatePlaylist;
        private System.Windows.Forms.Button btnPlaylists;
        private System.Windows.Forms.Panel panelMediaSubMenu;
        private System.Windows.Forms.Button btnOpenedMusic;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnOpenFiles;
        private System.Windows.Forms.Button btnMedia;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelMainDesktop;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

