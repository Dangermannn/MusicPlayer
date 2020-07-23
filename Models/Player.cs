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
        private Queue<string> _playlist;
        public static IWavePlayer player = new WaveOutEvent();

        public Player(List<MusicFile> playlist)
        {
            this._playlist = new Queue<string>();
            foreach (var item in playlist)
                if (item.state == CheckState.Checked)
                {
                    this._playlist.Enqueue(item.path.ToString());
                    Console.WriteLine("ADDING " + item.path.ToString() + "\tSTATE: " + item.state.ToString());
                }
            //this._playlist = new Queue<string>(playlist);
        }
        public Player()
        {
            this._playlist = new Queue<string>();
        }
        public Player(CheckedListBox playlist)
        {
            this._playlist = new Queue<string>();
            MessageBox.Show("CONSTRUCTOR: " + playlist.CheckedItems.Count);

            foreach(FileInfo song in playlist.CheckedItems)
            {
                this._playlist.Enqueue(song.ToString());
            }
        }

        public void PlayPlaylist()
        {
            MessageBox.Show("PLAYING ");
            if (this._playlist.Count < 1)
            {
                MessageBox.Show("PLAYLIST LESS THAN 1");
                return;
            }

            if(player != null)
            {
                player.Dispose();
                player = null;
            }
            player = new WaveOutEvent();
            var audioFilePath = _playlist.Dequeue();
            MessageBox.Show("DEQUING, playing " + audioFilePath.ToString());
            var fileWaveStream = new AudioFileReader(audioFilePath);
            player.Init(fileWaveStream);
            player.Play();
            MessageBox.Show("AFTER PLAY METHOD");
            /*
             */
             /*
            NAudio.Wave.WaveStream pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream
                                        (new NAudio.Wave.Mp3FileReader(_playlist.First()));
            var stream = new NAudio.Wave.BlockAlignReductionStream(pcm);
            var output = new NAudio.Wave.DirectSoundOut();
            output.Init(stream);
            output.Play();
            MessageBox.Show("STARTED PLAYING");
            */
        }

        public void PausePlaylist()
        {
            if (player != null)
                player.Pause();
        }
    }
}
