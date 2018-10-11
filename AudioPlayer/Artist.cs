namespace AudioPlayer
{
    internal class Artist
    {
        private string _nameArtist;

        internal Artist(string nameArtist)
        {
            NameArtist = nameArtist;
        }

        public string NameArtist
        {
            get => _nameArtist;
            set => _nameArtist = value == "" ? "НЕТ ДАННЫХ" : value;
        }
    }
}