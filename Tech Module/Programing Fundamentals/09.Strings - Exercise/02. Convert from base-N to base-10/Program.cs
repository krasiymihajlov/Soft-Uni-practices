namespace _02.Convert_from_base_N_to_base_10
{
    using System;
    using System.Numerics;

    public class StringExercises
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var basedN = BigInteger.Parse(input[0]);
            var based10 = BigInteger.Parse(input[1]);

            var count = 0;
            BigInteger rest = 0;

            while (based10 != 0)
            {
                var lastDigit = based10 % 10;
                rest += (lastDigit * Pow(count, basedN));
                count++;

                based10 = based10 / 10;
            }
       
            Console.WriteLine(rest);
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