namespace _03.Fold_and_Sum
{
    using System;
    using System.Linq;

    public class ArraysExercises
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = numbers.Length / 4;
            int[] sum = new int[numbers.Length / 2];
            int[] reverseStart = new int[k];
            int[] reverseEnd = new int[k];

            for (int i = 0, j = numbers.Length - 1; i < k; i++, j--)
            {
                reverseStart[i] = numbers[k - 1 - i];
                reverseEnd[i] = numbers[j];
                sum[i] = reverseStart[i];
                sum[i + k] = reverseEnd[i];
            }

            for (int i = 0; i < numbers.Length / 2; i++)
            {
                sum[i] += numbers[k + i];
            }

            Console.WriteLine(string.Join(" ", sum));            
        }
    }
}
