namespace _4.MaximalSum
{
    using System;
    using System.Linq;

    public class MaximalSum
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var rows = int.Parse(input[0]);
            var cols = int.Parse(input[1]);
            int[][] matrix = new int[rows][];


            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            var maxSum = int.MinValue;
            var maxRow = 0;
            var maxCol = 0;

            for (int i = 2; i < matrix.Length; i++)
            {
                for (int j = 2; j < matrix[i].Length; j++)
                {
                    var currentSum = matrix[i][j] + matrix[i][j - 1] + matrix[i][j - 2] + matrix[i - 1][j] + matrix[i - 1][j - 1] + matrix[i - 1][j - 2] + matrix[i - 2][j] + matrix[i - 2][j - 1] + matrix[i - 2][j - 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int i = maxRow - 2 ; i < maxRow + 1; i++)
            {
                for (int j = maxCol - 2; j < maxCol + 1; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
