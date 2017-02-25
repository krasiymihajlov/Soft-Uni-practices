namespace _19.Thea_The_Photographer
{
    using System;

    public class DateAndTypesExercises
    {
        public static void Main()
        {
            long allPictures = long.Parse(Console.ReadLine());
            long filterTime = long.Parse(Console.ReadLine());
            long filterFactor = long.Parse(Console.ReadLine());
            long uploadTime = long.Parse(Console.ReadLine());

            double filteredPicture = Math.Ceiling((filterFactor / 100d) * allPictures);           
            double totalFilterTime = allPictures * filterTime;
            double totalUploadTime = filteredPicture * uploadTime;
            double totalTime = totalFilterTime + totalUploadTime;            
            TimeSpan dateFormat = TimeSpan.FromSeconds(totalTime);
            string allTime = dateFormat.ToString(@"d\:hh\:mm\:ss");

            Console.WriteLine(allTime);            
        }
    }
}
