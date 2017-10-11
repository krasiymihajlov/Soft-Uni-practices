namespace _05.BorderControl
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            List<string> statistic = new List<string>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split();
                string name = tokens[0];

                if (tokens.Length == 2)
                {
                    INumber robot = new Robot(tokens[0], tokens[1]);
                    statistic.Add(robot.ID);
                }
                else
                {
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    INumber citizen = new Citizens(name, age, id);
                    statistic.Add(citizen.ID);
                }
            }

            string check = Console.ReadLine();

            for (int i = 0; i < statistic.Count; i++)
            {
                if (statistic[i].EndsWith(check))
                {
                    Console.WriteLine(statistic[i]);
                }
            }
        }
    }
}
