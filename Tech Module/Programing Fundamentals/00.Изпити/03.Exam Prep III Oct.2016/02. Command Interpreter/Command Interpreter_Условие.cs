namespace _02.Command_Interpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CommandInterpreter
    {
        private static string command;

        public static void Main()
        {
            var seriesOfStrings = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                ToArray();

            var commandFormat = Console.ReadLine();

            while (commandFormat != "end")
            {
                var commands = commandFormat
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var command = commands.First();

                switch (command)
                {
                    case "reverse":
                        int startReverse = int.Parse(commands.Skip(2).First());
                        int countReverse = int.Parse(commands.Last());

                        if (IsValid(seriesOfStrings, startReverse, countReverse))
                        {
                            Reverse(seriesOfStrings, startReverse, countReverse);                      
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }

                        break;

                    case "sort":
                        int startSort = int.Parse(commands.Skip(2).First());
                        int countSort = int.Parse(commands.Last());
                                                
                        if (IsValid(seriesOfStrings, startSort, countSort))
                        {
                            GetSort(seriesOfStrings, startSort, countSort);                            
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }

                        break;

                    case "rollLeft":
                        int countLeft = int.Parse(commands.Skip(1).First());

                        if (countLeft >= 0)
                        {
                            RollLeft(seriesOfStrings, countLeft);                            
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }


                        break;

                    case "rollRight":
                        int countRight = int.Parse(commands.Skip(1).First());

                        if (countRight >= 0)
                        {
                            RollRight(seriesOfStrings, countRight);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }

                        break;

                    default:
                        break;
                }

                commandFormat = Console.ReadLine();
            }

            Console.WriteLine("[" + string.Join(", ", seriesOfStrings) + "]");

        }

        private static void RollRight(string[] seriesOfStrings, int countRight)
        {
            var count = countRight % seriesOfStrings.Length;

            for (int i = 0; i < count; i++)
            {
                var lastElement = seriesOfStrings.Last();

                for (int j = seriesOfStrings.Length - 1; j > 0; j--)
                {
                    seriesOfStrings[j] = seriesOfStrings[j - 1];
                }

                seriesOfStrings[0] = lastElement;
            }
        }

        private static void RollLeft(string[] seriesOfStrings, int countLeft)
        {
            var count = countLeft % seriesOfStrings.Length;

            for (int i = 0; i < count; i++)
            {
                var FirstElement = seriesOfStrings.First();

                for (int j = 1; j < seriesOfStrings.Length; j++)
                {
                    seriesOfStrings[j - 1] = seriesOfStrings[j];
                }

                seriesOfStrings[seriesOfStrings.Length - 1] = FirstElement;
            }
        }

        private static void GetSort(string[] seriesOfStrings, int startSort, int countSort)
        {
            var sortedList = new List<string>();
            for (int i = startSort; i < startSort + countSort; i++)
            {
                sortedList.Add(seriesOfStrings[i]);
            }

            sortedList.Sort();
            for (int i = startSort, j = 0; i < startSort + countSort; i++, j++)
            {
                seriesOfStrings[i] = sortedList[j];
            }
        }

        private static void Reverse(string[] seriesOfStrings, int start, int count)
        {
            var list = new List<string>();
            for (int i = start; i < start + count ; i++)
            {
                list.Add(seriesOfStrings[i]);
            }

            list.Reverse();
            for (int i = start, j = 0; i < start + count; i++, j++)
            {
                seriesOfStrings[i] = list[j];
            }
        }

        private static bool IsValid(string[] seriesOfStrings, int start, int count)
        {
            if (start >= 0 && start < seriesOfStrings.Length && (start + count) <= seriesOfStrings.Length && count >= 0)
            {
                return true;
            }

            return false;
        }
    }
}
