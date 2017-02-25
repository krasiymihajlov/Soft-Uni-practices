namespace _06.Rectangle_Position
{
    using System;
    using System.Linq;

    public class ObjectAndClasses
    {
        public static void Main()
        {
            var firstRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var secondRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var firstRectangle = new Rectangle
            {
                Left = firstRow[0],
                Top = firstRow[1],
                Width = firstRow[2],
                Height = firstRow[3]
            };

            var secondRectangle = new Rectangle
            {
                Left = secondRow[0],
                Top = secondRow[1],
                Width = secondRow[2],
                Height = secondRow[3]
            };

            if (IsInside(firstRectangle, secondRectangle))
            {
                Console.WriteLine("Inside");
            }
            else
            {
                Console.WriteLine("Not inside");
            }

        }

        private static bool IsInside(Rectangle first, Rectangle second)
        {
            if ((first.Left >= second.Left) && (first.Right <= second.Right) &&
                (first.Top >= second.Top) && (first.Bottom <= second.Bottom))
            {
                return true;
            }

            return false;
        }
    }
}
