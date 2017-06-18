namespace _04.MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    public class MatchingBrackets
    {
        public static void Main()
        {
            var expression = Console.ReadLine();
            var findBrackets = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                var currentChar = expression[i];

                if (currentChar == '(')
                {
                    findBrackets.Push(i);
                }
                else if( currentChar == ')')
                {
                    var startIndex = findBrackets.Pop();
                    var contents = expression.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(contents);
                }
            }
        }
    }
}
