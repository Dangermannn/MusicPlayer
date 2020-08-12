using MusicPlayer.Constants;
using MusicPlayer.DataAccess;
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
    public delegate void ClickingPlaylistEventHandler(Playlist playlistName);
    public partial class FormAllPlaylists : Form
    {
        public event ClickingPlaylistEventHandler playlistEventHandler;
        public Playlist playlistToOpen;
        private PlaylistList playlistList;
        public FormAllPlaylists(PlaylistList playlistList)
        {
            InitializeComponent();
            this.playlistList = playlistList;
        }

        public void SendClickingPlaylistEvent()
        {
            if (playlistEventHandler != null)
                playlistEventHandler(playlistToOpen);
        }

        private void SaveToXML()
        {
            XmlImportExport<PlaylistList> xmlImportExport = new XmlImportExport<PlaylistList>();
            xmlImportExport.SerializeToXml(playlistList, "playlists.xml" +
                "", "PlaylistList");
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
            Panel panel = new Panel();
            Label titleLabel = new Label();
            Label trackStringLabel = new Label();
            Label trackAmountLabel = new Label();
            PictureBox favPicture = new PictureBox
            {
                Name = "pictureBoxFavourite",
                Size = new Size(20, 20),
                Location = new Point(150, 50)
            };
            favPicture.SizeMode = PictureBoxSizeMode.Zoom;
            favPicture.Click += new EventHandler(this.ChangeFavourite_Click);

            if (isFavourite)
                favPicture.ImageLocation = (new ConstantPaths().redHeartImage);
            else
                favPicture.ImageLocation = (new ConstantPaths().greyHeartImage);

            titleLabel.Text = text;
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(10, 10);
            
            trackStringLabel.Text = "Tracks: ";
            trackStringLabel.ForeColor = Color.White;
            trackStringLabel.Location = new Point(10, 80);
            trackStringLabel.Width = 80;

            trackAmountLabel.ForeColor = Color.White;

            if (trackAmount != 0)
                trackAmountLabel.Text = trackAmount.ToString();
            else
                trackAmountLabel.Text = "0";
            trackAmountLabel.Location = new Point(120, 80);

            panel.Controls.Add(trackStringLabel);
            panel.Controls.Add(trackAmountLabel);
            panel.Controls.Add(titleLabel);
            panel.Controls.Add(favPicture);
            panel.Size = new Size(200, 100);
            panel.Left = 10;
            panel.Name = text;
            panel.ForeColor = Color.White;
            panel.Font = new Font("Serif", 12, FontStyle.Bold);
            panel.BackColor = ThemeColor.PrimaryColor;
            flowLayoutPanelWithPlaylists.Controls.Add(panel);
            panel.Click += new EventHandler(this.OpenPlaylist_Click);
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.BringToFront();
            childForm.Show();
        }

        private void ChangeFavourite_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            Control control = pb.Parent;
            var itemToChange = playlistList.playlistList.Where(x => x.name == control.Name).ToList();
            if(itemToChange.Count > 0)
            {
                var indexOfItemToChange = playlistList.playlistList.IndexOf(itemToChange[0]);
                if (playlistList.playlistList[indexOfItemToChange].isFavourite)
                    playlistList.playlistList[indexOfItemToChange].isFavourite = false;
                else
                    playlistList.playlistList[indexOfItemToChange].isFavourite = true;

                SaveToXML();
                flowLayoutPanelWithPlaylists.Controls.Clear(); 
                LoadPlaylists();
            }
            else
                MessageBox.Show("Error occured while changing isFavourite status. Cannot find the playlist", "Error", MessageBoxButtons.OK);
        }
        public void OpenPlaylist_Click(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            var playlist = playlistList.playlistList.Where(x => x.name == p.Name).ToList();
            if (playlist?.Count > 0)
            {
                playlistToOpen = playlist[0];
                MessageBox.Show("Added playlist" + playlist[0].GetType(), "Error");
            }
            else
                playlistToOpen = new Playlist();

            SendClickingPlaylistEvent();
        }

        private void FormAllPlaylists_Load(object sender, EventArgs e)
        {
            LoadPlaylists();
        }
    }
}
