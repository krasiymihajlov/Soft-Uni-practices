namespace _01.Reverse_String
{
    using System;
    using System.Linq;

    public class StringsLab
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToArray();
            var newWord = new char[input.Length];
            for (int i = input.Length - 1; i >= 0; i--)
            {
                var symbol = (char)input[i];
                Console.Write(symbol);
            }
            Console.WriteLine();
        }
    }
}
