namespace _04.OnlineRadioDatabase
{
    using System;
    using System.Linq;

    public class InvalidSongLengthException : InvalidSongException
    {
        public InvalidSongLengthException(string artistName, string songName, string length, int minutes, int seconds)
            : base(artistName, songName, length, minutes, seconds)
        {

        }

        public override string Length
        {
            get { return base.Length; }
            set
            {
                string[] time = value.Split(new[] {':'}, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

                if (value.Length < 3 || value.Length > 20 || 
                    (!int.TryParse(time[0], out int minutes) && (!int.TryParse(time[1], out int seconds))))
                {
                    throw new ArgumentException("Invalid song length.");
                }

                base.Length = value;
            }
        }
    }
}
