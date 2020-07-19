﻿using System;
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
    public partial class FormOpenedFiles : Form
    {
        public FormOpenedFiles(CheckedListBox openedMusic)
        {
            InitializeComponent();
            checkedListBoxWithMusicOpened.DataSource = openedMusic.DataSource;
            
        }
    }
}
