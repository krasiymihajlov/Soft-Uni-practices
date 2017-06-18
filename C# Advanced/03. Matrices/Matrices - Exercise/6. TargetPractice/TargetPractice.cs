namespace _6.TargetPractice
{
    using System;

    public class TargetPractice
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var rows = int.Parse(input[0]);
            var cols = int.Parse(input[1]);
            var snakeLength = Console.ReadLine();

            var shotParam = Console.ReadLine()
               .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var impactRow = int.Parse(shotParam[0]);
            var impactCol = int.Parse(shotParam[1]);
            var radius = int.Parse(shotParam[2]);
            char[][] matrix = new char[rows][];

            FillMatrix(matrix, cols, snakeLength);

            ShotTheSnake(matrix, impactCol, impactRow, radius);

            FallingDown(matrix);

            PrintMatrix(matrix);
        }

        private static void FillMatrix(char[][] matrix, int cols, string snakeLength)
        {
            for (int i = matrix.Length - 1; i >= 0; i--)
            {
                matrix[i] = new char[cols];
            }

            var isMovingLeft = true;
            var currentLength = 0;

            for (int i = matrix.Length - 1; i >= 0; i--)
            {
                var col = isMovingLeft ? matrix[i].Length - 1 : 0;
                var colIndex = isMovingLeft ? -1 : 1;

                while (col >= 0 && col < matrix[i].Length)
                {
                    matrix[i][col] = snakeLength[currentLength % snakeLength.Length];

                    currentLength++;
                    col += colIndex;
                }

                isMovingLeft = !isMovingLeft;
            }
        }


        private static void ShotTheSnake(char[][] matrix, int impactCol, int impactRow, int radius)
        {
            for (int currentRow = 0; currentRow < matrix.Length; currentRow++)
            {
                for (int currentCol = 0; currentCol < matrix[currentRow].Length; currentCol++)
                {
                    var infectRow = currentRow - impactRow;
                    var infectCol = currentCol - impactCol;

                    var isInfect = (infectRow * infectRow) + (infectCol * infectCol) <= radius * radius;

                    if (isInfect)
                    {
                        matrix[currentRow][currentCol] = ' ';
                    }
                }
            }
        }

        private static void FallingDown(char[][] matrix)
        {
            for (int currentRow = matrix.Length - 1; currentRow >= 0; currentRow--)
            {
                for (int currentCol = 0; currentCol < matrix[currentRow].Length; currentCol++)
                {
                    var isEmpty = matrix[currentRow][currentCol] != ' ';

                    if (isEmpty)
                    {
                        continue;
                    }

                    var updateRow = currentRow - 1;

                    while (updateRow >= 0)
                    {
                        isEmpty = matrix[updateRow][currentCol] != ' ';

                        if (isEmpty)
                        {
                            matrix[currentRow][currentCol] = matrix[updateRow][currentCol];
                            matrix[updateRow][currentCol] = ' ';
                            break;
                        }

                        updateRow--;
                    }
                }
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write($"{matrix[i][j]}");
                }

                Console.WriteLine();
            }
        }
    }
}
