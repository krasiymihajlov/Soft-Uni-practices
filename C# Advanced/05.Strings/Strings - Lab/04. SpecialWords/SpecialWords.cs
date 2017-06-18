namespace _04.SpecialWords
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class SpecialWords
    {
        public static void Main()
        {
            string[] specialWords = Console.ReadLine()
                .Split(new[] { ' ', '(', ')', '[', ']', '<', '>', ',', '-', '!', '?' },
                    StringSplitOptions.RemoveEmptyEntries);

            string[] text = Console.ReadLine()
                .Split(new[] { ' ', '(', ')', '[', ']', '<', '>', ',', '-', '!', '?' },
                StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> countSpecialWord = new Dictionary<string, int>();

            for (int i = 0; i < specialWords.Length; i++)
            {
                string pattern = specialWords[i];
                if (!countSpecialWord.ContainsKey(pattern))
                {
                    countSpecialWord[pattern] = 0;
                }

                for (int j = 0; j < text.Length; j++)
                {
                    if (pattern.Equals(text[j]))
                    {
                        countSpecialWord[pattern] += 1;
                    }
                }
            }

            Console.WriteLine(string.Join("\r\n", countSpecialWord.Select(x => $"{x.Key} - {x.Value}")));
        }
    }
}
