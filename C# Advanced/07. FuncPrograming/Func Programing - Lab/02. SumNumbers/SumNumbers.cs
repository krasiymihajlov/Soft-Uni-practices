using System.Collections.Generic;

namespace _02.SumNumbers
{
    using System;
    using System.Linq;

    public class SumNumbers
    {
        public static void Main()
        {
            Console.WriteLine(Console.ReadLine()
                .Split(new string[] { ", " },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray().PrtintSumAndCount());
        }
    }

    public static class Print
    {
        public static string PrtintSumAndCount(this int[] arr)
        {
            return $"{arr.Length}\n{arr.Sum()}";

        }
    }
}
