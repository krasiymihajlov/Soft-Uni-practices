namespace _02.Reverse_Array_of_Integers
{
    using System;
    using System.Linq;

    public class Arrays
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var integers = new int[number];
            var reverseInteger = new int[integers.Length];
            for (int i = 0; i < integers.Length; i++)
            {
                integers[i] = int.Parse(Console.ReadLine());                
                           
            }

            integers = integers.Reverse().ToArray();
            Console.Write(string.Join(" ", integers));
        }   
    }
}
