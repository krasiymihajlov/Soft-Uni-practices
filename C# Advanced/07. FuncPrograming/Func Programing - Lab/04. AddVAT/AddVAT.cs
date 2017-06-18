namespace _04.AddVAT
{
    using System;
    using System.Linq;

    public class AddVAT
    {
        public static void Main()
        {
            Console.WriteLine(string.Join(Environment.NewLine, 
                Console.ReadLine()
                .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x => $"{x * 1.2:F2}")
                .ToList()));
        }
    }
}
