namespace _04.ConvertFromBase_10ToBase_N
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;


    public class ConvertFromBase10ToN
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

            BigInteger number = BigInteger.Parse(input[1]);
            BigInteger basedN = BigInteger.Parse(input[0]);
            Stack<BigInteger> result = new Stack<BigInteger>();

            while (number != 0)
            {
                BigInteger rest = number % basedN;
                result.Push(rest);
                number /= basedN;
            }

            while (result.Count > 0)
            {
                Console.Write(result.Pop());
            }

            Console.WriteLine();
        }
    }
}
