using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer.Forms
{
    public partial class FormOpenedFiles : Form
    {
        public Player player;

        public List<System.IO.FileInfo> openedFiles;
        public List<MusicFile> musicFiles = new List<MusicFile>();
        //public FormOpenedFiles(List<System.IO.FileInfo> fileList)
        public FormOpenedFiles(List<MusicFile> fileList)
        {
            InitializeComponent();
            //this.openedFiles = fileList;
            this.musicFiles = fileList;


            //checkedListBoxWithMusicOpened.DataSource = openedMusic.DataSource;
            //checkedListBoxWithMusicOpened.DataSource = fileList;
            //openedMusic.Items.Add("TEST ADD", true);
            //..MessageBox.Show(openedMusic);
            //player = new Player(openedMusic);
            //checkedListBoxWithMusicOpened = openedMusic;
            //MessageBox.Show("FORM 2: " + openedMusic.Items.Count.ToString());
        }
        public void Play()
        {
            player?.PlayPlaylist();
        }

        private void FormOpenedFiles_Load(object sender, EventArgs e)
        {
            foreach(var file in musicFiles)
            {
                checkedListBoxWithMusicOpened.Items.Add(file.path, file.state);
            }
            if (checkedListBoxWithMusicOpened.Items.Count >= 1)
                MessageBox.Show("STORING: " + checkedListBoxWithMusicOpened.Items.Count + " ITEMS");
            else
                MessageBox.Show("EMPTY STORAGE");
            /*
            foreach (var file in openedFiles)
                checkedListBoxWithMusicOpened.Items.Add(file, true);
            if (checkedListBoxWithMusicOpened.Items.Count >= 1)
                MessageBox.Show("STORING: " + checkedListBoxWithMusicOpened.Items.Count + " ITEMS");
            else
                MessageBox.Show("EMPTY STORAGE");
                */
        }

        private void checkedListBoxWithMusicOpened_MouseClick(object sender, MouseEventArgs e)
        {
            for(int i = 0; i < checkedListBoxWithMusicOpened.Items.Count; i++)
            {
                musicFiles[i].state = checkedListBoxWithMusicOpened.GetItemCheckState(i);
            }
        }
        /*
private void checkedListBoxWithMusicOpened_SelectedIndexChanged(object sender, EventArgs e)
{
if (player != null)
player = null;
player = new Player(checkedListBoxWithMusicOpened);
}
*/

    }
}
