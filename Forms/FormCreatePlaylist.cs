using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer.Forms
{
    public partial class FormCreatePlaylist : Form
    {
        public string playlistName { get; set; }
        public FormCreatePlaylist()
        {
            InitializeComponent();
            btnCancel.DialogResult = DialogResult.Cancel;
            btnConfirm.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            playlistName = string.Empty;
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBoxPlaylistName.Text))
                MessageBox.Show("Text field cannot be empty", "Error");
            else
            {
                playlistName = textBoxPlaylistName.Text;
                this.Close();
            }
        }

    }
}
