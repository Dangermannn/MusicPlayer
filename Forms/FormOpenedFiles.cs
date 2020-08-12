using MusicPlayer.Models;
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
        public Playlist playlist = new Playlist();
        public FormOpenedFiles(Playlist fileList)
        {
            InitializeComponent();
            this.playlist= fileList;
        }

        private void FormOpenedFiles_Load(object sender, EventArgs e)
        {
            foreach(var file in playlist.musicList)
                checkedListBoxWithMusicOpened.Items.Add(file.path?.ToString().Split('\\').Last(), file.state);
        }

        private void checkedListBoxWithMusicOpened_MouseClick(object sender, MouseEventArgs e)
        {
            for(int i = 0; i < checkedListBoxWithMusicOpened.Items.Count; i++)
                playlist.musicList[i].state = checkedListBoxWithMusicOpened.GetItemCheckState(i);
        }
    }
}
