

namespace _02.SoftUniParty
{
    using System;
    using System.Collections.Generic;

    public class SoftUniParty
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var set = new SortedSet<string>();

            while (input != "END")
            {
                set.Add(input);

                if (input == "PARTY")
                {
                    while (input != "END")
                    {
                        set.Remove(input);
                        input = Console.ReadLine();
                    }

                    break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(set.Count);

            foreach (var number in set)
            {
                Console.WriteLine(number);
            }

        }
    }
}
