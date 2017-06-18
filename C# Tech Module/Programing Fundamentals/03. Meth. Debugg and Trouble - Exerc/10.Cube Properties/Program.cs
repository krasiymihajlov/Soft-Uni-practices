namespace _10.Cube_Properties
{
    using System;

    public class Methods
    {
        public static void Main()
        {
            double side = double.Parse(Console.ReadLine());
            string parameter = Console.ReadLine();

            if (parameter == "face")
            {
                Console.WriteLine("{0:f2}", GiveFaceDiagonals(side));
            }
            else if (parameter == "space")
            {
                Console.WriteLine("{0:f2}", GiveSpaceDiagonals(side));
            }
            else if (parameter == "volume")
            {
                Console.WriteLine("{0:f2}", GiveVolume(side));
            }
            else if (parameter == "area")
            {
                Console.WriteLine("{0:f2}", GiveSurfaceArea(side));
            }
        }

        public static double GiveFaceDiagonals(double s)
        {
            double result = Math.Sqrt(2 * Math.Pow(s, 2));
            return result;
        }

        public static double GiveSpaceDiagonals(double s)
        {
            double result = Math.Sqrt(3 * Math.Pow(s, 2));
            return result;
        }

        public static double GiveVolume(double s)
        {
            double result = Math.Pow(s, 3);
            return result;
        }

        public static double GiveSurfaceArea(double s)
        {
            double result = 6 * Math.Pow(s, 2);
            return result;
        }
    }
}
