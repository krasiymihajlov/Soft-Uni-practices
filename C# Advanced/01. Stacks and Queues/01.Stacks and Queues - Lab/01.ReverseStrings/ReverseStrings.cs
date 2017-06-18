namespace _01.ReverseStrings
{
    using System;
    using System.Collections.Generic;

    public class ReverseStrings
    {
        public static void Main()
        {
            var inputString = Console.ReadLine();
            var stack = new Stack<char>();

            for (int i = 0; i < inputString.Length; i++)
            {
                var currentChar = inputString[i];
                stack.Push(currentChar);
            }

            for (int i = 0; i < inputString.Length; i++)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
