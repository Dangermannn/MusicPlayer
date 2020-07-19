using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private CheckedListBox openedMusic = new CheckedListBox();
       // private readonly ListBox openedMusic = new ListBox();
        public Form1()
        {
            InitializeComponent();
            hideSubMenuAtStart();
            random = new Random();          
        }
        private void hideSubMenuAtStart()
        {
            panelPlaylistsSubMenu.Visible = false;
            panelMediaSubMenu.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelMediaSubMenu.Visible)
                panelMediaSubMenu.Visible = false;
            if (panelPlaylistsSubMenu.Visible)
                panelPlaylistsSubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                hideSubMenu();
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
                    Console.WriteLine("DISABLING");
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

        private void btnMedia_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            showSubMenu(panelMediaSubMenu);
        }

        private void btnPlaylists_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            showSubMenu(panelPlaylistsSubMenu);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnOpenedMusic_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormOpenedFiles(this.openedMusic), sender);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (output != null)
            {
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing) output.Pause();
                else if (output.PlaybackState == NAudio.Wave.PlaybackState.Paused) output.Play();
            }
        }

        private void btnPlayNextOne_Click(object sender, EventArgs e)
        {

        }

        private void playPreviousInQueue_Click(object sender, EventArgs e)
        {

        }

        private void btnOpenFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            open.Title = "Please select files to open *.mp3/*.wav";
            open.Filter = "Audio File (*.mp3;*.wav)|*.mp3;*.wav;";
            List<System.IO.FileInfo> fileList = new List<System.IO.FileInfo>();
            if (open.ShowDialog() != DialogResult.OK) return;
            
            foreach(String file in open.FileNames)
            {
                try
                {
                    fileList.Add(new System.IO.FileInfo(file));
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disc. Error message: " + ex.Message);
                }
            }
            openedMusic.DataSource = fileList;
            OpenChildForm(new Forms.FormOpenedFiles(this.openedMusic), sender);
            
            DisposeWave();
            NAudio.Wave.WaveStream pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream
                                                    (new NAudio.Wave.Mp3FileReader(open.FileName));
            stream = new NAudio.Wave.BlockAlignReductionStream(pcm);
            output = new NAudio.Wave.DirectSoundOut();
            output.Init(stream);
            output.Play();
            
        }

        private void DisposeWave()
        {
            if(output != null)
            {
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing) output.Stop();
                output.Dispose();
                output = null;
            }
            if(stream != null)
            {
                stream.Dispose();
                stream = null;
            }
        }
    }
}
