namespace _07.Balanced_Parenthesis
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesis
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();
            var isTrue = true;

            if (input.Length % 2 == 1)
            {
                Console.WriteLine("NO");
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];

                if (currentChar == ')')
                {
                    if (stack.Pop() == '(')
                    {
                        stack.Push(')');
                    }

                    if (stack.Pop() != currentChar)
                    {
                        isTrue = false;
                        break;
                    }
                }
                else if (currentChar == ']')
                {
                    if (stack.Pop() == '[')
                    {
                        stack.Push(']');
                    }

                    if (stack.Pop() != currentChar)
                    {
                        isTrue = false;
                        break;
                    }
                }
                else if (currentChar == '}')
                {
                    if (stack.Pop() == '{')
                    {
                        stack.Push('}');
                    }

                    if (stack.Pop() != currentChar)
                    {
                        isTrue = false;
                        break;
                    }
                }
                else
                {
                    stack.Push(currentChar);
                }
            }

            if (isTrue)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
