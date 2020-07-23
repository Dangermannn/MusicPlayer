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
        //public Player player;

        public List<System.IO.FileInfo> openedFiles;
        public List<MusicFile> musicFiles = new List<MusicFile>();
        public FormOpenedFiles(List<MusicFile> fileList)
        {
            InitializeComponent();
            this.musicFiles = fileList;
        }
        public void Play()
        {
            //player?.PlayPlaylist();
        }

        private void FormOpenedFiles_Load(object sender, EventArgs e)
        {
            foreach(var file in musicFiles)
                checkedListBoxWithMusicOpened.Items.Add(file.path.ToString().Split('\\').Last(), file.state);
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
