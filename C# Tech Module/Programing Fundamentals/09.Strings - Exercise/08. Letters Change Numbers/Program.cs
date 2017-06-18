namespace _08.Letters_Change_Numbers
{
    using System;
    using System.Text.RegularExpressions;
    using System.Linq;
    using System.Text;

    public class StringExercises
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            var regexBigger = new Regex(@"[A-Z]");
            var regexSmaller = new Regex(@"[a-z]");

            var sb = new StringBuilder();
            var number = 0M;

            for (int i = 0; i < input.Length; i++)
            {
                var word = input[i];
                var firstLetter = word.First();
                var lastLetter = word.Last();                

                for (int j = 1; j < word.Length - 1; j++)
                {
                    sb.Append(word[j]);
                }

                var currentNumber = decimal.Parse(sb.ToString());
                sb.Clear();

                if (regexBigger.IsMatch(firstLetter.ToString()))
                {
                    var firstDigit = (decimal)firstLetter - 'A' + 1;
                    currentNumber = currentNumber / firstDigit;
                }
                else 
                {
                    var firstDigit = (decimal)firstLetter - 'a' + 1;
                    currentNumber = currentNumber * firstDigit;
                }

                if (regexBigger.IsMatch(lastLetter.ToString()))
                {
                    var lastDigit = (decimal)lastLetter - 'A' + 1;
                    currentNumber = currentNumber - lastDigit;
                }
                else
                {
                    var lastDigit = (decimal)lastLetter - 'a' + 1;
                    currentNumber = currentNumber + lastDigit;
                }
                
                number += currentNumber;               
            }

            Console.WriteLine($"{number:F2}");
        }
    }
}
