using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace AudioPlayer
{
    //add duration
    internal class Core
    {
        private List<Song> _alltracks;
        private List<Song> _chart;
        
        private bool _isPlaying;
        private bool _locked;
        private Song[] _newForPlaylist;
        private Playlist _playList;
        private Song PlayingSong;

        internal Core()
        {
            _alltracks = new List<Song>();
            PullData();
        }

        internal void PullData()
        {
            try
            {
                var path = @"C:\Users\Рома\source\repos\AudioPlayer\AudioPlayer\Database.txt";

                foreach (var line in File.ReadLines(path))
                {
                    var data = line.Split(new[] {'\t'}, StringSplitOptions.RemoveEmptyEntries);
                    _alltracks.Add(new Song((data[1]), new Artist(data[2]), new Genre(data[3]),
                        new Chart(data[0])));
                }
            }
            catch (DirectoryNotFoundException directoryNotFoundException)
            {
                Console.WriteLine("Error:\t" + directoryNotFoundException.Message);
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                Console.WriteLine("Error:\t" + fileNotFoundException.Message);
            }

            Shuffle();

            //  SortByTitle();
            // AddNewSongInLibrary();
            Play();



            //Writealltracks();
            //  Writealltracks();
            // CreatePlaylistByGenre();
            //  Play();
            // Writealltracks();
            //   CreateChart();
            //            AddNewTrackInPlaylist();
            //
            //            Writealltracks();
            //
            //            WritePlaylist();
        }

        internal void Writealltracks()
        {
            foreach (var song in _alltracks) Console.WriteLine(song);
        }

        internal void WritePlaylist()
        {
            _playList.Writedata();
        }

        internal void CreatePlaylistByGenre()
        {
            _playList = new Playlist(_alltracks);
        }

        internal void AddNewTrackInPlaylist()
        {
            var i = 0;
            Console.WriteLine("Введите количество треков");
            var amount = int.Parse(Console.ReadLine());
            _newForPlaylist = new Song[amount];
            do
            {
                NewTrack(out var name, out var artist, out var chart, out var album, out var genre);

                _newForPlaylist[i++] = new Song((name), new Artist(artist), new Genre(genre),
                    new Chart(chart), new Album(album));
            } while (amount > i);

            _playList = _playList ?? new Playlist();
            _playList.AddSong(_newForPlaylist);
        }

        internal void AddNewSongInLibrary()
        {
            NewTrack(out var name, out var artist, out var chart, out var album, out var genre);

            _alltracks.Add(new Song((name), new Artist(artist), new Genre(genre),
                new Chart(chart), new Album(album)));
        }

        private static void NewTrack(out string name, out string artist, out string chart, out string album,
            out string genre)
        {
            Console.WriteLine("Введите название трека");
            name = Console.ReadLine();
            Console.WriteLine("Введите Имя артиста");
            artist = Console.ReadLine();
            Console.WriteLine("Введите позицию в чарте");
            chart = Console.ReadLine();
            Console.WriteLine("Введите название альбома");
            album = Console.ReadLine();
            Console.WriteLine("Введите жанр");
            genre = Console.ReadLine();
        }

        internal int NowTrack()
        {
            Console.WriteLine("Введите номер трека");
            int num;
            int.TryParse(Console.ReadLine(), out num);
            return num;
        }

        internal void Play()
        {
            /* if (_locked != true)
                 _isPlaying = true;
             else
                 return true;

             var number = NowTrack();
             if ((number == 0) | (number == null)) number = 1;

             PlayingSong = _alltracks[number - 1];
             return _playList != null;
             */
            var number = NowTrack();
            PlayingSong = _alltracks[number - 1];
            if ((number == 0) | (number == null) | (number > _alltracks.Count)) number = 1;
            do
            {
                if (_alltracks != null)
                {
                    Console.WriteLine("Now Playing:\t" + PlayingSong + "\n");

                    WriteLyrics(number, false);
                    number++;
                }

                Thread.Sleep(1000);
                PlayingSong = _alltracks[number];
            } while (number < _alltracks.Count - 1);
        }

        internal bool Stop()
        {
            if (_locked != true)
                _isPlaying = false;
            else
                return true;
            var number = NowTrack();
            PlayingSong = _alltracks[number];
            return _playList != null;
        }

        internal void Lock()
        {
            _locked = true;
        }

        internal void Unlock()
        {
            _locked = false;
        }

        internal void CreateChart()
        {
            _chart = new List<Song>();
            foreach (var alltrack in _alltracks)
                _chart.Add(new Song((alltrack.title), new Artist(alltrack.artist), new Genre(alltrack.genre),
                    new Chart(alltrack.chart), new Album(alltrack.album)));


            foreach (var song in _alltracks) Console.WriteLine(song);
        }

        internal void SortChart()
        {
            _alltracks = new List<Song>(_alltracks.OrderBy(s => s.chart, new ComparerChart()));
        }

        internal void WriteLyrics(int number, bool loop)
        {
            string name;
            var i = 0;
            name = _alltracks[number - 1].title;
            i = loop ? 1 : 5;
            var res = new Lyrics().Dlyrics(name).Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);
            if (res[0] == "Lyrics no found")
            {
                Console.WriteLine(res[0]);
                Console.WriteLine();
                return;
            }

            for (var j = 0; j < i; j++) Console.WriteLine(res[j]);

            Console.WriteLine();
        }

        public void Shuffle()
        {
            var rand = new Random();
            for (var i = 0; i < _alltracks.Count; i++) _alltracks[rand.Next(0, _alltracks.Count)] = _alltracks[i];
        }

        public void SortByTitle()
        {
            _alltracks = new List<Song>(_alltracks.OrderBy(s => s.title));
            foreach (var song in _alltracks) Console.WriteLine(song);
        }
    }
}