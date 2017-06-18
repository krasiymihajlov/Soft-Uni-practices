using System.Linq;
using System.Text;

namespace _08.ExtractHyperlinks
{
    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;


    public class ExtractHyperlinks
    {
        public static void Main()
        {
            string line = Console.ReadLine();
            string pattern = @"<a\s+[^>]*?href\s*=(.*?)>.*?<\s*\/\s*a\s*>";
            Regex regex = new Regex(pattern);
            StringBuilder sb = new StringBuilder();

            while (line != "END")
            {
                sb.Append(line).Append(" ");
                line = Console.ReadLine();
            }

            MatchCollection matches = regex.Matches(sb.ToString());

            foreach (Match match in matches)
            {
                string currentMatch = match.Groups[1].Value.Trim();

                if (currentMatch[0] == '"')
                {
                    Console.WriteLine(currentMatch.Split(new[] { '"' }, StringSplitOptions.RemoveEmptyEntries).First());
                }
                else if (currentMatch[0] == '\'')
                {
                    Console.WriteLine(currentMatch.Split(new[] { '\'' }, StringSplitOptions.RemoveEmptyEntries).First());
                }
                else
                {
                    Console.WriteLine(currentMatch.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).First());
                }
            }
        }
    }
}
