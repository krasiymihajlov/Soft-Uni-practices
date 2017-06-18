namespace _07.Population_Counter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DictLamdaLinqsExer
    {
        public static void Main()
        {
            var counter = new Dictionary<string, Dictionary<string, long>>();
            var line = Console.ReadLine();


            while (line != "report")
            {
                var separateLine = line.Split('|');

                var city = separateLine[0];
                var country = separateLine[1];
                var population = long.Parse(separateLine[2]);

                if (!counter.ContainsKey(country))
                {
                    counter[country] = new Dictionary<string, long>();
                }

                if(!counter[country].ContainsKey(city))
                {
                    counter[country][city] = population;
                }
                else
                {
                    counter[country][city] += population;
                }                

                line = Console.ReadLine();
            }

            foreach (var country in counter.OrderByDescending(x => x.Value.Sum(y => y.Value)))
            {
                var state = country.Key;
                var population = country.Value;

                var allPopulation = country.Value.Values.Sum();                         

                Console.WriteLine($"{state} (total population: {allPopulation})");

                foreach (var city in population.OrderByDescending(y => y.Value))
                {
                    var cityName = city.Key;
                    var cityPopulation = city.Value;

                    Console.WriteLine($"=>{cityName}: {cityPopulation}");
                }
            }
        }
    }
}
