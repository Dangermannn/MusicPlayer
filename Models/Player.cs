using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public class Player
    {
        private Queue<string> playlist;
        public static IWavePlayer player = new WaveOutEvent();

        public Player(List<string> playlist)
        {
            this.playlist = new Queue<string>(playlist);
        }
        public Player()
        {
            this.playlist = new Queue<string>();
        }
        public Player(CheckedListBox playlist)
        {
            this.playlist = new Queue<string>();
            MessageBox.Show("CONSTRUCTOR: " + playlist.CheckedItems.Count);

            foreach(FileInfo song in playlist.CheckedItems)
            {
                this.playlist.Enqueue(song.ToString());
            }
        }

        public void PlayPlaylist()
        {
            MessageBox.Show("PLAYING ");
            if (this.playlist.Count < 1)
            {
                MessageBox.Show("PLAYLIST LESS THAN 1");
                return;
            }

            /*
            if(player != null)
            {
                player.Dispose();
                player = null;
            }
            player = new WaveOutEvent();
            var audioFilePath = playlist.Dequeue();
            var fileWaveStream = new AudioFileReader(audioFilePath);
            player.Init(fileWaveStream);
            player.Play();
            MessageBox.Show("AFTER PLAY METHOD");
             */

            NAudio.Wave.WaveStream pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream
                                        (new NAudio.Wave.Mp3FileReader(playlist.First()));
            var stream = new NAudio.Wave.BlockAlignReductionStream(pcm);
            var output = new NAudio.Wave.DirectSoundOut();
            output.Init(stream);
            output.Play();
            MessageBox.Show("STARTED PLAYING");
        }
    }
}
