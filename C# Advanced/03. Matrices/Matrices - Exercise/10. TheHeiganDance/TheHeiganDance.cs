namespace _10.TheHeiganDance
{
    using System;

    public class TheHeiganDance
    {
        public static void Main()
        {
            var matrix = InitializeMatrix();

            StartPlaying(matrix);
        }

        private static void StartPlaying(int[][] matrix)
        {
            var damage = double.Parse(Console.ReadLine());

            while (true)
            {
                var line = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var magic = line[0];
                var spellRow = int.Parse(line[1]);
                var spellCol = int.Parse(line[2]);

                InRange(spellRow, spellCol, matrix);
            }
        }

        private static bool InRange(int spellRow, int spellCol, int[][] matrix)
        {
            for (int i = 0; i < length; i++)
            {

            }
        }

        private static int[][] InitializeMatrix()
        {
            var matrix = new int[15][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[15];
            }

            return matrix;
        }
    }
}
