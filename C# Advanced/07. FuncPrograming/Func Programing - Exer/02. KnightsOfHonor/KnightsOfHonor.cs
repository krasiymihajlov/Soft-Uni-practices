namespace _02.KnightsOfHonor
{
    using System;

    public class KnightsOfHonor
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = p => Console.WriteLine($"Sir {p}");

            foreach (var name in input)
            {
                print(name);
            }
        }
    }
}
