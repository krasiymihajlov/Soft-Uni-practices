namespace _11.Geometry_Calculator
{
    using System;

    public class Methods
    {
        public static void Main()
        {
            string figures = Console.ReadLine();

            if (figures == "triangle")
            {
                double side = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                Console.WriteLine("{0:f2}", GetTriangleArea(side, height));
            }
            else if (figures == "square")
            {
                double side = double.Parse(Console.ReadLine());
                Console.WriteLine("{0:f2}", GetSquareArea(side));
            }
            else if (figures == "rectangle")
            {
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                Console.WriteLine("{0:f2}", GetRectangleArea(width, height));
            }
            else if (figures == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                Console.WriteLine("{0:f2}", GetCircleArea(radius));
            }
        }

        public static double GetTriangleArea(double side, double height)
        {
            double result = (side * height) / 2;
            return result;
        }

        public static double GetSquareArea(double side)
        {
            double result = side * side;
            return result;
        }

        public static double GetRectangleArea(double width, double height)
        {
            double result = width * height;
            return result;
        }

        public static double GetCircleArea(double r)
        {
            double result = Math.PI * r * r;
            return result;
        }
    }
}
