namespace _09.UserLogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserLogs
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var users = new SortedDictionary<string, Dictionary<string, int>>();

            while (input != "end")
            {
                var arr = input.Split(new[] { "IP=", "user="," ",}, StringSplitOptions.RemoveEmptyEntries);

                var ip = arr[0];
                var name = arr[2];

                if(!users.ContainsKey(name))
                {
                    users[name] = new Dictionary<string, int>();
                }

                var boxIp = users[name];

                if(!boxIp.ContainsKey(ip))
                {
                    boxIp[ip] = 1;
                }
                else
                {
                    boxIp[ip] += 1;
                }

                input = Console.ReadLine();
            }

            foreach (var kvp in users)
            {
                var name = kvp.Key;
                var boxIp = kvp.Value;

                Console.WriteLine($"{name}: ");

                Console.WriteLine($"{string.Join(", ", boxIp.Select(i => $"{i.Key} => {i.Value}"))}.");                
            }
        }
    }
}
