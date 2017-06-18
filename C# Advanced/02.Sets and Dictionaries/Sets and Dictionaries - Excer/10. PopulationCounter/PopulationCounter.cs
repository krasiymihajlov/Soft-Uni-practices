namespace _10.PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PopulationCounter
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var statistic = new Dictionary<string, Dictionary<string, long>>();

            while(input != "report")
            {
                var line = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                var city = line[0];
                var countrys = line[1];
                var population = long.Parse(line[2]);

                if(!statistic.ContainsKey(countrys))
                {
                    statistic[countrys] = new Dictionary<string, long>();
                }

                var country = statistic[countrys];

                if(!country.ContainsKey(city))
                {
                    country[city] = population;
                }
                else
                {
                    country[city] += population;
                }

                input = Console.ReadLine();
            }

            foreach (var kvp in statistic.OrderByDescending(y => y.Value.Values.Sum()))
            {
                var country = kvp.Key;
                var value = kvp.Value;

                Console.WriteLine($"{country} (total population: {value.Values.Sum()})");
                Console.WriteLine($"{string.Join("\r\n", value.OrderByDescending(y => y.Value).Select(x => $"=>{x.Key}: {x.Value}"))}");
            }
        }
    }
}
