namespace _04.Character_Multiplier
{
    using System;
    using System.Collections.Generic;

    public class StringExercises
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var firstWord = input[0];
            var secondWord = input[1];

            var firstList = GetCharacterCodeMultiply(firstWord);
            var secondList = GetCharacterCodeMultiply(secondWord);

            var minLenth = Math.Min(firstList.Count, secondList.Count);
            var maxLenth = Math.Max(firstList.Count, secondList.Count);
            var diffLenth = maxLenth - minLenth;
            var result = 0;

            for (int i = 0; i < minLenth; i++)
            {
                result += firstList[i] * secondList[i];
            }

            if (firstList.Count > secondList.Count)
            {
                for (int i = maxLenth - 1 ; i >= minLenth; i--)
                {
                    result += firstList[i];
                }
            }
            else if (secondList.Count > firstList.Count)
            {
                for (int i = maxLenth - 1; i >= minLenth; i--)
                {
                    result += secondList[i];
                }
            }

            Console.WriteLine(result);
        }

        public static List<int> GetCharacterCodeMultiply(string firstWord)
        {
            var list = new List<int>();
            foreach (var symbol in firstWord)
            {
                var result = (int)symbol;
                list.Add(result);
            }

            return list;
        }
    }
}
