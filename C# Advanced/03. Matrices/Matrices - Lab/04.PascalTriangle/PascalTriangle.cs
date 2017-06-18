namespace _04.PascalTriangle
{
    using System;

    public class PascalTriangle
    {
        public static void Main()
        {
            var number = long.Parse(Console.ReadLine());

            long[][] matrix = new long[number][];
            var currentCol = 1;

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new long[currentCol];
                matrix[i][matrix[i].Length - 1] = 1;
                matrix[i][0] = 1;


                for (int j = 1; j < matrix[i].Length - 1; j++)
                {
                    matrix[i][j] = matrix[i - 1][j] + matrix[i - 1][j - 1];
                }

                currentCol++;
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine($"{string.Join(" ", matrix[i])}");
            }
        }
    }
}
