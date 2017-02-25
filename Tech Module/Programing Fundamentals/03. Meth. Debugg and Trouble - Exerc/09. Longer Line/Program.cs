namespace _09.Longer_Line
{
    using System;

    public class Methods
    {
        public static void Main()
        {
            double firstPointX1 = double.Parse(Console.ReadLine());
            double firstPointY1 = double.Parse(Console.ReadLine());
            double firstPointX2 = double.Parse(Console.ReadLine());
            double firstPointY2 = double.Parse(Console.ReadLine());
            double secondPointX1 = double.Parse(Console.ReadLine());
            double secondPointY1 = double.Parse(Console.ReadLine());
            double secondPointX2 = double.Parse(Console.ReadLine());
            double secondPointY2 = double.Parse(Console.ReadLine());

            double firstDiagonal = GetDiagonalToTheCenter(firstPointX1, firstPointY1);
            double secondDiagonal = GetDiagonalToTheCenter(firstPointX2, firstPointY2);
            double thirdDiagonal = GetDiagonalToTheCenter(secondPointX1, secondPointY1);
            double fourDiagonal = GetDiagonalToTheCenter(secondPointX2, secondPointY2);

            double firstLine = GetLine(firstPointX1, firstPointY1, firstPointX2, firstPointY2);
            double secondLine = GetLine(secondPointX1, secondPointY1, secondPointX2, secondPointY2);           

            if (firstLine < secondLine)
            {
                FindCloserPointToCenter(thirdDiagonal, fourDiagonal, secondPointX1, secondPointY1, secondPointX2, secondPointY2);
            }
            else
            {
                FindCloserPointToCenter(firstDiagonal, secondDiagonal, firstPointX1, firstPointY1, firstPointX2, firstPointY2);
            }

        }    

        public static double GetLine(double firstPointX1, double firstPointY1, double secondPointX2, double secondPointY2)
        {
            double result = Math.Sqrt(Math.Pow(secondPointX2 - firstPointX1, 2) + Math.Pow(secondPointY2 - firstPointY1, 2));
            return result;
        }

        public static double GetDiagonalToTheCenter(double firstPoint, double secondPoint)
        {
            double result = Math.Sqrt(Math.Pow(firstPoint, 2) + Math.Pow(secondPoint, 2));
            return result;
        }

        public static void FindCloserPointToCenter(double firstDiagonal, double secondDiagonal, double X1, double Y1, double X2, double Y2)
        {
            if (firstDiagonal > secondDiagonal)
            {
                Console.WriteLine($"({X2}, {Y2})({X1}, {Y1})");
            }           
            else
            {
                Console.WriteLine($"({X1}, {Y1})({X2}, {Y2})");
            }
        }
    }
}