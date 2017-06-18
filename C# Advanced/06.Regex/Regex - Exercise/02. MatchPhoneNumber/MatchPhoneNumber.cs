namespace _02.MatchPhoneNumber
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchPhoneNumber
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            string pattern = @"^\+359(\s|-)2\1\d{3}\1\d{4}$";
            Regex regex = new Regex(pattern);

            while (text != "end")
            {
                Match match = regex.Match(text);

                if (match.Success)
                {
                    Console.WriteLine(match.Groups[0].Value);
                }

                text = Console.ReadLine();
            }
        }
    }
}
