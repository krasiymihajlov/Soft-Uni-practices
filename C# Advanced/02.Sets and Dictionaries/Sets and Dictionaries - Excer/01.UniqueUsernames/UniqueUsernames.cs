namespace _01.UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    public class UniqueUsernames
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var set = new HashSet<string>();

            for (int i = 0; i < number; i++)
            {
                var name = Console.ReadLine();

                set.Add(name);
            }

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }

        }
    }
}
