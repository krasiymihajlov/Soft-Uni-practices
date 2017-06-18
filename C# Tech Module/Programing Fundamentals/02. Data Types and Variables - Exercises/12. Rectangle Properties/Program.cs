namespace _12.Rectangle_Properties
{
    using System;

    public class DateAndTypesExercises
    {
        public static void Main()
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double perimeter = 2 * width + 2 * height;
            double area = width * height;
            double squareWidth = Math.Pow(width, 2);
            double squereHeight = Math.Pow(height, 2);
            double diagonal = squareWidth + squereHeight;

            Console.WriteLine(perimeter);
            Console.WriteLine(area);
            Console.WriteLine(Math.Sqrt(diagonal));
        }
    }
}
