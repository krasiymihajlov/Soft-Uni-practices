namespace _08.ExtractQuotations
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractQuotations
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            string pattern = "\"(.*?)\"|\'(.*?)\'";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                if (match.Groups[1].Success)
                {
                    Console.WriteLine($"{match.Groups[1].Value}");
                }
                else
                {
                    Console.WriteLine($"{match.Groups[2].Value}");
                }
            }
        }
    }
}
