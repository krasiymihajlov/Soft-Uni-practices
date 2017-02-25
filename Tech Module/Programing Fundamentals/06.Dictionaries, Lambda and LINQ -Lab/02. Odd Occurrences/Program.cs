namespace _02.Odd_Occurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Dictionaries
    {
        public static void Main()
        {
            var sequenceOfWords = Console.ReadLine()
                .ToLower()
                .Split(' ')
                .ToList();

            var oddDict = new Dictionary<string, int>();

            foreach (var word in sequenceOfWords)
            {
                if (!oddDict.ContainsKey(word))
                {
                    oddDict[word] = 0;
                }
                oddDict[word]++;
            }

            var result = new List<string>();

            foreach (var item in oddDict)
            {
                if (item.Value % 2 != 0)
                {
                    result.Add(item.Key);
                }
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
