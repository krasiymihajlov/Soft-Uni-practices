namespace _09.Refactor_Special_Numbers
{
    using System;

    public class DateAndTypesLab
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());           
            for (int currentNumber = 1; currentNumber <= number; currentNumber++)
            {
                int digits = currentNumber;
                int sumDigits = 0;
                while (digits > 0)
                {
                    sumDigits += digits % 10;
                    digits = digits / 10;
                }
                bool special = (sumDigits == 5 || sumDigits == 7 || sumDigits == 11);
                Console.WriteLine($"{currentNumber} -> {special}");                                
            }

        }
    }
}
