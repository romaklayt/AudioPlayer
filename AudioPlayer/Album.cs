namespace AudioPlayer
{
    internal class Album
    {
        private string _nameAlbum;

        internal Album(string nameAlbum)
        {
            NameAlbum = nameAlbum;
        }

        public string NameAlbum
        {
            get => _nameAlbum;
            set => _nameAlbum = value == "" ? "НЕТ ДАННЫХ" : value;
        }
    }
}