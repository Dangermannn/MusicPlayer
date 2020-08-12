using MusicPlayer.DataAccess;
using MusicPlayer.Forms;
using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MusicPlayer
{
    public partial class Form1 : Form
    {
        private Player player;
        private Button _currentButton;
        private Random _random;
        private Form _activeForm;
        private int _tempIndex;
        
        private Playlist currentOpenedPlaylist = new Playlist();
        private PlaylistList playlistList = new PlaylistList();

        public Form1()
        {
            ThemeColor.PrimaryColor = Color.FromArgb(39, 39, 58);
            InitializeComponent();
            HideSubMenuAtStart();
            checkBoxSelectAll.Visible = false;
            _random = new Random();
        }

        #region Menu workflow
        private void HideSubMenuAtStart()
        {
            panelPlaylistsSubMenu.Visible = false;
            panelMediaSubMenu.Visible = false;
        }

        private void HideSubMenu()
        {
            if (panelMediaSubMenu.Visible)
                panelMediaSubMenu.Visible = false;
            if (panelPlaylistsSubMenu.Visible)
                panelPlaylistsSubMenu.Visible = false;
        }

        private void ShowSubMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private Color SelectThemeColor()
        {
            int index = _random.Next(ThemeColor.ColorList.Count);
            while (_tempIndex == index)
                index = _random.Next(ThemeColor.ColorList.Count);
            _tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if(btnSender != null)
            {
                if(_currentButton != (Button)btnSender)
                {
                    DisableButtons();
                    Color color = SelectThemeColor();
                    _currentButton = (Button)btnSender;
                    _currentButton.BackColor = color;
                    _currentButton.ForeColor = Color.White;
                    _currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelCard.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }

        private void DisableButtons()
        {
            foreach(Control btn in panel1.Controls)
            {
                if(btn.GetType() == typeof(Button))
                {
                    btn.BackColor = Color.FromArgb(25, 25, 65);
                    btn.ForeColor = Color.Gainsboro;
                    btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        public void OpenPlaylistFromReceivingEvent(Playlist playlist)
        {
            currentOpenedPlaylist = playlist;
            OpenChildForm(new Forms.FormOpenedFiles(currentOpenedPlaylist), null);
        }
        public delegate void DelegateOpenChildForm(Form childForm, object btnSender);
        private void OpenChildForm(Form childForm, object btnSender)
        {
            _activeForm?.Close();
            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelMainDesktop.Controls.Add(childForm);
            this.panelMainDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        #endregion

        private void SaveToXML()
        {
            XmlImportExport<PlaylistList> xmlImportExport = new XmlImportExport<PlaylistList>();
            xmlImportExport.SerializeToXml(playlistList, "playlists.xml", "PlaylistList");
        }
        private void BtnPlaylists_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ShowSubMenu(panelPlaylistsSubMenu);
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void BtnOpenedMusic_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormOpenedFiles(currentOpenedPlaylist), sender);
        }

        #region Lower panel to play/pause/move to next one/before one music
        private void BtnPlay_Click(object sender, EventArgs e)
        {
            if (player == null)
            {
                player = new Player(currentOpenedPlaylist);
                player.PlayPlaylist();
            }
            else
                player.ResumePlaylist();
            btnPlay.Visible = false;
            btnPause.Visible = true;
        }

        private void BtnPlayNextOne_Click(object sender, EventArgs e)
        {
            player.PlayNext();
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            player?.PausePlaylist();
            btnPause.Visible = false;
            btnPlay.Visible = true;
        }

        private void PlayPreviousInQueue_Click(object sender, EventArgs e)
        {
            player?.PlayBeforeCurrentPlaying();
        }
        #endregion

        #region Media
        private void BtnMedia_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ShowSubMenu(panelMediaSubMenu);
        }
        private void BtnOpenFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Please select files to open *.mp3/*.wav",
                Filter = "Audio File (*.mp3;*.wav)|*.mp3;*.wav;"
            };
            if (open.ShowDialog() != DialogResult.OK) return;
            checkBoxSelectAll.Visible = true;
            foreach(String file in open.FileNames)
            {
                try
                {
                    currentOpenedPlaylist.musicList.Add(new MusicFile(new System.IO.FileInfo(file).ToString()));
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disc. Error message: " + ex.Message);
                }
            }   
            OpenChildForm(new Forms.FormOpenedFiles(currentOpenedPlaylist), sender);         
        }


        private void BtnOpenFolder_Click(object sender, EventArgs e)
        {
            using(var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    var files = Directory.EnumerateFiles(fbd.SelectedPath, "*.*", SearchOption.AllDirectories)
                        .Where(s => s.EndsWith(".mp3") || s.EndsWith(".wav"));
                    foreach (var file in files)
                        currentOpenedPlaylist.musicList.Add(new MusicFile(new System.IO.FileInfo(file).ToString()));
                    checkBoxSelectAll.Visible = true;
                    OpenChildForm(new Forms.FormOpenedFiles(currentOpenedPlaylist), sender);
                }
            }
        }
        #endregion
        #region Playlists
        private void btnCreatePlaylist_Click(object sender, EventArgs e)
        {
            using (var form = new FormCreatePlaylist())
            {
                var result = form.ShowDialog();
                if(result == DialogResult.OK)
                {
                    if (string.IsNullOrWhiteSpace(form.playlistName))
                        return;
                    var isItem = playlistList.playlistList.Where(x => x.name == form.playlistName).ToList();
                    if (isItem.Count != 0)
                    {
                        MessageBox.Show("There's a playlist with the same name. Try other name", "Error", MessageBoxButtons.OK);
                        return;
                    }
                            
                    Playlist p = new Playlist(form.playlistName);
                    playlistList.playlistList.Add(p);
                    var formAllPlaylists = new FormAllPlaylists(playlistList);
                    SaveToXML();
                    OpenChildForm(formAllPlaylists, sender);
                }
            }

        }

        private void btnFavouritePlaylists_Click(object sender, EventArgs e)
        {
            PlaylistList temp = new PlaylistList();
            foreach(var playlist in playlistList.playlistList)
            {
                if (playlist.isFavourite)
                    temp.playlistList.Add(playlist);
            }
            OpenChildForm(new FormAllPlaylists(temp), sender);
        }

        private void btnShowAllPlaylists_Click(object sender, EventArgs e)
        {             
            XmlImportExport<PlaylistList> xmlImport = new XmlImportExport<PlaylistList>();
            playlistList = xmlImport.DeserializeXml("playlists.xml", "PlaylistList");
            var form = new Forms.FormAllPlaylists(playlistList);
            form.playlistEventHandler += OpenPlaylistFromReceivingEvent;
            OpenChildForm(form, null);
            Application.DoEvents();
        }
        #endregion
        
        private void Form1_Load(object sender, EventArgs e)
        {
            XmlImportExport<PlaylistList> xmlImport = new XmlImportExport<PlaylistList>();
            playlistList = xmlImport.DeserializeXml("playlists.xml", "PlaylistList");
            var form = new Forms.FormAllPlaylists(playlistList);
            form.playlistEventHandler += OpenPlaylistFromReceivingEvent;
            OpenChildForm(form, null);
            Application.DoEvents();
        }

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSelectAll.Checked)
                foreach (var song in currentOpenedPlaylist.musicList)
                    song.state = CheckState.Checked;
            else
                foreach (var song in currentOpenedPlaylist.musicList)
                    song.state = CheckState.Unchecked;
        }
    }
}
