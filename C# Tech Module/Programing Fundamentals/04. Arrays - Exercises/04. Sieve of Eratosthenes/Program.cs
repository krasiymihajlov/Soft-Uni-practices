namespace _04.Sieve_of_Eratosthenes
{
    using System;    

    public class ArraysExercise
    {
        public static void Main()
        {
            int range = int.Parse(Console.ReadLine());
            bool[] primes = new bool[range + 1];

            for (int number = 0; number <= range; number++)
            {
                primes[number] = true;
            }

            primes[0] = false;
            primes[1] = false;

            for (int counter = 0; counter < primes.Length; counter++)
            {
                if (primes[counter])
                {
                    for (int multiplier = 2; (multiplier * counter) < primes.Length; multiplier++)
                    {
                        primes[multiplier * counter] = false;
                    }
                }                    
            }

            for (int i = 0; i < primes.Length; i++)
            {
                if(primes[i])
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
