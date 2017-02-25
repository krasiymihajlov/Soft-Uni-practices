namespace _03.Last_K_Numbers_Sums
{
    using System;    

    public class Arrays
    {
        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());
            var k = long.Parse(Console.ReadLine());
            var outputNumbers = new long[n];
            long sum = 1;
            outputNumbers[0] = 1;

            for (int i = 1; i < outputNumbers.Length; i++)
            {
                
                if (k > i)
                {
                    outputNumbers[i] = sum;
                }
                else
                {
                    for (int j = 0; j < k; j++)
                    {
                        outputNumbers[i] += outputNumbers[i - k + j];                                            
                    }                   
                }

                sum += outputNumbers[i];
            }
            Console.WriteLine(string.Join(" ", (outputNumbers)));
        }
    }
}
