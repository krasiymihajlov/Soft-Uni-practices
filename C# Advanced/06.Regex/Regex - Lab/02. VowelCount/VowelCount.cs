namespace _02.VowelCount
{
    using System;
    using System.Text.RegularExpressions;

    public class VowelCount
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            string pattern = @"[AEOUYIaeouyi]";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            int count = matches.Count;

            Console.WriteLine($"Vowels: {count}");
        }
    }
}
