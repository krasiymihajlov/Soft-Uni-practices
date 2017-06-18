namespace _04.FindEvensOrOdds
{
    using System;
    using System.Linq;

    public class FindEvensOrOdds
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            int startNumber = numbers[0];
            int endNumber = numbers[1];
            Predicate<int> EvenOrOdd = n => n % 2 == 0;

            if ("even" == command)
            {
                for (int i = startNumber; i <= endNumber; i++)
                {
                    if (EvenOrOdd(i) )
                    {
                        Console.Write($"{i} ");
                    }
                }
            }
            else
            {
                for (int i = startNumber; i <= endNumber; i++)
                {
                    if (!EvenOrOdd(i))
                    {
                        Console.Write($"{i} ");
                    }
                }
            }
  
        }
    }
}
