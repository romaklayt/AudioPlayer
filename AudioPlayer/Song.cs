namespace AudioPlayer
{
    internal class Song
    {
        private readonly Album _album;
        private readonly Artist _artist;
        private readonly Chart _chartPosition;
        private readonly string _genre;
        private  string _title;
        private Lyrics _lyrics;


        internal Song()
        {
            _title = ("НЕТ ДАННЫХ");
            _album = new Album("НЕТ ДАННЫХ");
            _artist = new Artist("НЕТ ДАННЫХ");
            _genre = "НЕТ ДАННЫХ";
            _chartPosition = new Chart("НЕТ ДАННЫХ");
        }

        internal Song(string title, Artist artist) : this()
        {
            _title = title;
            _artist = artist;
            _album = new Album(_title);
        }

        internal Song(string title, Artist artist, string genre) : this(title, artist)
        {
            _genre = genre;
        }

        internal Song(string title, Artist artist, string genre, Chart chartPosition) : this(title, artist, genre)
        {
            _chartPosition = chartPosition;
        }

        internal Song(string title, Artist artist, string genre, Chart chartPosition, Album album)
        {
            _title = title;
            _artist = artist;
            _album = album;
            _genre = genre;
            _chartPosition = chartPosition;
        }

        public string title => _title;

        public string album => _album.NameAlbum;

        public string genre => _genre;

        public string artist => _artist.NameArtist;

        public string chart
        {
            get => _chartPosition.PosChart;
            set => _chartPosition.PosChart = value;
        }

        public override string ToString()
        {
            return title + "\t" + artist + "\t" + album + "\t" + chart;
        }
    }
}