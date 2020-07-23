using MusicPlayer.Forms;
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

namespace MusicPlayer
{
    public partial class Form1 : Form
    {
        private Player player;
        public static Color PrimaryColor { get; set; }
        public static Color SecondaryColor { get; set; }

        private Button _currentButton;
        private Random _random;
        private Form _activeForm;
        private int _tempIndex;

        private NAudio.Wave.BlockAlignReductionStream stream = null;
        private NAudio.Wave.DirectSoundOut output = null;

        private string _currentPlayingFilePath = string.Empty;
        private int _currentPlayingIndex = 0;
        
        private readonly List<MusicFile> musicFiles = new List<MusicFile>();

        public Form1()
        {
            InitializeComponent();
            HideSubMenuAtStart();
            _random = new Random();
        }
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

        private void OpenChildForm(Form childForm, object btnSender)
        {
            _activeForm?.Close();
            ActivateButton(btnSender);
            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelMainDesktop.Controls.Add(childForm);
            this.panelMainDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
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
            OpenChildForm(new Forms.FormOpenedFiles(this.musicFiles), sender);
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            if (player == null)
            {
                player = new Player(musicFiles);
                player.PlayPlaylist();
            }
            else
                player.ResumePlaylist();
            btnPlay.Visible = false;
            btnPause.Visible = true;
        }

        private void BtnPlayNextOne_Click(object sender, EventArgs e)
        {

            //btnPause.Visible = true;
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            if (player != null)
                player.PausePlaylist();
            btnPause.Visible = false;
            btnPlay.Visible = true;
        }

        private void PlayPreviousInQueue_Click(object sender, EventArgs e)
        {

        }      
        
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
            foreach(String file in open.FileNames)
            {
                MessageBox.Show(file);
                try
                {
                    musicFiles.Add(new MusicFile(new System.IO.FileInfo(file)));
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disc. Error message: " + ex.Message);
                }
            }
            OpenChildForm(new Forms.FormOpenedFiles(this.musicFiles), sender);         
        }

        #endregion

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
                        musicFiles.Add(new MusicFile(new System.IO.FileInfo(file)));
                    OpenChildForm(new Forms.FormOpenedFiles(this.musicFiles), sender);
                }
            }
        }
    }
}
