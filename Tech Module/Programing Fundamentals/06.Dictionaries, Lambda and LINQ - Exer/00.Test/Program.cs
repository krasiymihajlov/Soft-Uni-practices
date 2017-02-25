namespace _07.Population_Counter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DictLamdaLinqsExer
    {
        public static void Main()
        {
            var counter = new SortedDictionary<string, SortedDictionary<string, List<long>>>();
            var line = Console.ReadLine();


            while (line != "report")
            {
                var separateLine = line.Split('|');

                var city = separateLine[0];
                var country = separateLine[1];
                var population = long.Parse(separateLine[2]);

                if (!counter.ContainsKey(country))
                {
                    counter[country] = new SortedDictionary<string, List<long>>();
                }

                if (!counter[country].ContainsKey(city))
                {
                    counter[country][city] = new List<long>();
                    counter[country][city].Add(population);
                }
                else
                {
                    counter[country][city].Add(population);
                }

                line = Console.ReadLine();
            }

            foreach (var country in counter.OrderByDescending(x => x.Value.Sum(y => y.Value.Sum())))
            {
                var state = country.Key;
                var population = country.Value;

                var allPopulation = population.Values.Sum(y => y.Sum());

                Console.WriteLine($"{state} (total population: {allPopulation})");

                foreach (var city in population.Reverse())
                {
                    var cityName = city.Key;
                    var cityPopulation = city.Value.Sum();

                    Console.WriteLine($"=>{cityName}: {cityPopulation}");
                }
            }
        }
    }
}
