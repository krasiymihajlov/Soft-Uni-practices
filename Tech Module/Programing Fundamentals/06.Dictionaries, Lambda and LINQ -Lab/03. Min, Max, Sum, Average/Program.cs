namespace _03.Min_Max_Sum_Average
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DictionariesLambdaLinq
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            var listOfNumbers = new List<int>();

            for (int i = 0; i < number; i++)
            {
                listOfNumbers.Add(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine($"Sum = {listOfNumbers.Sum()}");
            Console.WriteLine($"Min = {listOfNumbers.Min()}");
            Console.WriteLine($"Max = {listOfNumbers.Max()}");
            Console.WriteLine($"Average = {listOfNumbers.Average()}");
        }
    }
}
