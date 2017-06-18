namespace _04.AcademyGraduation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AcademyGraduation
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var academy = new Dictionary<string, double>();

            for (int i = 0; i < number; i++)
            {
                var name = Console.ReadLine().Trim();
                var rating = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .Average();

                if (!academy.ContainsKey(name))
                {
                    academy.Add(name, rating);
                }
                else
                {
                    academy[name] += rating;
                }
            }

            foreach (var name in academy.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{name.Key} is graduated with {name.Value}");
            }
        }
    }
}
