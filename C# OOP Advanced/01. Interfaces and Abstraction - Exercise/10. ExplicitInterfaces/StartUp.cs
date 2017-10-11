namespace _10.ExplicitInterfaces
{
    using _10.ExplicitInterfaces.Interfaces;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string citizen;
            while ((citizen = Console.ReadLine()) != "End")
            {
                string[] tokens = citizen.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                IResident resident = new Citizen(name, country, age);
                IPerson person = new Citizen(name, country, age);

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
