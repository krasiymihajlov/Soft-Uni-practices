namespace _10.Сръбско_Unleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class DictLambdaLinqExer
    {
        public static void Main()
        {
            var trepniTrepni = new Dictionary<string, Dictionary<string, double>>();

            string pattern = @"(.*?)\s@(.*?)\s(\d+)\s(\d+)";
            string input = Console.ReadLine();

            while (input != "End")
            {
                if (Regex.IsMatch(input, pattern))
                {
                    var separator = new string[] { " @" };
                    var inputSpace = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                    if (inputSpace.Length == 2)
                    {
                        var vanue = inputSpace[1].Split();

                        var cityName = GetCityName(vanue).Trim();
                        var singerName = inputSpace[0].Trim();

                        var ticketsPrice = double.Parse(vanue[vanue.Length - 2]);
                        var ticketsCount = double.Parse(vanue[vanue.Length - 1]);

                        var price = ticketsCount * ticketsPrice;

                        if (!trepniTrepni.ContainsKey(cityName))
                        {
                            trepniTrepni[cityName] = new Dictionary<string, double>();
                        }

                        if (!trepniTrepni[cityName].ContainsKey(singerName))
                        {
                            trepniTrepni[cityName][singerName] = price;
                        }
                        else
                        {
                            trepniTrepni[cityName][singerName] += price;
                        }

                    }
                }

                input = Console.ReadLine();
            }

            foreach (var city in trepniTrepni)
            {
                var cityName = city.Key;
                var concert = city.Value;

                Console.WriteLine($"{cityName}");

                foreach (var money in concert.OrderByDescending(x => x.Value))
                {
                    var singerName = money.Key;
                    var price = money.Value;

                    Console.WriteLine($"#  {singerName} -> {price}");
                }
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
