namespace _05.Calculate_Triangle_Area
{
    using System;

    public class CalculateTriangleArea
    {
        public static void Main()
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine(GetTriangleArea(width, height));
        }

        public static double GetTriangleArea(double width, double height)
        {
            double area = (width * height) / 2;
            return area;
        }
    }
}
