namespace _02.BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicStackOperation
    {
        public static void Main()
        {
            var comands = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var stackOfNum = new Stack<int>();

            var numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            foreach (var number in numbers)
            {
                stackOfNum.Push(number);
            }

            for (int i = 0; i < comands[1]; i++)
            {
                if (stackOfNum.Count != 0)
                {
                    stackOfNum.Pop();
                }
            }

            if (stackOfNum.Count != 0)
            {
                if (stackOfNum.Contains(comands[2]))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    var arr = stackOfNum.ToArray();

                    var minNum = arr.Min();
                    Console.WriteLine(minNum);
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
