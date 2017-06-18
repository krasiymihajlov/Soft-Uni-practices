namespace _04.CountSymbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountSymbols
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var dict = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                var currentChar = text[i];

                if(!dict.ContainsKey(currentChar))
                {
                    dict[currentChar] = 1; 
                }
                else
                {
                    dict[currentChar] += 1;
                }
            }

            foreach (var symbol in dict.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }

        }
    }
}
