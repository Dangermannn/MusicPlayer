using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public class MusicFile
    {
        public System.IO.FileInfo path { get; set; }
        public CheckState state { get; set; }
        public MusicFile() {
            state = CheckState.Checked;
        }
        public MusicFile(System.IO.FileInfo path)
        {
            this.path = path;
            state = CheckState.Checked;
        }

    }
}
