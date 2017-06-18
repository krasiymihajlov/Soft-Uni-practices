namespace _01.Day_of_Week
{
    using System;
    using System.Globalization;

    public class ObjectAndClasses
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var date = DateTime.ParseExact(input, "d-M-yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine(date.DayOfWeek);
            Console.WriteLine(date.Year);
            Console.WriteLine(date.Month);
            Console.WriteLine(date.Day);

        }
    }
}
