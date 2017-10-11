namespace _04.OnlineRadioDatabase
{
    using System;
    using System.Linq;

    public class InvalidSongSecondsException : InvalidSongLengthException
    {
        private int seconds;

        public InvalidSongSecondsException(string artistName, string songName, string length, int minutes, int seconds)
            :base(artistName, songName, length, minutes, seconds)
        {
            this.Seconds = seconds;
        }
        public override int Seconds
        {
            get { return this.seconds; }
            set
            {
                string[] time = base.Length.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
                int second = int.Parse(time[1]);

                if (second < 0 || second > 59)
                {
                    throw new ArgumentException("Song seconds should be between 0 and 59.");
                }

                this.seconds = second;
            }
        }
    }
}
