namespace _3.SquaresInMatrix
{
    using System;
    using System.Linq;

    public class SquaresInMatrix
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = input[0];
            var cols = input[1];
            var matrix = new string[rows][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            var countSquere = 0; 
            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[i].Length; j++)
                {
                    var currentSymbol = matrix[i - 1][j - 1];

                    if (matrix[i - 1][j] == currentSymbol 
                        &&  matrix[i][j - 1] == currentSymbol 
                        && matrix[i][j] == currentSymbol)
                    {
                        countSquere++;
                    } 
                }
            }

            Console.WriteLine(countSquere);
        }
    }
}
