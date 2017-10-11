namespace _04.OnlineRadioDatabase
{
    using System;
    using System.Linq;

    public class InvalidSongMinutesException : InvalidSongLengthException
    {
        private int minutes;

        public InvalidSongMinutesException(string artistName, string songName, string length, int minutes, int seconds)
            :base(artistName, songName, length, minutes, seconds)
        {
            this.Minutes = minutes;
        }
        public override int Minutes
        {
            get { return this.minutes; }
            set
            {
                string[] time = base.Length.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
                int minute = int.Parse(time[0]);

                if (minute < 0 || minute > 14)
                {
                   throw new ArgumentException("Song minutes should be between 0 and 14.");
                }

                this.minutes = minute;
            }
        }
    }
}
