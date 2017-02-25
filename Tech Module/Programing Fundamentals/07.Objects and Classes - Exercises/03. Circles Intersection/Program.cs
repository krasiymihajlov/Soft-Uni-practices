namespace _03.Circles_Intersection
{
    using System;
    using System.Linq;

    public class ObjAndClassesExer
    {
        public static void Main()
        {
            var firstRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var secondRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var circleC2 = new Circle()
            {
                X = firstRow[0],
                Y = firstRow[1],
                Radius = firstRow[2]
            };

            var circleC1 = new Circle()
            {
                X = secondRow[0],
                Y = secondRow[1],
                Radius = secondRow[2]
            };

            var distance = CalcDistance(circleC1, circleC2);

            if (distance <= circleC1.Radius + circleC2.Radius)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        public static double CalcDistance(Circle p1, Circle p2)
        {
            var first = Math.Pow((p2.X - p1.X), 2);
            var second = Math.Pow((p2.Y - p1.Y), 2);

            return Math.Sqrt(first + second);
        }
    }

    public class Circle
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Radius { get; set; }
    }
}
