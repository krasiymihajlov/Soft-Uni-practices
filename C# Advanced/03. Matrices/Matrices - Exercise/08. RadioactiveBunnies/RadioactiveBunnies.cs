namespace _08.RadioactiveBunnies
{
    using System;
    using System.Collections.Generic;

    public class RadioactiveBunnies
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var rows = int.Parse(input[0]);
            var cols = int.Parse(input[1]);
            char[][] matrix = new char[rows][];
            var isWin = false;
            var isDead = false;

            for (int i = 0; i < rows; i++)
            {
                var line = Console.ReadLine();
                matrix[i] = new char[cols];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = line[j];
                }
            }

            var commands = Console.ReadLine();
            var lastCord = new int[2];

            for (int i = 0; i < commands.Length; i++)
            {
                var command = commands[i];

                var isDeadIsWin = PlayersMoved(matrix, command, lastCord, isWin, isDead);

                isDead = isDeadIsWin[0];
                isWin = isDeadIsWin[1];

                var queue = GetBunnies(matrix);

                isDead = BunniesSpread(matrix, isDead, queue, lastCord);

                if (isWin || isDead)
                {
                    break;
                }
            }

            PrintMatrix(lastCord, matrix, isDead, isWin);

        }

        private static void PrintMatrix(int[] lastCord, char[][] matrix, bool isDead, bool isWin)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j]);
                }

                Console.WriteLine();
            }

            if (isWin)
            {
                Console.WriteLine($"won: {lastCord[0]} {lastCord[1]}");
            }
            if(isDead)
            {
                Console.WriteLine($"dead: {lastCord[0]} {lastCord[1]}");
            }
        }

        private static Queue<int> GetBunnies(char[][] matrix)
        {
            var queue = new Queue<int>();

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'B')
                    {
                        queue.Enqueue(i);
                        queue.Enqueue(j);
                    }
                }
            }

            return queue;
        }

        private static bool BunniesSpread(char[][] matrix, bool isDead, Queue<int> queue, int[] arr)
        {
            var count = queue.ToArray().Length / 2;

            for (int k = 0; k < count; k++)
            {
                var i = queue.Dequeue();
                var j = queue.Dequeue();

                var currentPosition = matrix[i][j];

                if (currentPosition == 'B')
                {
                    if (j - 1 >= 0)
                    {
                        if (matrix[i][j - 1] == '.' || matrix[i][j - 1] == 'B')
                        {
                            matrix[i][j - 1] = 'B';
                        }
                        else
                        {
                            isDead = true;
                            arr[0] = i;
                            arr[1] = j - 1;
                            matrix[i][j - 1] = 'B';
                        }
                    }

                    if (j + 1 < matrix[i].Length)
                    {
                        if (matrix[i][j + 1] == '.' || matrix[i][j + 1] == 'B')
                        {
                            matrix[i][j + 1] = 'B';
                        }
                        else
                        {
                            isDead = true;
                            arr[0] = i;
                            arr[1] = j + 1;
                            matrix[i][j + 1] = 'B';
                        }
                    }

                    if (i - 1 >= 0)
                    {
                        if (matrix[i - 1][j] == '.' || matrix[i - 1][j] == 'B')
                        {
                            matrix[i - 1][j] = 'B';
                        }
                        else
                        {
                            isDead = true;
                            arr[0] = i - 1;
                            arr[1] = j;
                            matrix[i - 1][j] = 'B';
                        }
                    }

                    if (i + 1 < matrix.Length)
                    {
                        if (matrix[i + 1][j] == '.' || matrix[i + 1][j] == 'B')
                        {
                            matrix[i + 1][j] = 'B';
                        }
                        else
                        {
                            isDead = true;
                            arr[0] = i + 1;
                            arr[1] = j;
                            matrix[i + 1][j] = 'B';
                        }
                    }

                }
            }

            return isDead;
        }

        private static bool[] PlayersMoved(char[][] matrix, char command, int[] arr, bool isWin, bool isDead)
        {
            var isDeadisWon = new bool[2];

            bool nextStep;

            switch (command)
            {
                case 'L':
                    var playerCoordinates = FindPlayer(matrix);
                    var playerRow = playerCoordinates[0];
                    var playerCol = playerCoordinates[1];

                    nextStep = playerCol - 1 >= 0;

                    if (nextStep)
                    {
                        if (matrix[playerRow][playerCol - 1] != 'B')
                        {
                            matrix[playerRow][playerCol - 1] = 'P';
                            matrix[playerRow][playerCol] = '.';
                        }
                        else
                        {
                            isDeadisWon[0] = true;
                            isDeadisWon[1] = isWin;
                            arr[0] = playerRow;
                            arr[1] = playerCol - 1;
                            matrix[playerRow][playerCol] = '.';
                        }

                    }
                    else
                    {
                        isDeadisWon[0] = isDead;
                        isDeadisWon[1] = true;
                        arr[0] = playerRow;
                        arr[1] = playerCol;
                        matrix[playerRow][playerCol] = '.';
                       
                    }

                    break;

                case 'R':
                    var playerCoordinatesR = FindPlayer(matrix);
                    var playerRowR = playerCoordinatesR[0];
                    var playerColR = playerCoordinatesR[1];

                    nextStep = playerColR + 1 < matrix[playerRowR].Length;

                    if (nextStep)
                    {
                        if (matrix[playerRowR][playerColR + 1] != 'B')
                        {
                            matrix[playerRowR][playerColR + 1] = 'P';
                            matrix[playerRowR][playerColR] = '.';
                        }
                        else
                        {
                            isDeadisWon[0] = true;
                            isDeadisWon[1] = isWin;
                            arr[0] = playerRowR;
                            arr[1] = playerColR + 1;
                            matrix[playerRowR][playerColR] = '.';
                        }

                    }
                    else
                    {
                        isDeadisWon[0] = isDead;
                        isDeadisWon[1] = true;
                        arr[0] = playerRowR;
                        arr[1] = playerColR;
                        matrix[playerRowR][playerColR] = '.';
                    }

                    break;
                case 'U':

                    var playerCoordinatesU = FindPlayer(matrix);
                    var playerRowU = playerCoordinatesU[0];
                    var playerColU = playerCoordinatesU[1];

                    nextStep = playerRowU - 1 >= 0;

                    if (nextStep)
                    {
                        if (matrix[playerRowU - 1][playerColU] != 'B')
                        {
                            matrix[playerRowU - 1][playerColU] = 'P';
                            matrix[playerRowU][playerColU] = '.';
                        }
                        else
                        {
                            isDeadisWon[0] = true;
                            isDeadisWon[1] = isWin;
                            arr[0] = playerRowU - 1;
                            arr[1] = playerColU;
                            matrix[playerRowU][playerColU] = '.';
                        }

                    }
                    else
                    {
                        isDeadisWon[0] = isDead;
                        isDeadisWon[1] = true;
                        arr[0] = playerRowU;
                        arr[1] = playerColU;
                        matrix[playerRowU][playerColU] = '.';
                    }

                    break;
                case 'D':

                    var playerCoordinatesD = FindPlayer(matrix);
                    var playerRowD = playerCoordinatesD[0];
                    var playerColD = playerCoordinatesD[1];

                   // curentStep = matrix[playerRowD][playerColD];
                    nextStep = playerRowD + 1 < matrix.Length;

                    if (nextStep)
                    {
                        if (matrix[playerRowD + 1][playerColD] != 'B')
                        {
                            matrix[playerRowD + 1][playerColD] = 'P';
                            matrix[playerRowD][playerColD] = '.';
                        }
                        else
                        {
                            isDeadisWon[0] = true;
                            isDeadisWon[1] = isWin;
                            arr[0] = playerRowD + 1;
                            arr[1] = playerColD;
                            matrix[playerRowD][playerColD] = '.';
                        }

                    }
                    else
                    {
                        isDeadisWon[0] = isDead;
                        isDeadisWon[1] = true;
                        arr[0] = playerRowD;
                        arr[1] = playerColD;
                        matrix[playerRowD][playerColD] = '.';
                    }

                    break;
                default:
                    break;
            }

            return isDeadisWon;

        }

        private static int[] FindPlayer(char[][] matrix)
        {
            var array = new int[2];

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'P')
                    {
                        array[0] = i;
                        array[1] = j;
                        return array;
                    }
                }
            }

            return array;
        }
    }
}
