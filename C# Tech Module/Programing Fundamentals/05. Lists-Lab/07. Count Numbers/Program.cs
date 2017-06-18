namespace _07.Count_Numbers
{
    using System;
    using System.Linq;

    public class Lists
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            numbers.Add(int.MaxValue);
            numbers.Sort();           
            int count = 1;                    

            for (int i = 0; i < numbers.Count - 1 ; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    count++;
                }
                else
                {
                    Console.WriteLine($"{string.Join(" ", numbers[i])} -> {count}");
                    count = 1;
                }
            }
        }
    }
}
