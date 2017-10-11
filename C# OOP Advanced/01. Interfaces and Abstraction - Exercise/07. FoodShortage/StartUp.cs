namespace _07.FoodShortage
{
    using System;
    using System.Collections.Generic;
    using _07.FoodShortage.Interfaces;
    using _07.FoodShortage.Population;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<IBuyer> statistic = new List<IBuyer>();

            int parameter = int.Parse(Console.ReadLine());
            for (int i = 0; i < parameter; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];

                if (tokens.Length == 4)
                {
                    IBuyer citizen = new Citizens(name, int.Parse(tokens[1]), tokens[2], tokens[3]);
                    statistic.Add(citizen);
                }
                else
                {
                    IBuyer rabel = new Rabel(name, int.Parse(tokens[1]), tokens[2]);
                    statistic.Add(rabel);
                }
            }

            string command;
            int result = 0;
            while ((command = Console.ReadLine()) != "End")
            {
                foreach (var person in statistic)
                {
                    if (person.Name == command)
                    {
                        result += person.BuyFood();
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
