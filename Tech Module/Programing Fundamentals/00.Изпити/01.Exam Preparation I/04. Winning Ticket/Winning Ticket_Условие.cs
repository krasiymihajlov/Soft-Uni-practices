namespace _04.Winning_Ticket
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WinningTicket
    {
        public static void Main()
        {
            var tickets = Console.ReadLine()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(t => t.Trim())
                .ToArray();

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                var leftSide = new string(ticket.Take(10).ToArray());
                var rightSide = new string(ticket.Skip(10).ToArray());

                var symbols = new string[] { "@", "#", "\\$", "\\^" };
                var winningTicket = false;


                foreach (var symbol in symbols)
                {
                    var regex = new Regex($"{symbol}{{6,}}");
                    var matchLeft = regex.Match(leftSide);

                    if (matchLeft.Success)
                    {
                        var matchRight = regex.Match(rightSide);
                        if (matchRight.Success)
                        {
                            winningTicket = true;

                            var leftLenght = matchLeft.Value.Length;
                            var rightLenght = matchRight.Value.Length;

                            var jackpot = leftLenght == 10 && rightLenght == 10
                                ? " Jackpot!"
                                : string.Empty;

                            Console.WriteLine($"ticket \"{ticket}\" - {Math.Min(leftLenght, rightLenght)}{symbol.Trim('\\')}{jackpot}");
                            break;
                        }
                    }
                }

                if (!winningTicket)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
            }
        }

        private static int GetCount(char[] symbols)
        {
            var count = 1;
            var maxCount = 0;
            var maxSymbol = default(char);

            for (int j = 1; j < symbols.Length; j++)
            {
                var currentSymbol = symbols[j];
                var previousSymbol = symbols[j - 1];
                if (previousSymbol == currentSymbol)
                {
                    count++;
                }
                else
                {
                    if (count > maxCount)
                    {
                        maxCount = count;                        
                        maxSymbol = previousSymbol;
                    }

                    count = 1;
                }
            }

            return maxCount;
        }




    }
}
