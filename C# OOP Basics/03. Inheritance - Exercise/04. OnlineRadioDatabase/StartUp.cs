namespace _04.OnlineRadioDatabase
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] song = Console.ReadLine().Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

                try
                {
                    if (song.Length != 3)
                    {
                        throw new ArgumentException("Invalid song.");
                    }
                
                    InvalidSongException songValidation = new InvalidSongException(song[0], song[1], song[2], 
                        int.Parse(song[2].Split(':').First()), int.Parse(song[2].Split(':').Last()));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            
        }
    }
}
