namespace _11.Equal_Sums
{
    using System;
    using System.Linq;

    public class ArraysExercises
    {
        public static void Main()
        {
            var elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int leftSum = 0;
            int rightSum = 0;
            bool isEqual = true;
            int separator = 0;

            for (separator = 0; separator < elements.Length; separator++)
            {
                leftSum = 0;
                rightSum = 0;
                for (int i = 0; i < separator; i++)
                {
                    leftSum += elements[i];
                }

                for (int j = elements.Length - 1; j > separator; j--)
                {
                    rightSum += elements[j];
                }

                if (leftSum == rightSum)
                {
                    isEqual = false;
                    Console.WriteLine(separator);
                    break;
                }
            }

            if (isEqual && separator != 0)
            {
                Console.WriteLine("no");
            }
            else if (separator == 0 && isEqual)
            {
                Console.WriteLine(0);
            }
        }
    }
}
