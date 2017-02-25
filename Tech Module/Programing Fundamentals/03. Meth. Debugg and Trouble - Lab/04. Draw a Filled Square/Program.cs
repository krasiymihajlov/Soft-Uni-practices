namespace _04.Draw_a_Filled_Square
{
    using System;

    public class DrawFilledSquare
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintHeaderRow(number);
            PrintMiddleCol(number);
            PrintHeaderRow(number);
        }

        public static void PrintHeaderRow(int number)
        {
            Console.WriteLine(new string('-', 2 * number));
        }

        public static void PrintMiddleRow(int number)
        {
            Console.Write("-");

            for (int i = 1; i < number; i++)
            {
                Console.Write("\\");
                Console.Write("/");
            }

            Console.Write("-");
            Console.WriteLine();
        }

        public static void PrintMiddleCol(int number)
        {
            for (int i = 2; i < number; i++)
            {
                PrintMiddleRow(number);
            }
        }
    }
}
