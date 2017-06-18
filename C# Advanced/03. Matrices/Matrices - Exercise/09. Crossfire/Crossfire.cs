namespace _09.Crossfire
{
    using System;
    using System.Collections.Generic;

    public class Crossfire
    {
        public static void Main()
        {
            var point = new int[2];
            var matrix = InitialMatrix();

            StartShooting(matrix);

            PrintMatrix(matrix);
            
        }

        private static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] != -1)
                    {
                        Console.Write($"{matrix[i][j]} ");
                    }
                }

                Console.WriteLine();
            }
        }

        private static bool IsInRange(int[] point, int[][] matrix)
        {
            var row = point[0];
            var col = point[1];

            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[0].Length;
        }

        private static void StartShooting(int[][] matrix)
        {
            var text = Console.ReadLine();
            while (text != "Nuke it from orbit")
            {
                var line = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var impactRow = int.Parse(line[0]);
                var impactCol = int.Parse(line[1]);
                var shootRadius = int.Parse(line[2]);
                var currentArray = new int[] { impactRow, impactCol };

                if (IsInRange(currentArray, matrix))
                {
                    DestroyingCells(currentArray, matrix, shootRadius);
                    FixMatrix(matrix);
                }
                else
                {
                    DestroyingCells(currentArray, matrix, shootRadius);
                    FixMatrix(matrix);
                }

                text = Console.ReadLine();
            }
        }

        private static void FixMatrix(int[][] matrix)
        {
            var queue = new Queue<int>();

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] != -1)
                    {
                        continue;
                    }

                    for (int k = 0; k < matrix[i].Length; k++)
                    {
                        if(matrix[i][k] == -1)
                        {
                            queue.Enqueue(-1);
                        }
                        else
                        {
                            if(k - queue.Count >= 0)
                            {
                                matrix[i][k - queue.Count] = matrix[i][k];
                            }
                        }
                    }

                    var length = queue.Count;

                    
                    for (int m = matrix[i].Length -1 ; m > matrix[i].Length - 1 - length; m--)
                    {
                        if (queue.Count > 0)
                        {
                            matrix[i][m] = queue.Dequeue();
                        }
                    }
                }
            }

        }

        private static void DestroyingCells(int[] currentArray, int[][] matrix, int shootRadius)
        {
            var row = currentArray[0];
            var col = currentArray[1];

            // if shoot is in matrix
            if (IsInRange(currentArray, matrix))
            {
                // remove right
                for (int i = col; i < col + shootRadius; i++)
                {
                    currentArray[1] = i;
                    if (IsInRange(currentArray, matrix) && matrix[row][i] != -1)
                    {
                        matrix[row][i] = -1;
                    }
                }
                // remove left
                for (int i = col - 1; i >= col - shootRadius; i--)
                {
                    currentArray[1] = i;
                    if (IsInRange(currentArray, matrix) && matrix[row][i] != -1)
                    {
                        matrix[row][i] = -1;
                    }
                }
                // remove up
                for (int i = row; i < row + shootRadius; i++)
                {
                    currentArray[0] = i;
                    if (IsInRange(currentArray, matrix) && matrix[i][col] != -1)
                    {
                        matrix[i][col] = -1;
                    }
                }
                // remove down
                for (int i = row - 1; i >= row - shootRadius; i--)
                {
                    currentArray[0] = i;
                    if (IsInRange(currentArray, matrix) && matrix[i][col] != -1)
                    {
                        matrix[i][col] = -1;
                    }
                }
            }
            else
            {
                var currentCol = col;
                var currentRow = row;
                var currentRadiusCol = shootRadius;
                var currentRadiusRow = shootRadius;

                if (currentCol < 0)
                {
                    currentRadiusCol = currentCol + shootRadius + 1;
                    currentCol = 0;
                }

                // remove right
                for (int i = currentCol; i < currentCol + currentRadiusCol; i++)
                {
                    if (row >= 0 && row < matrix.Length && currentCol < matrix[0].Length)
                    {
                        currentArray[1] = i;
                        if (matrix[row][i] != -1)
                        {
                            matrix[row][i] = -1;
                        }
                    }                    
                }

                if (currentCol > matrix[0].Length)
                {
                    currentRadiusCol = matrix[0].Length - shootRadius;
                    currentCol = matrix[0].Length - 1;
                }
                // remove left
                for (int i = currentCol; i > currentCol - currentRadiusCol - 1; i--)
                {
                    if(row >= 0 && row < matrix.Length && col >= 0)
                    {
                        currentArray[1] = i;
                        if (IsInRange(currentArray, matrix) && matrix[row][i] != -1)
                        {
                            matrix[row][i] = -1;
                        }
                    }                    
                }

                
                if (currentRow > matrix.Length)
                {
                    currentRadiusRow = matrix.Length - shootRadius;
                    currentRow = matrix.Length - 1;
                }
                // remove up
                for (int i = currentRow; i > currentRow - currentRadiusRow - 1; i--)
                {
                    if(col >= 0 && col < matrix[0].Length && row >= 0)
                    {
                        currentArray[0] = i;
                        if (IsInRange(currentArray, matrix) && matrix[i][col] != -1)
                        {
                            matrix[i][col] = -1;
                        }
                    }                    
                }

                if (currentRow < 0)
                {
                    currentRadiusRow = currentRow + shootRadius + 1;
                    currentRow = 0;
                }
                // remove down
                for (int i = currentRow; i < currentRow + currentRadiusRow; i++)
                {
                    if (col >= 0 && col < matrix[0].Length && currentRow < matrix.Length)
                    {
                        currentArray[0] = i;
                        if (IsInRange(currentArray, matrix) && matrix[i][col] != -1)
                        {
                            matrix[i][col] = -1;
                        }
                    }                    
                }

            }
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
    }
}
