namespace _04.Largest_3_Numbers
{
    using System;   
    using System.Linq;

    public class DictionariesLambdaLinq
    {
        public static void Main()
        {
            var listOfRealNumber = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .OrderByDescending(x => x)
                .Take(3)
                .ToList();

            Console.WriteLine(string.Join(" ", listOfRealNumber));
        }
    }
}
