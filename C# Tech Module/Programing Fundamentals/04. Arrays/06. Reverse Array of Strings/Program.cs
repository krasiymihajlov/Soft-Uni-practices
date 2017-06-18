namespace _06.Reverse_Array_of_Strings
{
    using System;
    using System.Linq;

    public class Arrays
    {
        public static void Main()
        {
            string[] readString = Console.ReadLine().Split(' ').ToArray();
            string[] reverseArray = readString.Reverse().ToArray();            

            Console.WriteLine(string.Join(" ", reverseArray));
        }
    }
}
