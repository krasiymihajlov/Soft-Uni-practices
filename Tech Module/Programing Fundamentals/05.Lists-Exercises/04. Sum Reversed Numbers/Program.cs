namespace _04.Sum_Reversed_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListsExrcises
    {
        public static void Main()
        {
            var sequenceOfElements = Console.ReadLine().Split(' ').ToList();

            var reversesDigits = new List<string>();

            for (int i = 0; i < sequenceOfElements.Count; i++)
            {
                var reversElement = Reverse(sequenceOfElements[i]);
                reversesDigits.Add(reversElement);                               
            }

            var sum = reversesDigits.Select(x => int.Parse(x)).Sum();
            Console.WriteLine(sum);
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
