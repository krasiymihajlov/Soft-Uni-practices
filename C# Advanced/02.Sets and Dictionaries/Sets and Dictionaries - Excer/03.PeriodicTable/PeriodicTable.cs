namespace _03.PeriodicTable
{
    using System;
    using System.Collections.Generic;

    public class PeriodicTable
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var set = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var chemicalCopm = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < chemicalCopm.Length; j++)
                {
                    set.Add(chemicalCopm[j]);
                }
            }

            Console.WriteLine(string.Join(" ", set));
        }
    }
}
