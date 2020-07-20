using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class AudioHandler
    {
        private readonly List<AudioFileReader> audios = new List<AudioFileReader>();
        //private readonly WaveOutEvent();

        public void playList()
        {
            foreach(AudioFileReader audio in audios)
            {
                //audio.pla
            }
        }
    }
}
