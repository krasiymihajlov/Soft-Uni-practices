namespace _10.Centuries_to_Nanoseconds
{
    using System;
    using System.Numerics;

    public class DateAndTypesExercises
    {
        public static void Main()
        {
            int centuries = int.Parse(Console.ReadLine());
            int years = 100 * centuries;
            BigInteger days = (3652422 * centuries)/ 100;
            BigInteger hours = 24 * days;
            BigInteger minutes = 60 * hours;
            BigInteger seconds = 60 * minutes;
            BigInteger milliseconds = 1000 * seconds;
            BigInteger microseconds = 1000 * milliseconds;
            BigInteger nanoseconds = 1000 * microseconds;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
        }
    }
}
