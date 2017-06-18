namespace _05.Sort_Numbers
{
    using System;
    using System.Linq;

    public class ListsLab
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(decimal.Parse).ToList();

            numbers.Sort();
            Console.WriteLine(string.Join(" <= ", numbers));
        }
    }
}
