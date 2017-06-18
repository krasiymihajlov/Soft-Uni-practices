namespace _03.Maximum_Element
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaximumElement
    {
        public static void Main()
        {
            int numberOfQuery = int.Parse(Console.ReadLine());
            var stackOfQuery = new Stack<int>();
            var maxValue = int.MinValue;

            for (int i = 0; i < numberOfQuery; i++)
            {
                int[] currentColection = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                var currentQuery = currentColection[0];

                if (currentQuery == 1)
                {
                    var currentNumber = currentColection[1];
                    if (currentNumber > maxValue)
                    {
                        maxValue = currentNumber;
                    }

                    stackOfQuery.Push(currentNumber);
                }
                else if (currentQuery == 2)
                {
                    if (stackOfQuery.Count != 0)
                    {
                        var lastNumber = stackOfQuery.Pop();

                        if (stackOfQuery.Count != 0 && lastNumber == maxValue)
                        {
                            maxValue = stackOfQuery.Max();
                        }
                        else if (stackOfQuery.Count == 0 && lastNumber == maxValue)
                        {
                            maxValue = 0;
                        }
                    }
                }
                else if (currentQuery == 3)
                {
                    Console.WriteLine(maxValue);
                }
            }
        }
    }
}