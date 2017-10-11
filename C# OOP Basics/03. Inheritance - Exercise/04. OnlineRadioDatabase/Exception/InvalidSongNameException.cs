namespace _04.OnlineRadioDatabase
{
    using System;

    public class InvalidSongNameException : InvalidSongException
    {
        public InvalidSongNameException(string artistName, string songName, string length, int minutes, int seconds)
            : base(artistName, songName, length, minutes, seconds)
        {

        }

        public override string SongName
        {
            get { return base.SongName; }
            set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new ArgumentException("Song name should be between 3 and 30 symbols.");
                }

                base.SongName = value;
            }
        }
    }
}
