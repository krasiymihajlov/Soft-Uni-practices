namespace _04.OnlineRadioDatabase
{
    public class InvalidSongException
    {
        private string artistName;
        private string songName;
        private string length;
        private int minutes;
        private int seconds;

        public InvalidSongException(string artistName, string songName, string length, int minutes, int seconds)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.Length = length;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public virtual string ArtistName
        {
            get { return this.artistName; }
            set
            {
                this.artistName = value;
            }
        }

        public virtual string SongName
        {
            get { return this.songName; }
            set { this.songName = value; }
        }
        public virtual string Length
        {
            get { return this.length; }
            set { this.length = value; }
        }

        public virtual int Minutes
        {
            get { return this.minutes; }
            set { this.minutes = value; }
        }

        public virtual int Seconds
        {
            get { return this.seconds; }
            set { this.seconds = value; }
        }
    }
}
