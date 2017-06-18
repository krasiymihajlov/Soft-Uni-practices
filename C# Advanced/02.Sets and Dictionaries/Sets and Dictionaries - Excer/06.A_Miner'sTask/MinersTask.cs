namespace _06.A_Miner_sTask
{
    using System;
    using System.Collections.Generic;

    public class MinersTask
    {
        public static void Main()
        {
            var resource = Console.ReadLine();
            var collect = new Dictionary<string, int>();

            while (resource != "stop")
            {
                var quantity = int.Parse(Console.ReadLine());

                if(!collect.ContainsKey(resource))
                {
                    collect[resource] = quantity;
                }
                else
                {
                    collect[resource] += quantity;
                }

                resource = Console.ReadLine();
            }

            foreach (var kvp in collect)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
