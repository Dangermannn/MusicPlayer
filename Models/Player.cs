using MusicPlayer.Models;
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
        private Playlist _playlist;
        private static IWavePlayer _player = new WaveOutEvent();
        private string _currentPlaying;
        private int _currentPlayingIndex;


        public Player(Playlist playlist)
        {
            this._playlist = playlist;
            this._currentPlayingIndex = 0;
        }
        public Player()
        {
            _playlist = new Playlist();
        }

        private void Update()
        {
            
        }

        public void PlayBeforeCurrentPlaying()
        {
            if(_player != null)
            {
                this.Update();
                if (_playlist == null)
                    return;

                if (_playlist.musicList.First().path.ToString() == _currentPlaying)
                    return;

                _currentPlayingIndex = _currentPlayingIndex == 0 ? _currentPlayingIndex = _playlist.musicList.Count - 1 : _currentPlayingIndex -= 1;
                var fileWaveStream = new AudioFileReader(_playlist.musicList[_currentPlayingIndex].path.ToString());
                _player.Dispose();
                _player.Init(fileWaveStream);
                _player.Play();
            }
        }

        public void PlayPlaylist()
        {
            if (this._playlist.musicList.Count < 1)
                return;

            if(_player != null)
            {
                _player.Dispose();
                _player = null;
            }
            _player = new WaveOutEvent();
            Console.WriteLine("BEFORE: " + _currentPlayingIndex.ToString());
            _currentPlaying = _playlist.musicList[_currentPlayingIndex].path.ToString();
            _currentPlayingIndex++;
            var fileWaveStream = new AudioFileReader(_currentPlaying);
            Console.WriteLine("\tAFTER: " + _currentPlayingIndex.ToString());
            _player.Init(fileWaveStream);
            _player.Play();
        }

        public void ResumePlaylist()
        {
            if (_player != null)
                _player.Play();
        }
        public void PlayNext()
        {
            if (_player != null)
            {
                if(_playlist.musicList.Count == 0)
                {
                    MessageBox.Show("Error", "Playlist is empty!", MessageBoxButtons.OK);
                    return;
                }
                _currentPlayingIndex = (_currentPlayingIndex + 1) % _playlist.musicList.Count;
                _currentPlaying = _playlist.musicList[_currentPlayingIndex].path.ToString();
                var fileWaveStream = new AudioFileReader(_currentPlaying);
                _player.Dispose();
                _player.Init(fileWaveStream);
                _player.Play();
            }else
                MessageBox.Show("Error", "Player has not been initialized", MessageBoxButtons.OK);

        }

        public void PausePlaylist()
        {
            if (_player != null)
                _player.Pause();
        }
    }
}
