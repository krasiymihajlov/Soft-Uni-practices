namespace _01.Count_Work_Days
{
    using System;
    using System.Globalization;
    using System.Linq;

    public class ObJAndClassesExer
    {
        public static void Main()
        {
            var firstRow = Console.ReadLine();
            var secondRow = Console.ReadLine();

            var format = "dd-MM-yyyy";
            var startDay = DateTime.ParseExact(firstRow, format, CultureInfo.InvariantCulture);
            var endDay = DateTime.ParseExact(secondRow, format, CultureInfo.InvariantCulture);

            var vacation = GetVacationDays();
            var workingDay = 0;

            for (DateTime i = startDay; i <= endDay; i = i.AddDays(1))
            {
                var day = i.DayOfWeek;

                DateTime temp = new DateTime(2016, i.Month, i.Day);

                if (!vacation.Contains(temp) &&
                    (DayOfWeek.Saturday != day) && (DayOfWeek.Sunday != day))
                {
                    workingDay++;
                }
            }

            Console.WriteLine(workingDay);
        }

        private static DateTime[] GetVacationDays()
        {
            var officialHolidays = new DateTime[11];

            officialHolidays[0] = new DateTime(2016, 01, 01);
            officialHolidays[1] = new DateTime(2016, 03, 03);
            officialHolidays[2] = new DateTime(2016, 05, 01);
            officialHolidays[3] = new DateTime(2016, 05, 06);
            officialHolidays[4] = new DateTime(2016, 05, 24);
            officialHolidays[5] = new DateTime(2016, 09, 06);
            officialHolidays[6] = new DateTime(2016, 09, 22);
            officialHolidays[7] = new DateTime(2016, 11, 01);
            officialHolidays[8] = new DateTime(2016, 12, 24);
            officialHolidays[9] = new DateTime(2016, 12, 25);
            officialHolidays[10] = new DateTime(2016, 12, 26);

            return officialHolidays;
        }
    }
}
