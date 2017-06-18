namespace _2.Diagonal_Difference
{
    using System;
    using System.Linq;

    public class DiagonalDifference
    {
        public static void Main()
        {
            var squareLenth = int.Parse(Console.ReadLine());
            int[][] matrix = new int[squareLenth][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            var firstDiagonalSum = 0;
            var secondDiagonalSum = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                firstDiagonalSum += matrix[i][i];
                secondDiagonalSum += matrix[i][matrix.Length - i - 1];
            }
            
            Console.WriteLine(Math.Abs(firstDiagonalSum - secondDiagonalSum));

        }
    }
}
