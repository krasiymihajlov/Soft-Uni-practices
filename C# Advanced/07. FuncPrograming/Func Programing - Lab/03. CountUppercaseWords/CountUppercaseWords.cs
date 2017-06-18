namespace _03.CountUppercaseWords
{
    using System;
    using System.Linq;

    public class CountUppercaseWords
    {
        public static void Main()
        {
            Console.WriteLine(string.Join("\n",
                Console.ReadLine().
                    Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(x => char.ToUpper(x[0]) == x[0])));
        }
    }
}
