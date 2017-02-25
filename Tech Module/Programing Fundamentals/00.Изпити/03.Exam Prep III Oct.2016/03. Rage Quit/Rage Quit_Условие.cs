namespace _03.Rage_Quit
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Linq;

    public class RageQuir
    {
        public static void Main()
        {
            var text = Console.ReadLine().ToUpper();

            var pattern = @"(\D+)(\d+)";
            var regex = new Regex(pattern);
            var uniqueSymbols = new List<char>();
            var output = new StringBuilder();

            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                var symbols = match.Groups[1].ToString();
                var count = int.Parse(match.Groups[2].ToString());

                for (int i = 0; i < symbols.Length; i++)
                {
                    if (!uniqueSymbols.Contains(symbols[i]))
                    {
                        uniqueSymbols.Add(symbols[i]);
                    }
                }

                for (int i = 0; i < count; i++)
                {
                    output.Append(symbols);
                }
            }

            Console.WriteLine($"Unique symbols used: {output.ToString().Distinct().Count()}");
            Console.WriteLine($"{string.Join("", output.ToString())}");

        }

    }
}
