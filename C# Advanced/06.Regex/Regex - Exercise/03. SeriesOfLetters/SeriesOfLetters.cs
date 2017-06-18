namespace _03.SeriesOfLetters
{
    using System;
    using System.Text.RegularExpressions;

    public class SeriesOfLetters
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            string pattern = @"([A-Za-z])\1+";
            Regex regex = new Regex(pattern);

            Match match = regex.Match(text);

            while (match.Success)
            {
                string currentMatch = match.Groups[0].Value;
                int currentIndex = text.IndexOf(currentMatch);
                string raplacedSymbol = currentMatch.Substring(0, 1);
                text = text.Substring(0, currentIndex) + raplacedSymbol + text.Substring(currentIndex + currentMatch.Length);
                
                match = regex.Match(text);
            }

            Console.WriteLine(text);
        }
    }
}
