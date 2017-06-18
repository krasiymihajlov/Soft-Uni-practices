namespace _02.SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SetsOfElements
    {
        public static void Main()
        {
            var length = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var firstSet = new SortedSet<int>();
            var secondSet = new SortedSet<int>();

            for (int i = 0; i < length.Sum(); i++)
            {
                var number = int.Parse(Console.ReadLine());

                if(i < length[0])
                {
                    firstSet.Add(number);
                }
                else
                {
                    if(firstSet.Contains(number))
                    {
                        secondSet.Add(number);
                    }
                }

            }

            foreach (var item in secondSet)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }
    }
}
