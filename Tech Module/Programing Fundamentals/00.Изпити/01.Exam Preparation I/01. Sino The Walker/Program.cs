namespace _01.Sino_The_Walker
{
    using System;
    using System.Globalization;

    public class ExamPreparationI
    {
        public static void Main()
        {
            var timeLeave = DateTime.ParseExact(
                Console.ReadLine(),
                "HH:mm:ss",
                CultureInfo.InvariantCulture);    
                    
            var numberOfSteps = int.Parse(Console.ReadLine()) % 86400;
            var timeInSeconds = int.Parse(Console.ReadLine()) % 86400;

            var totalSeconds = numberOfSteps * timeInSeconds; 

            timeLeave = timeLeave.AddSeconds(totalSeconds);

            Console.WriteLine($"Time Arrival: {timeLeave:HH:mm:ss}");
        }
    }
}
