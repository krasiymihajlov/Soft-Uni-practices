namespace _06.Sum_big_numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StringsExercises
    {
        public static void Main()
        {
            var firstNum = Console.ReadLine().TrimStart('0');
            var secondNum = Console.ReadLine().TrimStart('0');

            var list = new List<string>();
            list.Add(firstNum);
            list.Add(secondNum);
            var shorter = list.OrderBy(x => x.Count()).First();
            var longer = list.OrderBy(x => x.Count()).Last();

            var result = new StringBuilder();
            var transfer = 0;

            for (int i = 0; i < shorter.Length; i++)
            {
                var numerator = int.Parse(firstNum[firstNum.Length - 1 - i].ToString()) + transfer;
                var denominator = int.Parse(secondNum[secondNum.Length - 1 - i].ToString());

                transfer = 0;
                var total = numerator + denominator;

                if (total >= 10)
                {
                    transfer = total / 10;
                    result.Append(total % 10);
                }
                else
                {
                    result.Append(total);
                }
            }

            var diffLenght = longer.Length - shorter.Length;

            for (int i = diffLenght - 1; i >= 0; i--)
            {
                var total = transfer + int.Parse(longer[i].ToString());

                if (total >= 10)
                {
                    transfer = total / 10;
                    result.Append(total % 10);
                }
                else
                {
                    transfer = 0;
                    result.Append(total);
                }
            }

            if (transfer > 0)
            {
                result.Append(transfer);
            }

            var resultToString = result.ToString().Reverse();

            Console.WriteLine(string.Join("", resultToString));
        }
    }
}
