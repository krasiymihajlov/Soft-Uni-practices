namespace _02.SquareWithMaximumSum
{
    using System;
    using System.Linq;

    public class SquareWithMaximumSum
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = input[0];
            var cols = input[1];
            var matrix = new int[rows][];

            var maxRow = 0;
            var maxCol = 0;
            var maxSum = int.MinValue;

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[i].Length; j++)
                {
                    var currentSum = matrix[i - 1][j - 1] + matrix[i - 1][j] + matrix[i][j - 1] + matrix[i][j];

                    if(maxSum < currentSum)
                    {
                        maxSum = currentSum;
                        maxRow = i - 1;
                        maxCol = j - 1;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxRow][maxCol]} {matrix[maxRow][maxCol + 1]}");
            Console.WriteLine($"{matrix[maxRow + 1][maxCol]} {matrix[maxRow + 1][maxCol + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
