namespace _13.Vowel_or_Digit
{
    using System;

    public class DateAndTypesExercises
    {
        public static void Main()
        {
            char symbol = char.Parse(Console.ReadLine().ToLower());
            bool digit = "0123456789".IndexOf(symbol) >= 0;
            bool letter = "aoueiy".IndexOf(symbol) >= 0;
            if (digit)
            {
                Console.WriteLine("digit");
            }
            else if (letter)
            {
                Console.WriteLine("vowel");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}
