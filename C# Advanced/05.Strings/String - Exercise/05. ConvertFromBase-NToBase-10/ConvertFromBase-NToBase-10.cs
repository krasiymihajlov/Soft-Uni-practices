namespace _05.ConvertFromBase_NToBase_10
{
    using System;
    using System.Numerics;

    public class ConvertFromBaseNTo10
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

            BigInteger number = BigInteger.Parse(input[1]);
            BigInteger basedN = BigInteger.Parse(input[0]);
            BigInteger result = 0;
            int count = 0;

            while (number != 0)
            {
                BigInteger lastDigit = number % 10;
                result += lastDigit * Pow(count, basedN);
                count++; 
                number /= 10;
            }
            
            Console.WriteLine(result);
        }

        public static BigInteger Pow(int count, BigInteger digit)
        {
            BigInteger result = 1;

            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    result *= digit;
                }
                return result;
            }
            else
            {
                return 1;
            }
        }
    }
}
