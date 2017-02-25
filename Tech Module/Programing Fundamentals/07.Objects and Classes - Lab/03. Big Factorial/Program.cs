namespace _03.Big_Factorial
{
    using System;
    using System.Numerics;

    public class ObjectAndClasses
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            BigInteger factoriel = 1;

            for (int i = number; i > 1; i--)
            {
                factoriel *= i;
            }

            Console.WriteLine(factoriel);
        }
    }
}
