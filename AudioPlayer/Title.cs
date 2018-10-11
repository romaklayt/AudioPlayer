namespace AudioPlayer
{
    internal class Title
    {
        private string _nameTrack;

        internal Title(string nameTrack)
        {
            NameTrack = nameTrack;
        }

        public string NameTrack
        {
            get => _nameTrack;
            set => _nameTrack = value == "" ? "НЕТ ДАННЫХ" : value;
        }
    }
}