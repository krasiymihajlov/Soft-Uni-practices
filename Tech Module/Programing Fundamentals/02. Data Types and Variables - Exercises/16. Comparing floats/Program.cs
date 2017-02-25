namespace _16.Comparing_floats
{
    using System;

    public class DateAndTypesExercises
    {
        public static void Main()
        {
            double numberA = double.Parse(Console.ReadLine());
            double numberB = double.Parse(Console.ReadLine());           
            double roundingNumberA = Math.Round(numberA, 6);
            double roundingNumberB = Math.Round(numberB, 6);

            if (Math.Abs(roundingNumberA) == Math.Abs(roundingNumberB)) 
            {
                Console.WriteLine("True");
            }
            else if (roundingNumberA < roundingNumberB)
            {
                Console.WriteLine("False");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
