namespace _13.SrabskoUnleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SrabskoUnleashed
    {
        public static void Main()
        {
            var line = Console.ReadLine();
            var concert = new Dictionary<string, Dictionary<string, long>>();

            while (line != "End")
            {
                var splitLine = line.Split(new[] { " @" }, StringSplitOptions.RemoveEmptyEntries);

                if (!(splitLine.Length > 1))
                {
                    line = Console.ReadLine();
                    continue;
                }

                var name = splitLine[0];

                var sum = splitLine[1].Split();

                if (sum.Length < 3)
                {
                    line = Console.ReadLine();
                    continue;
                }
                else
                {
                    try
                    {
                        var test1 = long.Parse(sum[sum.Length - 2].Trim());
                        var test2 = long.Parse(sum[sum.Length - 1].Trim());
                    }
                    catch
                    {
                        line = Console.ReadLine();
                        continue;

                    }
                }

                var venue = GetCityName(sum);
                var ticketsPrice = long.Parse(sum[sum.Length - 2].Trim());
                var ticketsCount = long.Parse(sum[sum.Length - 1].Trim());

                var price = ticketsCount * ticketsPrice;

                if (!concert.ContainsKey(venue))
                {
                    concert[venue] = new Dictionary<string, long>();
                }

                var disko = concert[venue];

                if (!disko.ContainsKey(name))
                {
                    disko[name] = price;
                }
                else
                {
                    disko[name] += price;
                }


                line = Console.ReadLine();
            }

            foreach (var kvp in concert)
            {
                var city = kvp.Key;
                var singer = kvp.Value;
                Console.WriteLine($"{city}");
                Console.WriteLine($"{string.Join("\r\n", singer.OrderByDescending(x => x.Value).Select(y => $"#  {y.Key} -> {y.Value}"))}");
            }
        }

        private static string GetCityName(string[] city)
        {
            var cityName = string.Empty;
            for (int i = 0; i < city.Length - 2; i++)
            {
                cityName += city[i] + " ";
            }
            return cityName;
        }
    }
}
