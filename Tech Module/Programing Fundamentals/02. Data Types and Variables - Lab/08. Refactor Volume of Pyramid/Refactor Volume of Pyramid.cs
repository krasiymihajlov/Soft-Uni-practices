namespace _08.Refactor_Volume_of_Pyramid
{
    using System;

    public class DateAndTypesLab
    {
        public static void Main()
        {            
            double Length = double.Parse(Console.ReadLine());
            double Width = double.Parse(Console.ReadLine());           
            double Heigth = double.Parse(Console.ReadLine());
            double V = (Length * Width * Heigth) / 3;
            Console.WriteLine("Length: Width: Height: Pyramid Volume: {0:f2}", V);
        }
    }
}
