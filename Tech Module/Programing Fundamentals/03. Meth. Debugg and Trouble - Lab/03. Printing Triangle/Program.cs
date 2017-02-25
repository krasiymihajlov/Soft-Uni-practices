namespace _03.Printing_Triangle
{
    using System;

     public class PrintingTriangle
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            PrintFirstTriangle(number);
            PrintLine(1, number);
            PrintLastTriangle(number);
        }

        public static void PrintFirstTriangle(int number)
        {
            for (int i = 1; i < number; i++)
            {
                PrintLine(1, i);
            }
        }

        public static void PrintLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }

        public static void PrintLastTriangle(int number)
        {
            for (int i = number - 1; i > 0; i--)
            {
                PrintLine(1, i);
            }
        }
    }
}
