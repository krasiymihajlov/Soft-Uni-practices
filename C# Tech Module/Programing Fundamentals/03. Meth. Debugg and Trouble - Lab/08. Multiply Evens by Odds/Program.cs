namespace _08.Multiply_Evens_by_Odds
{
    using System;

    public class MultiplyEvensByOdds
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());      
                  
            Console.WriteLine(GetMultipleOfEvenAndOdd(number));
        }

        public static int GetMultipleOfEvenAndOdd(int number)
        {
            int result = Math.Abs(GetSumOfEvenDigits(number) * GetSumOfOddDigits(number));
            return result;
        }

        public static int GetSumOfOddDigits(int number)
        {
            var result = 0;

            foreach (var symbol in number.ToString())
            {
                var digit = symbol - '0';
                if (digit % 2 == 1)
                {
                    result += digit;
                }                            
            }
           
            return result;
        }

        public static int GetSumOfEvenDigits(int number)
        {
            var result = 0;

            foreach (var symbol in number.ToString())
            {
                var digit = symbol - '0';
                if (digit % 2 == 0)
                {
                    result += digit;
                }
            }

            return result;
        }
    }
}