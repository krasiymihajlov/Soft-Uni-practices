namespace _01.Largest_Common_End
{
    using System;
    using System.Linq;

    public class ArraysExercises
    {
        public static void Main()
        {
            string[] firstText = Console.ReadLine().Split(' ').ToArray();
            string[] secondText = Console.ReadLine().Split(' ').ToArray();

            int leftCounter = 0;
            int rightCounter = 0;
            int minLenght = Math.Min(firstText.Length, secondText.Length);

            for (int i = 0; i < minLenght; i++)
            {
                if (firstText[i] == secondText[i])
                {
                    leftCounter++;
                }
            }

            int different = Math.Max(firstText.Length, secondText.Length) - minLenght;

            for (int i = minLenght - 1; i >= 0; i--)
            {
                if (firstText.Length < secondText.Length && firstText[i] == secondText[different + i])
                {
                    rightCounter++;
                }
                else if (secondText.Length < firstText.Length && secondText[i] == firstText[different + i])
                {
                    rightCounter++;
                }
            }

            Console.WriteLine(Math.Max(leftCounter, rightCounter));
        }
    }
}
