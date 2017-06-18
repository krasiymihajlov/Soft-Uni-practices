namespace _07.SumBigNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumBigNumbers
    {
        public static void Main()
        {
            string firstNumber = Console.ReadLine().TrimStart('0');
            string secondNumber = Console.ReadLine().TrimStart('0');
            List<string> collection = new List<string>();
            collection.Add(firstNumber);
            collection.Add(secondNumber);

            string smaller = collection.OrderBy(x => x.Length).First();
            string bigger = collection.OrderBy(x => x.Length).Last();
            int transfer = 0;
            string sum = string.Empty;

            for (int i = 0; i < smaller.Length; i++)
            {
                int first = int.Parse(firstNumber[firstNumber.Length - 1 - i].ToString()) + transfer;
                int second = int.Parse(secondNumber[secondNumber.Length - 1 - i].ToString());

                int total = first + second;


                if (total >= 10)
                {
                    sum += (total % 10);
                    transfer = total / 10;
                }
                else
                {
                    transfer = 0;
                    sum += total;
                }
            }

            int diffLength = bigger.Length - smaller.Length;

            for (int i = diffLength - 1; i >= 0; i--)
            {
                int total = transfer + int.Parse(bigger[i].ToString());

                if (total >= 10)
                {
                    sum += (total % 10);
                    transfer = total / 10;
                }
                else
                {
                    transfer = 0;
                    sum += total;
                }
            }

            if (transfer > 0)
            {
                sum += transfer;
            }

            IEnumerable<char> result = sum.Reverse();
            Console.WriteLine(string.Join("", result));

        }
    }
}
