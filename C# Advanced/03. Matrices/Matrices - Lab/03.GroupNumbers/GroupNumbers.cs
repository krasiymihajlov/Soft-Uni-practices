namespace _03.GroupNumbers
{
    using System;
    using System.Linq;

    public class GroupNumbers
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] sizes = new int[3];
            foreach (var number in input)
            {
                int reminder = Math.Abs(number % 3);
                sizes[reminder]++;
            }

            int[][] matrix = { new int[sizes[0]], new int[sizes[1]], new int[sizes[2]] };

            int[] offsets = new int[3];

            foreach (var number in input)
            {
                int reminder = Math.Abs(number % 3);
                int index = offsets[reminder];
                matrix[reminder][index] = number;
                offsets[reminder]++;
            }
            
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
