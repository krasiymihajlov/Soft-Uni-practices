namespace _5.RubiksMatrix
{
    using System;

    public class RubiksMatrix
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var rows = int.Parse(input[0]);
            var cols = int.Parse(input[1]);
            int[][] matrix = new int[rows][];
            InitializationMatrix(cols, matrix);
            var numbersOfComand = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbersOfComand; i++)
            {
                var currentComand = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var rowOrCol = int.Parse(currentComand[0]);
                var direction = currentComand[1];
                var moves = int.Parse(currentComand[2]);

                switch (direction)
                {
                    case "left":
                        for (int j = 0; j < moves % matrix.Length; j++)
                        {
                            var currentArr = matrix[rowOrCol][0];

                            for (int k = 0; k < matrix[rowOrCol].Length - 1; k++)
                            {
                                matrix[rowOrCol][k] = matrix[rowOrCol][k + 1];
                            }

                            matrix[rowOrCol][matrix[rowOrCol].Length - 1] = currentArr;
                        }
                        break;
                    case "right":
                        for (int j = 0; j < moves % matrix.Length; j++)
                        {
                            var currentArr = matrix[rowOrCol][matrix[rowOrCol].Length - 1];

                            for (int k = matrix[rowOrCol].Length - 1; k > 0 ; k--)
                            {
                                matrix[rowOrCol][k] = matrix[rowOrCol][k - 1];
                            }

                            matrix[rowOrCol][0] = currentArr;
                        }
                        break;
                    case "up":
                        for (int j = 0; j < moves % matrix.Length; j++)
                        {
                            var currentArr = matrix[0][rowOrCol];

                            for (int k = 0; k < matrix[rowOrCol].Length - 1; k++)
                            {
                                matrix[k][rowOrCol] = matrix[k + 1][rowOrCol];
                            }

                            matrix[matrix[rowOrCol].Length - 1][rowOrCol] = currentArr;
                        }
                        break;
                    case "down":
                        for (int j = 0; j < moves % matrix.Length; j++)
                        {
                            var currentArr = matrix[matrix[rowOrCol].Length - 1][rowOrCol];

                            for (int k = matrix[rowOrCol].Length - 1; k > 0; k--)
                            {
                                matrix[k][rowOrCol] = matrix[k -1][rowOrCol];
                            }

                            matrix[0][rowOrCol] = currentArr;
                        }
                        break;
                    default:
                        break;
                }
            }

            var counter = 1;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (counter == matrix[i][j])
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        RearrangeMatrix(matrix, counter, i, j);
                    }

                    counter++;
                }
            }

        }

        private static void RearrangeMatrix(int[][] matrix, int counter, int i, int j)
        {
            for (int k = 0; k < matrix.Length; k++)
            {
                for (int z = 0; z < matrix[i].Length; z++)
                {
                    var currentNumber = matrix[i][j];
                    if (counter == matrix[k][z])
                    {
                        matrix[i][j] = counter;
                        matrix[k][z] = currentNumber;
                        Console.WriteLine($"Swap ({i}, {j}) with ({k}, {z})");
                        break;
                    }
                }

                if (counter == matrix[i][j])
                {
                    break;
                }
            }
        }

        private static void InitializationMatrix(int cols, int[][] matrix)
        {
            var counter = 1;

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[cols];

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = counter;
                    counter++;
                }
            }
        }
    }
}
