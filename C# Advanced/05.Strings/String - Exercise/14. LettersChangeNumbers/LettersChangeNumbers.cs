namespace _14.LettersChangeNumbers
{
    using System;

    public class LettersChangeNumbers
    {
        public static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

            decimal result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                string word = input[i];
                char firstSymbol = word[0];
                char lastSymbol = word[word.Length - 1];
                decimal number = decimal.Parse(word.Substring(1, word.Length - 2));
                number = StartMath(firstSymbol, number);
                number = EndMath(lastSymbol, number);

                result += number;
            }

            Console.WriteLine($"{result:F2}");
        }

        private static decimal EndMath(char lastSymbol, decimal number)
        {
            if (char.IsUpper(lastSymbol))
            {
                number -= ((int)lastSymbol - 'A' + 1);
            }
            else
            {
                number += ((int)lastSymbol - 'a' + 1);
            }

            return number;
        }

        private static decimal StartMath(char firstSymbol, decimal number)
        {
            if (char.IsUpper(firstSymbol))
            {
                number /= ((int)firstSymbol - 'A' + 1);
            }
            else
            {
                number *= ((int)firstSymbol - 'a' + 1);
            }

            return number;
        }
    }
}
