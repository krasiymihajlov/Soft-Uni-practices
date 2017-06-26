namespace _08.MapDistricts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MapDistricts
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
            double filterPopulation = double.Parse(Console.ReadLine());
            Dictionary<string, List<double>> dict = new Dictionary<string, List<double>>();

            for (int i = 0; i < input.Length; i++)
            {
                string[] split = input[i].Split(new char[] {':'}, StringSplitOptions.RemoveEmptyEntries);

                if (split.Length != 2)
                {
                    continue;
                }

                string city = split[0];
                double population = double.Parse(split[1]);

                if (!dict.ContainsKey(city))
                {
                    dict[city] = new List<double>();
                }

                dict[city].Add(population);
            }

            foreach (var kvp in dict.OrderByDescending(p => p.Value.Sum()))
            {
                string city = kvp.Key;
                var value = kvp.Value.OrderByDescending(p => p);

                if (filterPopulation <= value.Sum())
                {
                    Console.Write($"{city}: ");
                    Console.WriteLine(string.Join(" ", value.Take(5).Select(p => $"{p}")));
                }
            }
        }
    }
}
