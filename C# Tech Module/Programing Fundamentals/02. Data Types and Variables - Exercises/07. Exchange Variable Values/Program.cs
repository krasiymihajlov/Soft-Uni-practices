namespace _07.Exchange_Variable_Values
{
    using System;

    public class DateAndTypesExercises
    {
        public static void Main()
        {
            int a = 5;
            int b = 10;
            Console.WriteLine("Before:");
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");
            int c = a; a = b;
            Console.WriteLine("After:");
            Console.WriteLine($"a = {b}");
            Console.WriteLine($"b = {c}");
        }
    }
}
