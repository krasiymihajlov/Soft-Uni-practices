namespace _06.Prime_Checker
{
    using System;

    public class Program
    {
        public static void Main()
        {
            long number = long.Parse(Console.ReadLine());
            GetPrimeNumber(number);
        }

        public static void GetPrimeNumber(long number)
        {
            bool prime = true;
            long divider = 2;
            long maxDivider = (long)Math.Sqrt(number);
            while (prime && (divider <= maxDivider))
            {
                if (number % divider == 0)
                {
                    prime = false;
                }
                divider++;
            }

            if (number > 1)
            {
                Console.WriteLine(prime);
            }
            else
            {
                prime = false;
                Console.WriteLine(prime);
            }
        }
    }
}
