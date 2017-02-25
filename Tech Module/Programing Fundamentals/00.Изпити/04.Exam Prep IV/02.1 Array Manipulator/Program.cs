namespace _02.Array_Manipulator
{
    using System;
    using System.Linq;

    public class ArrayManipulator
    {
        public static void Main()
        {
            var arrOfIntegers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (true)
            {
                var arr = Console.ReadLine();
                if (arr == "end")
                {
                    break;
                }

                var commands = arr.Split();
                var command = commands[0];

                switch (command)
                {
                    case "exchange":
                        var indexExchange = int.Parse(commands[1]);
                        if (indexExchange >= 0 && indexExchange < arrOfIntegers.Length)
                        {
                            arrOfIntegers = ExchangeArray(arrOfIntegers, indexExchange + 1);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }

                        break;

                    case "max":
                    case "min":
                        Console.WriteLine(MinOrMax(arrOfIntegers, command, commands[1]));

                        break;

                    case "first":
                    case "last":
                        var count = int.Parse(commands[1]);

                        Console.WriteLine(FirstAndLast(arrOfIntegers, command, count, commands[2])); 

                        break;
                }
            }

            Console.WriteLine($"[{string.Join(", ", arrOfIntegers)}]");
        }

        private static string MinOrMax(int[] arrOfIntegers, string command, string evenOrOdd)
        {
            var evenOdd = evenOrOdd == "even" ? 0 : 1;
            var commands = arrOfIntegers.Where(x => x % 2 == evenOdd).ToArray();

            if (!commands.Any())
            {
                return "No matches";
            }

            return command == "max"
                ? Array.LastIndexOf(arrOfIntegers, commands.Max()).ToString()
                : Array.LastIndexOf(arrOfIntegers, commands.Min()).ToString();
        }

        private static string FirstAndLast(int[] arrOfIntegers, string commands ,int countLast, string evenOrOdd)
        {
            var evenOdd = evenOrOdd == "even" ? 0 : 1;
            var command = arrOfIntegers.Where(x => x % 2 == evenOdd).ToArray();

            if (countLast > arrOfIntegers.Length)
            {
                return "Invalid count";
            }

            var first = command.Take(countLast).ToArray();
            var last = command.Reverse().Take(countLast).Reverse().ToArray();
             
            return commands == "first"
            ? "[" + string.Join(", ", command.Take(countLast)) + "]"
            : "[" + string.Join(", ", command.Reverse().Take(countLast).Reverse()) + "]";
        }
    
        private static int[] ExchangeArray(int[] arr, int indexR)
        {
            var index = indexR % arr.Length;
            return arr = arr.Skip(index).Concat(arr.Take(index)).ToArray();
        }
    }
}
