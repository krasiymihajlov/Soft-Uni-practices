namespace _04.Distance_between_Points
{
    using System;

    public class ObjectAndClasses
    {
        public static void Main()
        {
            var firstRow = Console.ReadLine().Split();
            var secondRow = Console.ReadLine().Split();

            var p1 = new Point
            {
                X = double.Parse(firstRow[0]),
                Y = double.Parse(firstRow[1])
            };

            var p2 = new Point
            {
                X = double.Parse(secondRow[0]),
                Y = double.Parse(secondRow[1])
            };

            var result = CalcDistance(p1, p2);
            Console.WriteLine($"{result:f3}");
        }

        private static double CalcDistance(Point p1, Point p2)
        {
            var first = Math.Pow((p2.X - p1.X), 2);
            var second = Math.Pow((p2.Y - p1.Y), 2);

            return Math.Sqrt(first + second);
        }
    }
}
