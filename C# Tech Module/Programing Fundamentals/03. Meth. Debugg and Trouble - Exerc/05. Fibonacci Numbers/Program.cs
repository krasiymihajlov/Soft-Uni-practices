namespace _05.Fibonacci_Numbers
{
    using System;

    public class FibonacciNumbers
    {
        public static void Main()
        {
            long number = long.Parse(Console.ReadLine());
            long fibonaciiNumber = GetFibonaciiNumber(number);
            Console.WriteLine(fibonaciiNumber);
        }

        public static long GetFibonaciiNumber(long number)
        {
            long result = 1;
            long lastNumber = 0;
            long reverse;           
            for (int currentnumber = 1; currentnumber <= number; currentnumber++)
            {
                reverse = lastNumber;
                lastNumber = result;
                result = reverse + lastNumber;
            }

            return result;
        }
    }
}
