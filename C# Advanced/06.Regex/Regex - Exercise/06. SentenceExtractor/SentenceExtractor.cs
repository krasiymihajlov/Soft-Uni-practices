namespace _06.SentenceExtractor
{
    using System;
    using System.Text.RegularExpressions;

    public class SentenceExtractor
    {
        public static void Main()
        {
            string kayWord = Console.ReadLine();
            string text = Console.ReadLine();
            string pattern = $"[^!?.]+\\b{kayWord}\\b[^!?.]+[?|!|.]"; 

            MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[0].Value);
            }
        }
    }
}
