namespace _01.Reverse_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseNumbers
    {
        public static void Main()
        {
            long[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

            var stackOfNumbers = new Stack<long>();

            foreach (var number in numbers)
            {
                stackOfNumbers.Push(number);
            }

            Console.WriteLine(string.Join(" ", stackOfNumbers));
        }
    }
}
