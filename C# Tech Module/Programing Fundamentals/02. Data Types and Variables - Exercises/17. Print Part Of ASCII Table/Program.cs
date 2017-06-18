namespace _17.Print_Part_Of_ASCII_Table
{
    using System;

    public class DateAndTypesExercises
    {
        public static void Main()
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());            
            for (int counter = startNumber; counter <= endNumber; counter++)
            {
                Console.Write((char)counter + " ");
            }

            Console.WriteLine();
        }
    }
}
