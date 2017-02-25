namespace _04.Variable_in_Hex_Format
{
    using System;

    public class DateAndTypesExercises
    {
        public static void Main()
        {
            string hexFormat = Console.ReadLine();
            Console.WriteLine(Convert.ToInt32(hexFormat, 16));           
        }
    }
}
