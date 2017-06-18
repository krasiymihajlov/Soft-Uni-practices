namespace _09.Extract_Middle_Elements
{
    using System;
    using System.Linq;

    public class Arrays
    {
        public static void Main()
        {
            int[] numbersOfArrays = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int divider = numbersOfArrays.Length / 2;

            if (numbersOfArrays.Length == 1)
            {
                Console.WriteLine("{{ {0} }}", numbersOfArrays[0]);
            }
            else if (numbersOfArrays.Length % 2 == 0)
            {
                Console.WriteLine($"{{ {numbersOfArrays[divider - 1]}, {numbersOfArrays[divider]} }}");
            }
            else if (numbersOfArrays.Length % 2 == 1)
            {
                Console.WriteLine($"{{ {numbersOfArrays[divider - 1]}, {numbersOfArrays[divider]}, {numbersOfArrays[divider + 1]} }}");
            }
        }
    }
}
