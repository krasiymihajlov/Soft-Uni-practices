namespace _04.ExtractIntegerNumbers
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractIntegerNumbers
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            
            string pattern = @"([0-9]+)";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                string number = match.Groups[1].Value;
                Console.WriteLine(number);
            }
        }
    }
}
