namespace _06.ReverseAndExclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseAndExclude
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int divider = int.Parse(Console.ReadLine());
            Predicate<int> isDivisible = n => n % divider == 0;
            List<int> result = IsDivisible(isDivisible, numbers);
            PrintResult(result);
        }

        private static void PrintResult(List<int> result)
        {
            Console.WriteLine(string.Join(" ", result));
        }

        public static List<int> IsDivisible(Predicate<int> isDivisible, int[] numbers)
        {
            List<int> list = new List<int>();
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (!isDivisible(numbers[i]))
                {
                    list.Add(numbers[i]);
                }
            }

            return list;
        }
    }
}
