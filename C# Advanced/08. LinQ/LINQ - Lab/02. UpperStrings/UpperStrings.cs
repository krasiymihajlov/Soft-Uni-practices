namespace _02.UpperStrings
{
    using System;
    using System.Linq;

    public class UpperStrings
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split()
                .Select(w => w.ToUpper())
                .ToList()
                .ForEach(w => Console.Write(w + " "));
        }
    }
}
