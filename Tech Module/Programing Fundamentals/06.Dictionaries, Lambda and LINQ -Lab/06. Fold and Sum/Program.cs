namespace _06.Fold_and_Sum
{
    using System;   
    using System.Linq;

    public class DictionariesLambdaLinqLab
    {
        public static void Main()
        {
            var list = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int k = list.Count / 4;

            var startQuarter = list
                .Take(k)
                .Reverse()
                .ToList();

            var lastQuarter = list
                .Skip(3 * k)
                .Take(k)
                .Reverse()
                .ToList();

            var firstList = startQuarter.Concat(lastQuarter).ToList();

            var secondList = list
                .Skip(k)
                .Take(2 * k)
                .ToList();

            var sum = firstList
                .Select((x, index) => x + secondList[index]);

            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
