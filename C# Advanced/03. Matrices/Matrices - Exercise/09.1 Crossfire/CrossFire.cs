namespace _09.Crossfire
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CrossFire
    {
        public static void Main()
        {
            var point = new int[2];
            var matrix = InitialMatrix();

            matrix = StartShooting(matrix);
            PrintMatrix(matrix);

        }

        private static bool IsInRange(int[] point, int[][] matrix)
        {
            var row = point[0];
            var col = point[1];

            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        private static int[][] StartShooting(int[][] matrix)
        {
            var text = Console.ReadLine();
            while (text != "Nuke it from orbit")
            {
                var line = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var impactRow = int.Parse(line[0]);
                var impactCol = int.Parse(line[1]);
                var shootRadius = int.Parse(line[2]);
                var currentArray = new int[] { impactRow, impactCol };

                matrix = DestroyingCells(currentArray, matrix, shootRadius);
                matrix = FixMatrix(matrix);
                text = Console.ReadLine();
            }

            return matrix;
        }

        private static int[][] DestroyingCells(int[] currentArray, int[][] matrix, int shootRadius)
        {
            var row = currentArray[0];
            var col = currentArray[1];

            for (int i = col - shootRadius; i <= col + shootRadius; i++)
            {
                currentArray[1] = i;
                if (IsInRange(currentArray, matrix))
                {
                    matrix[row][i] = -1;
                }
            }

            currentArray[1] = col;
            for (int i = row - shootRadius; i <= row + shootRadius; i++)
            {
                currentArray[0] = i;
                if (IsInRange(currentArray, matrix))
                {
                    matrix[i][col] = -1;
                }
            }

            return matrix;
        }

        private static int[][] FixMatrix(int[][] matrix)
        {
            // Remove destroyed cells
            for (int i = 0; i < matrix.Length; i++)
            {
                // Remove destroyed cells if there is ones
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] < 0)
                    {
                        matrix[i] = matrix[i].Where(n => n > 0).ToArray();
                        break;
                    }
                }

                // Remove empty rows
                if (matrix[i].Count() < 1)
                {
                    matrix = matrix.Take(i).Concat(matrix.Skip(i + 1)).ToArray();
                    i--;
                }
            }

            return matrix;
        }

        private static int[][] InitialMatrix()
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var row = int.Parse(input[0]);
            var col = int.Parse(input[1]);
            int[][] matrix = new int[row][];
            var count = 1;

            for (int i = 0; i < row; i++)
            {
                matrix[i] = new int[col];

                for (int j = 0; j < col; j++)
                {
                    matrix[i][j] = count;
                    count++;
                }
            }

            return matrix;
        }

        private static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine($"{string.Join(" ", matrix[i])}");
            }
        }
    }
}
