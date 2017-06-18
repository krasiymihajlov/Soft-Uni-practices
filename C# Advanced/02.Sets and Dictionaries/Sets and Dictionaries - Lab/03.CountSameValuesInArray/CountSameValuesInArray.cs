namespace _03.CountSameValuesInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountSameValuesInArray
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var counter = new Dictionary<double, int>();

            for (int i = 0; i < inputLine.Length; i++)
            {
                if(!counter.ContainsKey(inputLine[i]))
                {
                    counter.Add(inputLine[i], 1);
                }
                else
                {
                    counter[inputLine[i]] += 1; 
                }
            }

            foreach (var number in counter.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }

          
        }
    }
}
