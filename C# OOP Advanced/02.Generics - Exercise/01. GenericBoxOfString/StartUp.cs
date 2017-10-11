namespace _01.GenericBoxOfString
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Box<double> box = new Box<double>();
            //Box<string> box = new Box<string>();

            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                double command = double.Parse(Console.ReadLine());
                //string command = Console.ReadLine();
                box.Add(command);
            }

            double str = double.Parse(Console.ReadLine());
            Console.WriteLine(box.ReturnCount(str));
        }
    }
}