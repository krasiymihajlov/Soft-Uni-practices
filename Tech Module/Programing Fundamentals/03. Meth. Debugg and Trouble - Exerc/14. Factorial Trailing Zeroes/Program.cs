namespace _14.Factorial_Trailing_Zeroes
{
    using System;
    using System.Numerics;

    public class Methods
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger factoriel = 1;

            for (int i = 1; i <= n; i++)
            {
                factoriel *= i;
            }

            int timesZero = 0;
            BigInteger factorielDivider = factoriel;
            while (factorielDivider % 10 == 0)
            {
                timesZero++;
                factorielDivider = factorielDivider / 10;               
            }

            Console.WriteLine(timesZero);
        }
    }
}
