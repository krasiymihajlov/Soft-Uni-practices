namespace _03.DecimalToBinaryConverter
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DecimalToBinaryConverter
    {
        public static void Main()
        {
            var decimalNumber = int.Parse(Console.ReadLine());
            var collection = new Stack<int>();

            if (decimalNumber == 0)
            {
                Console.WriteLine(0);
            }

            while (decimalNumber != 0)
            {
                collection.Push(decimalNumber % 2);
                decimalNumber /= 2;
            }

            while (collection.Count != 0)
            {
                Console.Write(collection.Pop());
            }

            Console.WriteLine();
        }
    }
}
