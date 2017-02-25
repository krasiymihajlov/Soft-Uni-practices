namespace _06.Math_Power
{
    using System;

    public class MathPower
    {
        public static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());
            Console.WriteLine(RaiseToPow(number, power));
        }

        public static double RaiseToPow(double number, double power)
        {
            double result = 1;
            for (int currentPower = 1; currentPower <= power; currentPower++)
            {
                result *= number;
            }

            return result;
        }       
    }
}
