namespace _08.MultiplyBigNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MultiplyBigNumber
    {
        public static void Main()
        {
            string firstNumber = Console.ReadLine().TrimStart('0');
            long secondNumber = long.Parse(Console.ReadLine());

            if (secondNumber == 0)
            {
                Console.WriteLine(0);
                return;
            }

            long transfer = 0;
            string sum = string.Empty;

            for (int i = 0; i < firstNumber.Length; i++)
            {
                long lastDigit = long.Parse(firstNumber[firstNumber.Length - 1 - i].ToString());
                long total = (lastDigit * secondNumber) + transfer;

                if (total >= 10)
                {
                    sum += total % 10;
                    transfer = total / 10;
                }
                else
                {
                    sum += total;
                    transfer = 0;
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
