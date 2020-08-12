using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MusicPlayer
{
    public class MusicFile
    {
        [XmlElement("Path")]
        public string path { get; set; }

        [XmlElement("State")]
        public CheckState state { get; set; }

        public MusicFile() {
            state = CheckState.Checked;
        }
        public MusicFile(string path)
        {
            this.path = path;
            state = CheckState.Checked;
        }

        public MusicFile(string path, CheckState state)
        {
            this.path = path;
            this.state = state;
        }

    }
}
