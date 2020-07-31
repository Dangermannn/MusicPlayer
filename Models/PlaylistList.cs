using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MusicPlayer.Models
{
    [XmlRoot("PlaylistList")]
    public class PlaylistList
    {
        [XmlElement("Playlist")]
        public List<Playlist> playlistList { get; set; }
        public PlaylistList()
        {
            playlistList = new List<Playlist>();
        }

        public PlaylistList(List<Playlist> items)
        {
            playlistList = items;
        }
    }
}
