namespace _01.Day_of_Week
{
    using System;

    public  class Arrays
    {
        public static void Main()
        {
            var enterDay = int.Parse(Console.ReadLine());
            string[] dayOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
                       
            if (enterDay <= 0 || enterDay > 7)
            {
                Console.WriteLine("Invalid Day!");
            }
            else
            {
                Console.WriteLine(dayOfWeek[enterDay - 1]);
            }
        }
    }
}
