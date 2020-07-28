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
    public partial class FormAllPlaylists : Form
    {
        public FormAllPlaylists()
        {
            InitializeComponent();
            AddLabel("test");
            AddLabel("test2");
            AddLabel("test2");
        }
        public void AddLabel(string text)
        {
            int id = flowLayoutPanelWithPlaylists.Controls.Count + 1;
            Label l = new Label();
            l.Name = "label" + id.ToString();
            l.Text = text;
            l.ForeColor = Color.White;
            l.BackColor = Color.Blue;
            l.Font = new Font("Serif", 24, FontStyle.Bold);
            l.Width = 170;
            l.Height = 80;
            l.TextAlign = ContentAlignment.MiddleCenter;
            l.Margin = new Padding(5);
            flowLayoutPanelWithPlaylists.Controls.Add(l);
        }
    }
}
