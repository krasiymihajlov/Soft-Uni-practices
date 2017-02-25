namespace _05.Closest_Two_Points
{
    using System;
    using System.Collections.Generic;

    public class ObjectAndClasses
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            var listOfPoints = new List<Point>();
            double currentminDistance = 0;
            double minDistance = double.MaxValue;
            var minRow1 = string.Empty;
            var minRow2 = string.Empty;

            for (int i = 0; i < number; i++)
            {
                var row = Console.ReadLine().Split();

                listOfPoints.Add(new Point
                {
                    X = double.Parse(row[0]),
                    Y = double.Parse(row[1])
                });
            }
            var smalestPoints = new Point();

            for (int i = 0; i < listOfPoints.Count - 1; i++)
            {
                for (int j = i + 1; j < listOfPoints.Count; j++)
                {
                    currentminDistance = GetDiagonalToCenter(listOfPoints[i], listOfPoints[j]);
                    if (currentminDistance < minDistance)
                    {
                        minDistance = currentminDistance;
                        minRow1 = $"({listOfPoints[i].X}, {listOfPoints[i].Y})";
                        minRow2 = $"({listOfPoints[j].X}, {listOfPoints[j].Y})";
                    }
                }
            }

            Console.WriteLine($"{minDistance:f3}");
            Console.WriteLine($"{minRow1}");
            Console.WriteLine($"{minRow2}");

        }

        private static double GetDiagonalToCenter(Point p1, Point p2)
        {
            var first = Math.Pow((p2.X - p1.X), 2);
            var second = Math.Pow((p2.Y - p1.Y), 2);

            return Math.Sqrt(first + second);
        }
    }

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}
