namespace _06.BirthdayCelebrations
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
                string race = tokens[0];

                if (race == "Citizen")
                {
                    IIdentity citizen = new Citizens(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
                    statistic.Add(citizen.Birthdate);
                }
                else if (race == "Pet")
                {
                    IIdentity pets = new Pet(tokens[1], tokens[2]);
                    statistic.Add(pets.Birthdate);
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
