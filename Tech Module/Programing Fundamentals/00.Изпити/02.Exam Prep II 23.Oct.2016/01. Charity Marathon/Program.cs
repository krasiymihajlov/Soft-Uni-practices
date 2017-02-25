namespace _01.Charity_Marathon
{
    using System;

    public class CharityMarathon
    {
        public static void Main()
        {
            var days = int.Parse(Console.ReadLine());
            var numberOfRunners = long.Parse(Console.ReadLine());
            var averageLaps = long.Parse(Console.ReadLine());
            var lenghtTrack = int.Parse(Console.ReadLine());
            var capacityOfTrack = int.Parse(Console.ReadLine());
            var moneyOfKillometer = double.Parse(Console.ReadLine());

            var maxRunners = capacityOfTrack * days;

            if (numberOfRunners > maxRunners)
            {
                numberOfRunners = maxRunners;
            }

            var totalMeters = numberOfRunners * averageLaps * lenghtTrack;
            var moneyRaise = (totalMeters / 1000d) * moneyOfKillometer;

            Console.WriteLine($"Money raised: {moneyRaise:F2}");

        }
    }
}
