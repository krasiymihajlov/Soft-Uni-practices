namespace _01.MatchFullName
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchFullName
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            string pattern = @"\b[A-Z][a-z]{1,}\s[A-Z][a-z]{1,}\b";
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
