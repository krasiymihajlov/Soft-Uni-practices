namespace _07.Primes_in_Given_Range
{
    using System;    
    using System.Collections.Generic;

    public class Methods
    {
        public static void Main()
        {
            var startNum = int.Parse(Console.ReadLine());
            var endNum = int.Parse(Console.ReadLine());

            var primesInRange = ItsPrime(startNum, endNum);
            Console.Write(string.Join(", ", primesInRange));
        }

        public static List<int> ItsPrime(int startNum, int endNum)
        {
            var primes = new List<int>();
            for (int currentNum = startNum; currentNum <= endNum; currentNum++)
            {
                if (GetPrimeNumber(currentNum))
                {
                    primes.Add(currentNum);
                }
            }

            return primes;
        }

        public static bool GetPrimeNumber(long number)
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
            }
            else
            {
                prime = false;                
            }

            return prime;
        }
    }
}
