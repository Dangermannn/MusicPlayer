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
        public static Color PrimaryColor { get; set; }
        public static Color SecondaryColor { get; set; }

        private Button currentButton;
        private Random random;
        private Form activeForm;
        private int tempIndex;

        private NAudio.Wave.BlockAlignReductionStream stream = null;
        private NAudio.Wave.DirectSoundOut output = null;

        private string currentPlayingFilePath = string.Empty;
        private int currentPlayingIndex = 0;
        
        private readonly List<MusicFile> musicFiles = new List<MusicFile>();

       // private readonly ListBox openedMusic = new ListBox();
        public Form1()
        {
            InitializeComponent();
            HideSubMenuAtStart();
            random = new Random();
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
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
                index = random.Next(ThemeColor.ColorList.Count);
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if(btnSender != null)
            {
                if(currentButton != (Button)btnSender)
                {
                    DisableButtons();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            activeForm?.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
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
            //OpenChildForm(new Forms.FormOpenedFiles(this.openedMusic), sender);
            
            
            OpenChildForm(new Forms.FormOpenedFiles(this.musicFiles), sender);
            //OpenChildForm(new Forms.FormOpenedFiles(this.openedFilesList), sender);
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            /*
            if (output != null)
            {
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing) output.Pause();
                else if (output.PlaybackState == NAudio.Wave.PlaybackState.Paused) output.Play();
            }
             */
            //FormOpenedFiles openedFilesForm = new Forms.FormOpenedFiles(this.openedMusic);


            //FormOpenedFiles openedFilesForm = new Forms.FormOpenedFiles(this.openedFilesList);
            FormOpenedFiles openedFilesForm = new Forms.FormOpenedFiles(this.musicFiles);
            //OpenChildForm(openedFilesForm, sender);
            //OpenChildForm(new Forms.FormOpenedFiles(this.openedMusic), sender);

            openedFilesForm.Play();
            btnPlay.Visible = false;
            btnPause.Visible = true;
        }

        private void BtnPlayNextOne_Click(object sender, EventArgs e)
        {

            //btnPause.Visible = true;
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            btnPause.Visible = false;
            btnPlay.Visible = true;
        }

        private void PlayPreviousInQueue_Click(object sender, EventArgs e)
        {
            /*
             
            foreach(string fileName in openedMusic.Items)
            {
                NAudio.Wave.WaveStream pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream
                                        (new NAudio.Wave.Mp3FileReader(fileName));
                stream = new NAudio.Wave.BlockAlignReductionStream(pcm);
                output = new NAudio.Wave.DirectSoundOut();
                output.Init(stream);
                output.Play();
            }
             */
            /*
            DisposeWave();
            NAudio.Wave.WaveStream pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream
                                                    (new NAudio.Wave.Mp3FileReader(open.FileName));
            stream = new NAudio.Wave.BlockAlignReductionStream(pcm);
            output = new NAudio.Wave.DirectSoundOut();
            output.Init(stream);
            output.Play();
            btnPlay.Visible = false;
            */
        }
        private void DisposeWave()
        {
            if (output != null)
            {
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing) output.Stop();
                output.Dispose();
                output = null;
            }
            if (stream != null)
            {
                stream.Dispose();
                stream = null;
            }
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
                    //openedMusic.DataSource = files.ToList();
                    foreach (var file in files)
                        musicFiles.Add(new MusicFile(new System.IO.FileInfo(file)));
                    OpenChildForm(new Forms.FormOpenedFiles(this.musicFiles), sender);
                }
            }
        }
    }
}
