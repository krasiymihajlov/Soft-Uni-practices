namespace _01.Remove_Negatives_and_Reverse
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Lists
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> newList = new List<int>();
            int count = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > 0)
                {
                    newList.Add(numbers[i]);
                    count++;
                }                               
            }

            newList.Reverse();

            if (count != 0)
            {
                Console.WriteLine(string.Join(" ", newList));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}
