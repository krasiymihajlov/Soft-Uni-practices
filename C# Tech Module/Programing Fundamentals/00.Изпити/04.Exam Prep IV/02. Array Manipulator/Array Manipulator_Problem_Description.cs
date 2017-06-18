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
                            arrOfIntegers = ExchangeArray(arrOfIntegers, indexExchange);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }

                        break;

                    case "max":
                        var evenOrOdd = commands[1];

                        var indexMax = MaxEvenOrOdd(arrOfIntegers, evenOrOdd);

                        if (indexMax < 0)
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                        {
                            Console.WriteLine($"{indexMax}");
                        }

                        break;

                    case "min":
                        var evenOrOddMin = commands[1];

                        var indexMin = MinEvenOrOdd(arrOfIntegers, evenOrOddMin);

                        if (indexMin < 0)
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                        {
                            Console.WriteLine($"{indexMin}");
                        }

                        break;

                    case "first":
                        var countFirst = int.Parse(commands[1]);
                        var evenOrOddFirst = commands[2];

                        var firstArr = FirstEvenOrOddElements(arrOfIntegers, countFirst, evenOrOddFirst);

                        if (countFirst > arrOfIntegers.Length)
                        {
                            Console.WriteLine($"Invalid count");
                        }
                        else
                        {
                            PrintArr(firstArr);
                        }

                        break;

                    case "last":
                        var countLast = int.Parse(commands[1]);
                        var evenOrOddLast = commands[2];
                                               
                        var lastArr = LastEvenOrOddElements(arrOfIntegers, countLast, evenOrOddLast);

                        if (countLast > arrOfIntegers.Length)
                        {
                            Console.WriteLine($"Invalid count");
                        }
                        else
                        {
                            PrintArr(lastArr);
                        }

                        break;
                }
            }

            PrintArr(arrOfIntegers);
        }

        private static int[] LastEvenOrOddElements(int[] arrOfIntegers, int countLast, string evenOrOddLast)
        {
            if (evenOrOddLast == "even")
            {
                return arrOfIntegers.Where(x => x % 2 == 0).Reverse().Take(countLast).Reverse().ToArray();
            }
            else
            {
                return arrOfIntegers.Where(x => x % 2 == 1).Reverse().Take(countLast).Reverse().ToArray();
            }
        }

        private static void PrintArr(int[] arrOfIntegers)
        {
            Console.WriteLine($"[{string.Join(", ", arrOfIntegers)}]");
        }

        private static int[] FirstEvenOrOddElements(int[] arrOfIntegers, int countFirst, string evenOrOddFirst)
        {
            if (evenOrOddFirst == "even")
            {
                return arrOfIntegers.Where(x => x % 2 == 0).Take(countFirst).ToArray();
            }
            else
            {
                return arrOfIntegers.Where(x => x % 2 == 1).Take(countFirst).ToArray();
            }
        }

        private static int MinEvenOrOdd(int[] arrOfIntegers, string evenOrOddMin)
        {
            var index = -1;
            var number = 0;
            var min = int.MaxValue;
            for (int i = 0; i < arrOfIntegers.Length; i++)
            {
                if (evenOrOddMin == "even")
                {
                    if (arrOfIntegers[i] % 2 == 0)
                    {
                        number = arrOfIntegers[i];
                        if (number <= min)
                        {
                            min = number;
                            index = i;
                        }
                    }
                }
                else
                {
                    if (arrOfIntegers[i] % 2 == 1)
                    {
                        number = arrOfIntegers[i];
                        if (number <= min)
                        {
                            min = number;
                            index = i;
                        }
                    }
                }
            }

            return index;
        }

        private static int MaxEvenOrOdd(int[] arrOfIntegers, string evenOrOdd)
        {
            var index = -1;
            var number = 0;
            var max = int.MinValue;
            for (int i = 0; i < arrOfIntegers.Length; i++)
            {
                if (evenOrOdd == "even")
                {
                    if (arrOfIntegers[i] % 2 == 0)
                    {
                        number = arrOfIntegers[i];
                        if (number >= max)
                        {
                            max = number;
                            index = i;
                        }
                    }
                }
                else
                {
                    if (arrOfIntegers[i] % 2 == 1)
                    {
                        number = arrOfIntegers[i];
                        if (number >= max)
                        {
                            max = number;
                            index = i;
                        }
                    }
                }
            }

            return index;
        }

        private static int[] ExchangeArray(int[] arrOfIntegers, int indexExchange)
        {
            var index = indexExchange % arrOfIntegers.Length;

            var firstArr = arrOfIntegers.Skip(index + 1);
            var secondArr = arrOfIntegers.Take(index + 1);

            return arrOfIntegers = firstArr.Concat(secondArr).ToArray();
        }
    }
}
