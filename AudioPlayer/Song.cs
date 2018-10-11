namespace AudioPlayer
{
    internal class Song
    {
        private readonly Album _album;
        private readonly Artist _artist;
        private readonly Chart _chartPosition;
        private readonly Genre _genre;
        private readonly Title _title;
        private Lyrics _lyrics;


        internal Song()
        {
            _title = new Title("НЕТ ДАННЫХ");
            _album = new Album("НЕТ ДАННЫХ");
            _artist = new Artist("НЕТ ДАННЫХ");
            _genre = new Genre("НЕТ ДАННЫХ");
            _chartPosition = new Chart("НЕТ ДАННЫХ");
        }

        internal Song(Title title, Artist artist) : this()
        {
            _title = title;
            _artist = artist;
            _album = new Album(_title.NameTrack);
        }

        internal Song(Title title, Artist artist, Genre genre) : this(title, artist)
        {
            _genre = genre;
        }

        internal Song(Title title, Artist artist, Genre genre, Chart chartPosition) : this(title, artist, genre)
        {
            _chartPosition = chartPosition;
        }

        internal Song(Title title, Artist artist, Genre genre, Chart chartPosition, Album album)
        {
            _title = title;
            _artist = artist;
            _album = album;
            _genre = genre;
            _chartPosition = chartPosition;
        }

        public string title => _title.NameTrack;

        public string album => _album.NameAlbum;

        public string genre => _genre.nameGenre;

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