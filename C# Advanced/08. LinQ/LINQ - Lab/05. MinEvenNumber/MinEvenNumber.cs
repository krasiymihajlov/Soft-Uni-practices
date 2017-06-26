namespace _05.MinEvenNumber
{
    using System;
    using System.Linq;

    public class MinEvenNumber
    {
        public static void Main()
        {
            double MinNumber = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)
                .FirstOrDefault();

            if (MinNumber == 0)
            {
                Console.WriteLine("No match");
            }
            else
            {
                Console.WriteLine($"{MinNumber:F2}");
            }
        }
    }
}
