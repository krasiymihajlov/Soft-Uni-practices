namespace _09.StackFibonacci
{
    using System;
    using System.Collections.Generic;

    public class StackFibonacci
    {
        public static void Main()
        {
            long number = long.Parse(Console.ReadLine());
            var stack = new Stack<long>();
            var counter = 1;

            if (number == 0)
            {
                Console.WriteLine(0);
                return;
            }
            else if (number == 1)
            {
                Console.WriteLine(1);
                return;
            }

            stack.Push(0);
            stack.Push(1);

            while (!(counter == number))
            {
                var last = stack.Pop();
                var preveus = stack.Peek();
                var sum = last + preveus;

                stack.Push(last);
                stack.Push(sum);
                counter++;
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
