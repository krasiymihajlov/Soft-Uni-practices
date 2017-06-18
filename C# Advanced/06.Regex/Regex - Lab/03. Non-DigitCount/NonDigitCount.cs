namespace _03.Non_DigitCount
{
    using System;
    using System.Text.RegularExpressions;

    public class NonDigitCount
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            string pattern = @"[^0-9]";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            int count = matches.Count;

            Console.WriteLine($"Non-digits: {count}");
        }
    }
}
