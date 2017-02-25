namespace _04.Numbers_in_Reversed_Order
{
    using System;

    public class NumbersInReversedOrder
    {
        public static void Main()
        {
            string number = Console.ReadLine();
            ReverseNumber(number);
        }

        public static void ReverseNumber(string number)
        {
            int counter = 1;
            var result = "";
            for (decimal i = number.Length; i > 0; i--)
            {
                char digit = number[number.Length - counter];
                result += digit;
                counter++;
            }

            Console.WriteLine(result);
        }
    }
}
