namespace _04.OnlineRadioDatabase
{
    using System;

    public class InvalidArtistNameException : InvalidSongException
    {
        public InvalidArtistNameException(string artistName, string songName, string length, int minutes, int seconds)
            : base(artistName, songName, length, minutes, seconds)
        {
            
        }

        public override string ArtistName
        {
            get { return base.ArtistName; }
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw  new ArgumentException("Artist name should be between 3 and 20 symbols.");
                }

                base.ArtistName = value;
            }
        }
    }
}
