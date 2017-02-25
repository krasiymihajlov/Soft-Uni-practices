namespace _03.English_Name_of_Last_Digit
{
    using System;

    public class EnglishNameOFLastDigit
    {
        public static void Main()
        {
            long number = long.Parse(Console.ReadLine());
            number = Math.Abs(number);
            ReadLastDigit(number);
        }

        public static void ReadLastDigit(long number)
        {
            long result = number % 10;
            ReadNumberEnglishName(result);
        }

        public static void ReadNumberEnglishName(long result)
        {
            string[] numberEnglishName = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            Console.WriteLine(numberEnglishName[result]);
        }
    }
}