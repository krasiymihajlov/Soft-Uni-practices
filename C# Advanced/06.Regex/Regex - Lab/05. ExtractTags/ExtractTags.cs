namespace _05.ExtractTags
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractTags
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            string pattern = "(<.*?>)";
            Regex regex = new Regex(pattern);

            while (text != "END")
            {
                MatchCollection matches = regex.Matches(text);

                foreach (Match match in matches)
                {
                    Console.WriteLine($"{match.Groups[1].Value}");
                }

                text = Console.ReadLine();
            }
        }
    }
}
