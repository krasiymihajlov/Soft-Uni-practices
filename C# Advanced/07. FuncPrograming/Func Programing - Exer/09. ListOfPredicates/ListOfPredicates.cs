namespace _09.ListOfPredicates
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class ListOfPredicates
    {
        public static void Main()
        {
            int endNumber = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            GetNumbers(endNumber, dividers);
        }

        public static void GetNumbers(int end, int[] numbs)
        {
            List<int> result = new List<int>();
            for (int i = 1; i <= end; i++)
            {
                bool correct = true;
                for (int j = 0; j < numbs.Length; j++)
                {
                    if (!(i % numbs[j] == 0))
                    {
                        correct = false;
                        break;
                    }
                }

                if (correct)
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
