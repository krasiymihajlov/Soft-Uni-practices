namespace _12.Master_Number
{
    using System;    

    public class Methods
    {
        public static void Main()
        {
            int masterNumber = int.Parse(Console.ReadLine());
            string value = masterNumber.ToString();

            for (int counter = 1; counter <= masterNumber; counter++)
            {
                if (IsPalindrome(counter.ToString()) && SumOfDigits(counter) && ContainsEvenDigit(counter))
                {
                    Console.WriteLine(counter);
                }
            }
        }

        public static bool IsPalindrome(string value)
        {
            int min = 0;
            int max = value.Length - 1;
            while (true)
            {
                if (min > max)
                {
                    return true;
                }

                char a = value[min];
                char b = value[max];
                if (char.ToLower(a) != char.ToLower(b))
                {
                    return false;
                }

                min++;
                max--;
            }
        }

        public static bool SumOfDigits(int value)
        {
            int sum = 0;
            while (value > 0)
            {
                int currentValue = value % 10;
                sum = sum + currentValue;
                value = value / 10;  
            }

            if (sum % 7 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ContainsEvenDigit(int value)
        {            
            while (value > 0)
            {
                int even = value % 10;
                if (even % 2 == 0)
                {
                    return true;
                }

                value = value / 10;
            }

            return false;
        }
    }
}
