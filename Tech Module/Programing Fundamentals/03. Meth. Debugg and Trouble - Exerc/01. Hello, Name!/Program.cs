namespace _01.Hello__Name_
{
    using System;

    public class Program
    {
        public static void Main()
        {
            GetName();
        }

        public static void GetName()
        {
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}!");
        }
    }
}