namespace _06.FindAndSumIntegers
{
    using System;
    using System.Linq;

    public class FindAndSumIntegers
    {
        public static void Main()
        {
            double[] line = Console.ReadLine()
                .Split()
                .Select(n =>
                {
                    double number;
                    bool isNumber = double.TryParse(n, out number);
                    return new {number, isNumber};
                })
                .Where(n => n.isNumber)
                .Select(n => n.number)
                .ToArray();

            Console.WriteLine(line.Length != 0 ? line.Sum().ToString() : "No match");
        }
    }
}
