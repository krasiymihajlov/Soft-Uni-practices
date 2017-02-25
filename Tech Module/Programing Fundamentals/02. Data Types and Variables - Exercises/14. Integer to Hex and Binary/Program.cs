namespace _14.Integer_to_Hex_and_Binary
{
    using System;

    public class DateAndTypesExercises
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            //string hexadecimal = Convert.ToString(number, 16).ToUpper();
            string hexadecimal = number.ToString("X");
            string binary = Convert.ToString(number, 2);      
                
            Console.WriteLine(hexadecimal);
            Console.WriteLine(binary);
        }
    }
}
