namespace _07.BoundedNumbers
{
    using System;
    using System.Linq;

    public class BoundedNumbers
    {
        public static void Main()
        {
            int[] boundery = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int min = Math.Min(boundery[0], boundery[1]);
            int max = Math.Max(boundery[0], boundery[1]);

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(n => n >= min && n <= max)
                .ToArray();

            Console.WriteLine(numbers.Length == 0 ? "" : string.Join(" ", numbers));
        }
    }
}
