using System;
using System.Collections.Generic;

namespace AudioPlayer
{
    internal class Playlist
    {
        private readonly List<Song> _playList;

        internal Playlist()
        {
            _playList = new List<Song>();
        }

        internal Playlist(List<Song> alltracks) : this()
        {
            Console.WriteLine("Enter genre:");
            var enterGenre = Console.ReadLine();
            foreach (var song in alltracks)
                if (enterGenre.ToUpper() == song.genre)
                    _playList.Add(song);
        }

        public string this[int i] => _playList[i].title;

        internal void AddSong(params Song[] songs)
        {
            foreach (var song in songs) _playList.Add(song);
        }

        internal void Writedata()
        {
            foreach (var song in _playList) Console.WriteLine(song.title + "\t" + song.artist + "\t" + song.album);
        }
    }
}