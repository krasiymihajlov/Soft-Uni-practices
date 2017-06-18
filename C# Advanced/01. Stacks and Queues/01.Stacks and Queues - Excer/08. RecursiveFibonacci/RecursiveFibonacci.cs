namespace _08.RecursiveFibonacci
{
    using System;

    public class RecursiveFibonacci
    {
        public static void Main()
        {
            long number = long.Parse(Console.ReadLine());
            Console.WriteLine(FibonacciNumber(0, 1, 1, number));
        }


        public static long FibonacciNumber(long a, long b, long counter, long number)
        {
            if (number <= 0)
            {
                return 0;
            }
            else if (number == 1)
            {
                return 1;
            }
            else
            {
                if (number < counter)
                {
                    return a;
                }
                return FibonacciNumber(b, a + b, counter + 1, number);
            }
            
        }
    }
}
