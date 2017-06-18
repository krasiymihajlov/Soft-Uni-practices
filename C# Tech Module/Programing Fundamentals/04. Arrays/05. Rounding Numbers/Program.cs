namespace _05.Rounding_Numbers
{
    using System;
    using System.Linq;

    public class Arrays
    {
        public static void Main()
        {
            double[] numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            double[] keepNumbers = new double[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                keepNumbers[i] = numbers[i];
                numbers[i] = Math.Round(numbers[i], MidpointRounding.AwayFromZero);
                Console.WriteLine(string.Join(" ", $"{keepNumbers[i]} => {numbers[i]}"));
            }            
        }
    }
}
