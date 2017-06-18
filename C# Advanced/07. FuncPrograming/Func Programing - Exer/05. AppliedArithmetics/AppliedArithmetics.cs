namespace _05.AppliedArithmetics
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class AppliedArithmetics
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();
            Func<int, int> sum = n => n + 1;
            Func<int, int> subtract = n => n - 1;
            Func<int, int> multiply = n => n * 2;
            Action<List<int>> print = n => Console.WriteLine(string.Join(" ", n));
            
            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                       numbers = GetCommand(numbers, sum);
                        break;
                    case "subtract":
                       numbers = GetCommand(numbers, subtract);
                        break;
                    case "multiply":
                       numbers = GetCommand(numbers, multiply);
                        break;
                    case "print":
                        print(numbers);
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }
        }

        public static List<int> GetCommand(List<int> numbers, Func<int, int> command)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] = command(numbers[i]);
            }

            return numbers;
        }
    }
}
