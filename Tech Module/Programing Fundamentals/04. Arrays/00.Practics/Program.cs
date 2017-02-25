namespace _08.Condense_Array_to_Number
{
    using System;
    using System.Linq;

    public class Arrays
    {
        public static void Main()
        {
            int[] numbersOfArrays = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = numbersOfArrays.Length; i > 1; i--)
            {
                if (numbersOfArrays.Length > 1)
                {
                    int[] secondArrays = new int[numbersOfArrays.Length - 1];
                    for (int j = 0; j < numbersOfArrays.Length - 1; j++)
                    {
                        secondArrays[j] = numbersOfArrays[j] + numbersOfArrays[j + 1];
                    }

                    numbersOfArrays = secondArrays;
                }
            }

            Console.WriteLine(string.Join(" ", numbersOfArrays));
        }
    }
}