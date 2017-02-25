namespace _08.Logs_Aggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DictLambdaLinqExer
    {
        public static void Main()
        {
            var users = new SortedDictionary<string, SortedDictionary<string, int>>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split();

                var ip = line[0];
                var user = line[1];
                var duration = line[2];

                if (!users.ContainsKey(user))
                {
                    users[user] = new SortedDictionary<string, int>();
                }

                if (!users[user].ContainsKey(ip))
                {
                    users[user][ip] = int.Parse(duration);
                }
                else
                {
                    users[user][ip] += int.Parse(duration);
                }                
            }

            foreach (var name in users)
            {
                var userName = name.Key;
                var userIp = name.Value;
                var sumduration = userIp.Values.Sum();

                Console.Write($"{userName}: {sumduration} [");

                var count = 0;

                foreach (var ip in userIp)
                {
                    var ipName = ip.Key;
                    count++;           

                    if (count == userIp.Count)
                    {
                        Console.Write($"{ipName}");
                        Console.Write("]");
                    }
                    else
                    {
                        Console.Write($"{ipName}, ");
                    }

                }

                Console.WriteLine();
            }

        }
    }
}
