namespace _01.Convert_from_base_10_to_base_N
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    public class StringExercises
    {
        public static void Main()
        {
            BigInteger[] input = Console.ReadLine().Split().Select(BigInteger.Parse).ToArray();
            var basedN = input[0];
            var based10 = input[1];

            var result = new List<BigInteger>();           

            while (based10 != 0)
            {
                BigInteger rest = based10 % basedN;
                result.Add(rest);
                based10 = based10 / basedN;
            }

            result.Reverse();
            Console.WriteLine(string.Join("", result));            
        }
    }
}
