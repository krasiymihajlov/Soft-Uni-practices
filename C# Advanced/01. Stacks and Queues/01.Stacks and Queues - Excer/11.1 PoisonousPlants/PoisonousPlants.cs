namespace _11.Poisonous_Plants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PoisinousPlants
    {
        public static void Main()
        {
            var plants = int.Parse(Console.ReadLine());
            var plantsLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var plantsIndex = new Stack<int>();
            plantsIndex.Push(0);
            var days = new int[plants];

            for (int i = 1; i < plantsLine.Length; i++)
            {
                int maxDays = 0;

                while (plantsIndex.Count > 0 && plantsLine[plantsIndex.Peek()] >= plantsLine[i])
                {
                    maxDays = Math.Max(maxDays, days[plantsIndex.Pop()]);
                }

                if (plantsIndex.Count > 0)
                {
                    days[i] = maxDays + 1;
                }

                plantsIndex.Push(i);
            }

            Console.WriteLine(days.Max());
           
        }
    }
}
