namespace _16._1_Comparing_floats
{
    using System;

    public class DateAndTypesExercises
    {
        public static void Main()
        {
            double numberA = double.Parse(Console.ReadLine());
            double numberB = double.Parse(Console.ReadLine());
            double precisionEps = 0.000001;
            double differenceInNumbers = Math.Abs(numberA - numberB);

            if (differenceInNumbers < precisionEps)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
