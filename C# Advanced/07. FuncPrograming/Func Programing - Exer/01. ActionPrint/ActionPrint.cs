namespace _01.ActionPrint
{
    using System;

    public class ActionPrint
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();

            Action<string> print = p => Console.WriteLine(p);

            foreach (var name in input)
            {
                print(name);
            }
        }
    }
}
