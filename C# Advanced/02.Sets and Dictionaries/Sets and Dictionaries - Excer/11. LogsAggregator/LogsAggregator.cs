namespace _11.LogsAggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LogsAggregator
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var info = new SortedDictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var ip = line[0];
                var user = line[1];
                var time = long.Parse(line[2]);

                if(!info.ContainsKey(user))
                {
                    info[user] = new Dictionary<string, long>();
                }
                                
                var ipCollection = info[user];

                if(!ipCollection.ContainsKey(ip))
                {
                    ipCollection[ip] = time;
                }
                else
                {
                    ipCollection[ip] += time;
                }

            }

            foreach (var kvp in info)
            {
                var user = kvp.Key;
                var ipBox = kvp.Value;

                Console.Write($"{user}: {ipBox.Select(x => x.Value).Sum()} [");
                Console.WriteLine($"{string.Join(", ", ipBox.OrderBy(x => x.Key).Select(x => $"{x.Key}"))}]");
            }
        }
    }
}
