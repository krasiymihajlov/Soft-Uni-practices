namespace _05.ExtractEmail
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractEmail
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = "\\b(?<!-|_|\\.)[A-Za-z0-9][\\w-.]+@([A-Za-z-]+)(\\.[A-Za-z-]+)+";

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[0].Value);
            }
            
        }
    }
}
