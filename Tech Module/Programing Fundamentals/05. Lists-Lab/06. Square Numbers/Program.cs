namespace _06.Square_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Lists
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var squareNumbers = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                var sqrtMath = Math.Sqrt(numbers[i]);
                if (sqrtMath == (int)sqrtMath)
                {
                    squareNumbers.Add(numbers[i]);
                }
            }

            squareNumbers.Sort();
            squareNumbers.Reverse();           

            Console.WriteLine(string.Join(" ", squareNumbers));
        }
    }
}