namespace _02.Longest_Increasing_Subsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListsExercises
    {
        public static void Main()
        {
            var listOfNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var length = new int[listOfNumbers.Length];
            var prevLength = new int[listOfNumbers.Length];
            var maxLength = 0;
            var lastIndex = -1;
            for (int i = 0; i < listOfNumbers.Length; i++)
            {
                length[i] = 1;
                prevLength[i] = -1;
                for (int j = 0; j < i; j++)
                {
                    if (listOfNumbers[j] < listOfNumbers[i] && length[j] + 1 > length[i])
                    {
                        length[i] = 1 + length[j];
                        prevLength[i] = j;
                    }

                    if (length[i] > maxLength)
                    {
                        maxLength = length[i];
                        lastIndex = i;
                    }
                }

                if (listOfNumbers.Length == 1)
                {
                    lastIndex = i;
                }
            }

            Console.WriteLine(string.Join(" ", RestoreLIS(listOfNumbers, prevLength, lastIndex)));

        }

        public static int[] RestoreLIS(int[] listOfNumbers, int[] prev, int lastIndex)
        {
            var longestSeq = new List<int>();
            while (lastIndex != -1)
            {
                longestSeq.Add(listOfNumbers[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            longestSeq.Reverse();

            return longestSeq.ToArray();
        }
    }
}
