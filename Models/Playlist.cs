using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MusicPlayer.Models
{
    public class Playlist
    {
        [XmlElement("PlaylistName")]
        public string name { get; set; }

        public List<MusicFile> musicList { get; set; }
        [XmlElement("Favourite")]
        public bool isFavourite { get; set; }
        public Playlist()
        {
            this.name = "Not named";
            this.musicList = new List<MusicFile>();
        }
        
        public Playlist(string name)
        {
            this.name = name;
            this.musicList = new List<MusicFile>();
            this.isFavourite = false;
        }

        public Playlist(List<MusicFile> items)
        {
            this.name = "Not named";
            this.musicList = items;
            this.isFavourite = false;
        }

        public Playlist(List<MusicFile> items, string name)
        {
            this.name = name;
            this.musicList = items;
            this.isFavourite = false;
        }

        public Playlist(List<MusicFile> items, string name, bool isFavourite)
        {
            this.name = name;
            this.musicList = items;
            this.isFavourite = isFavourite;
        }
    }
}
