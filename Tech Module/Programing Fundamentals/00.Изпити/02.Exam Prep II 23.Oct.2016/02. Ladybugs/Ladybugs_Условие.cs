namespace _02.Ladybugs
{
    using System;
    using System.Linq;

    public class Ladybugs
    {
        public static void Main()
        {
            var fieldNumber = ulong.Parse(Console.ReadLine());
            var fieldSize = new ulong[fieldNumber];
            var ladyBug = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            for (int i = 0; i < ladyBug.Length; i++)
            {
                var bug = ladyBug.Skip(i).First();

                if (bug <= fieldSize.Length - 1 && bug >= 0)
                {
                    fieldSize[bug] = 1;
                }
            }

            var commands = Console.ReadLine();
            while (commands != "end")
            {
                var command = commands
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var currentPosition = long.Parse(command.First());
                var direction = command.Skip(1).First();
                var nextPosition = long.Parse(command.Last());

                if ((currentPosition <= fieldSize.Length - 1 &&
                    currentPosition >= 0))
                {
                    if (direction == "right")
                    {
                        if (fieldSize[currentPosition] == 1)
                        {
                            fieldSize[currentPosition] = 0;
                            currentPosition = currentPosition + nextPosition;

                            while (currentPosition <= fieldSize.Length - 1 &&
                                currentPosition >= 0)
                            {
                                if (fieldSize[currentPosition] == 1)
                                {
                                    currentPosition += nextPosition;
                                }
                                else
                                {
                                    fieldSize[currentPosition] = 1;
                                    break;
                                }
                            }
                        }
                    }
                    else if (direction == "left")
                    {
                        if (fieldSize[currentPosition] == 1)
                        {
                            fieldSize[currentPosition] = 0;
                            currentPosition = currentPosition - nextPosition;

                            while (currentPosition <= fieldSize.Length - 1 &&
                                currentPosition >= 0)
                            {
                                if (fieldSize[currentPosition] == 1)
                                {
                                    currentPosition -= nextPosition;
                                }
                                else
                                {
                                    fieldSize[currentPosition] = 1;
                                    break;
                                }
                            }
                        }
                    }
                }

                commands = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", fieldSize));
        }
    }
}
