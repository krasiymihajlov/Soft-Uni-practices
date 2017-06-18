namespace _2.Circle_Area
{
    using System;

    public class DateAndTypesLab
    {
        public static void Main()
        {
            double r = double.Parse(Console.ReadLine());
            double area = Math.PI * r * r;
            Console.WriteLine("{0:f12}", area);
        }
    }
}
