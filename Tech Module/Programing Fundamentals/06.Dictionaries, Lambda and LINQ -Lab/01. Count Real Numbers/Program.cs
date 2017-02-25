namespace _01.Count_Real_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DictionariesLab
    {
        public static void Main()
        {
            var realNumbers = Console.ReadLine()
                .Split(' ')
                .Select(x => double.Parse(x))
                .ToList();       

            var counts = new SortedDictionary<double, int>();

            foreach (var number in realNumbers)
            {                
                if (!counts.ContainsKey(number))
                {
                    counts[number] = 0;
                }

                counts[number]++;
            }

            foreach (var num in counts.Keys)
            {
                Console.WriteLine($"{num} -> {counts[num]}");
            }
        }
    }
}
