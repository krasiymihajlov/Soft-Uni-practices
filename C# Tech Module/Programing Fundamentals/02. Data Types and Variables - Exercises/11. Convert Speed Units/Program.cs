﻿namespace _11.Convert_Speed_Units
{
    using System;
     
    public class DateAndTypesExercises
    {
        public static void Main()
        {
            int meters = int.Parse(Console.ReadLine());
            int inputHours = int.Parse(Console.ReadLine());
            int inputMinutes = int.Parse(Console.ReadLine());
            int inputSeconds = int.Parse(Console.ReadLine());
            float seconds = (((60f * inputHours) + inputMinutes) * 60f) + inputSeconds;
            float hours = (inputMinutes / 60f) + (inputSeconds / 3600f) + inputHours;
            float mile = (meters / 1609f);
            float meterPerSeconds = meters / seconds;
            float kilometerPerHours = (meters / 1000f) / hours;
            float milePerHours = (mile / hours );

            Console.WriteLine(meterPerSeconds);
            Console.WriteLine(kilometerPerHours);
            Console.WriteLine(milePerHours);
        }
    }
}
