namespace _03.A_Miner_Task
{
    using System;
    using System.Collections.Generic;

    public class DictLambdaLinqExer
    {
        public static void Main()
        {
            var minerDict = new Dictionary<string, int>();

            string resource = Console.ReadLine();            

            while (!resource.Equals("stop"))
            {
                int quantity = int.Parse(Console.ReadLine());

                if (!minerDict.ContainsKey(resource))
                {
                    minerDict[resource] = quantity;
                }
                else
                {
                    minerDict[resource] += quantity;
                }

                resource = Console.ReadLine();                
            }

            foreach (var resours in minerDict)
            {
                Console.WriteLine($"{resours.Key} -> {resours.Value}");
            }
        }
    }
}
