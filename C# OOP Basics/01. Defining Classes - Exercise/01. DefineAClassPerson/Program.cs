using System;
using System.Linq;

namespace _01.DefineAClassPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfEmployee = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEmployee; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string model = tokens[0];
                decimal fuelAmount = decimal.Parse(tokens[1]);
                decimal fuelConsumption = decimal.Parse(tokens[2]);


            }

        }
    }
}


