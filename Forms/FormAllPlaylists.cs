using MusicPlayer.Constants;
using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer.Forms
{
    public partial class FormAllPlaylists : Form
    {
        private PlaylistList playlistList;
        public FormAllPlaylists(PlaylistList playlistList)
        {
            InitializeComponent();
            this.playlistList = playlistList;
        }
        
        private void LoadPlaylists()
        {
            foreach(var playlist in playlistList.playlistList)
            {
                AddLabel(playlist.name, playlist.musicList.Count, playlist.isFavourite);
            }
        }
        public void AddLabel(string text, int trackAmount, bool isFavourite)
        {
            int id = flowLayoutPanelWithPlaylists.Controls.Count + 1;
            GroupBox gp = new GroupBox();
            Label trackString = new Label();
            Label trackAmountLabel = new Label();
            PictureBox favPicture = new PictureBox
            {
                Name = "pictureBoxFavourite",
                Size = new Size(20, 20),
                Location = new Point(150, 50)
            };
            favPicture.SizeMode = PictureBoxSizeMode.Zoom;

            if (isFavourite)
                favPicture.ImageLocation = (new ConstantPaths().redHeartImage);
            else
                favPicture.ImageLocation = (new ConstantPaths().greyHeartImage);

            trackString.Text = "Tracks: ";
            trackString.ForeColor = Color.White;
            trackString.Location = new Point(10, 80);
            trackString.Width = 80;
            trackAmountLabel.ForeColor = Color.White;

            if (trackAmount != 0)
                trackAmountLabel.Text = trackAmount.ToString();
            else
                trackAmountLabel.Text = "0";
            trackAmountLabel.Location = new Point(120, 80);

            gp.Controls.Add(trackString);
            gp.Controls.Add(trackAmountLabel);
            gp.Controls.Add(favPicture);

            gp.Size = new Size(200, 100);
            gp.Left = 10;
            gp.Text = text;
            gp.ForeColor = Color.White;
            gp.Font = new Font("Serif", 12, FontStyle.Bold);
            gp.BackColor = ThemeColor.PrimaryColor;
            flowLayoutPanelWithPlaylists.Controls.Add(gp);
        }

        private void FormAllPlaylists_Load(object sender, EventArgs e)
        {
            LoadPlaylists();
        }
    }
}
