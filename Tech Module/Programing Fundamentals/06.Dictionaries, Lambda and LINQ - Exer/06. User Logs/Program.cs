namespace _06.User_Logs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DictLambdaLinqExer
    {
        public static void Main()
        {          
            var input = Console.ReadLine();

            var userName = new SortedDictionary<string, Dictionary<string, List<int>>>();

            while (!(input == "end"))
            {
                var inputUsers = input.
                    Split("= ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var ipValue = inputUsers[1];
                var name = inputUsers[5];

                if (!userName.ContainsKey(name))
                {
                    userName[name] = new Dictionary<string, List<int>>();
                }

                var userIp = userName[name];                

                if (!userIp.ContainsKey(ipValue))
                {
                    userIp[ipValue] = new List<int>();
                    userIp[ipValue].Add(1);
                }
                else
                {
                    userIp[ipValue].Add(1);
                }

                input = Console.ReadLine();
            }

            foreach (var user in userName)
            {
                var last = user.Value.Last();
                var users = user.Key;
                var ipCountDict = user.Value;
                Console.WriteLine($"{users}:");

                foreach (var ip in ipCountDict)
                {
                    var ipName = ip.Key;
                    var ipSum = ip.Value.Sum();
                    if (!ip.Equals(last))
                    {
                        Console.Write($"{ipName} => {ipSum}, ");
                    }
                    else
                    {
                        Console.Write($"{ipName} => {ipSum}. ");
                    }
                }

                Console.WriteLine();
            }

        }
    }
}

