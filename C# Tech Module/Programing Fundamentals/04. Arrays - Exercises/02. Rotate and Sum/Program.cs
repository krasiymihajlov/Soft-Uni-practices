namespace _02.Rotate_and_Sum
{
    using System;
    using System.Linq;

    public class ArraysExercises
    {
        public static void Main()
        {
            int[] rotateNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rotator = int.Parse(Console.ReadLine());
            int[] rotatedN = new int[rotateNumbers.Length];
            int[] Sum = new int[rotateNumbers.Length];

            for (int i = 0; i < rotator; i++)
            {
                for (int j = 0; j < rotateNumbers.Length; j++)
                {
                    int r = (j + 1) % rotatedN.Length;
                    rotatedN[r] = rotateNumbers[j];
                    Sum[r] += rotatedN[r];
                }

                for (int m = 0; m < rotateNumbers.Length; m++)
                {
                    rotateNumbers[m] = rotatedN[m];
                }
            }

            Console.WriteLine(string.Join(" ", Sum));
        }
    }
}