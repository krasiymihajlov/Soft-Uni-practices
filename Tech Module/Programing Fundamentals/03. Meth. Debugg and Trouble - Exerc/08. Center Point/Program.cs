namespace _08.Center_Point
{
    using System;

    public class CenterPoint
    {
        public static void Main()
        {
            double firstPointX1 = double.Parse(Console.ReadLine());
            double firstPointY1 = double.Parse(Console.ReadLine());
            double secondPointX2 = double.Parse(Console.ReadLine());
            double secondPointY2 = double.Parse(Console.ReadLine());
            double firstPoint = Math.Pow(firstPointX1, 2) + Math.Pow(firstPointY1, 2);
            double secondPoint = Math.Pow(secondPointX2, 2) + Math.Pow(secondPointY2, 2);
            if (GetDiagonalToTheCenter(firstPoint) >= GetDiagonalToTheCenter(secondPoint))
            {
                Console.WriteLine($"({secondPointX2}, {secondPointY2})");
            }
            else
            {
                Console.WriteLine($"({firstPointX1}, {firstPointY1})");
            }
        }

        public static double GetDiagonalToTheCenter(double number)
        {
            double result = Math.Sqrt(number);
            return result;
        }            
    }
}
