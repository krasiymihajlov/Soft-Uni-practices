namespace _07.LegoBlocks
{
    using System;
    using System.Linq;

    public class LegoBlocks
    {
        public static void Main()
        {
            var bothRow = int.Parse(Console.ReadLine());

            int[][] firstMatrix = new int[bothRow][];
            int[][] secondMatrix = new int[bothRow][];

            for (int i = 0; i < bothRow * 2; i++)
            {
                var numbersOfRow = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (i < bothRow)
                {
                    firstMatrix[i] = numbersOfRow;
                }
                else
                {
                    secondMatrix[i - bothRow] = numbersOfRow;
                }
            }

            ReverseSecondMatrix(secondMatrix);

            int[][] newMatrix = FitTwoMatrix(firstMatrix, secondMatrix);

            PrintMatrix(newMatrix);
        }

        private static void ReverseSecondMatrix(int[][] matrix)
        {

            for (int currentRow = 0; currentRow < matrix.Length; currentRow++)
            {
                Array.Reverse(matrix[currentRow]);
            }
        }

        private static int[][] FitTwoMatrix(int[][] firstMatrix, int[][] secondMatrix)
        {
            int[][] newMatrix = new int[firstMatrix.Length][];

            for (int i = 0; i < newMatrix.Length; i++)
            {
                var firstCol = firstMatrix[i].Length;
                var secondCol = secondMatrix[i].Length;

                newMatrix[i] = new int[firstCol + secondCol];

                for (int j = 0; j < firstCol + secondCol; j++)
                {
                    if(j < firstCol)
                    {
                        newMatrix[i][j] = firstMatrix[i][j];
                    }
                    else
                    {
                        newMatrix[i][j] = secondMatrix[i][j - firstCol];
                    }
                }
            }

            return newMatrix;
        }

        private static void PrintMatrix(int[][] matrix)
        {
            var fitLength = matrix[0].Length;
            var isFit = true;
            var count = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                if(fitLength != matrix[i].Length)
                {
                    isFit = false;
                }

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    count++;
                }
            }

            if (isFit)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    Console.WriteLine($"[{string.Join(", ", matrix[i])}]");

                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {count}");
            }
        }
    }
}
