namespace EngName_of_Last_Digit
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            number = GetLastNumber(number);
            string[] verbalNums = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            
            Console.WriteLine(verbalNums[GetLastNumber(number)]);

        }

        public static int GetLastNumber(int tempNumber)
        {
            return Math.Abs(tempNumber %= 10);
        }
    }
}