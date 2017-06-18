namespace _01.MatrixOfPalindromes
{
    using System;
    using System.Linq;

    public class MatrixOfPalindromes
    {
        public static void Main()
        {
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var row = line[0];
            var col = line[1];

            var matrix = new string[row][];
            var text = string.Empty;

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int i = 0; i < row; i++)
            {
                matrix[i] = new string[col];
                var mainChar = alphabet[i];

                for (int j = 0; j < col; j++)
                {
                    var varChar = alphabet[(i + j) % 26];

                    matrix[i][j] = mainChar.ToString() + varChar + mainChar;
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine($"{string.Join(" ", matrix[i])}");
            }

        }
    }
}
