namespace _03.CustomMinFunction
{
    using System;
    using System.Linq;

    public class CustomMinFunction
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Func<int[], int> getSmallestNumber = n => n.Min();
            Console.WriteLine(getSmallestNumber(numbers));
        }
    }
}
