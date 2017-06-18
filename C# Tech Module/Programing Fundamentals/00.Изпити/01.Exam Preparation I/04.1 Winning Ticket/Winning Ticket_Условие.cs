namespace _04_1.Winning_Ticket
{
    using System;
    using System.Linq;

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

                var leftSide = ticket.Take(10).ToArray();
                var rightSide = ticket.Skip(10).ToArray();

                var winningTicket = false;

                var leftResult = GetCount(leftSide);

                if ((leftResult.Symbol == '@' ||
                    leftResult.Symbol == '#' ||
                    leftResult.Symbol == '$' ||
                    leftResult.Symbol == '^') &&
                    leftResult.Count >= 6 )                    
                {
                    var rightResult = GetCount(rightSide);
                    if (leftResult.Symbol == rightResult.Symbol &&
                        rightResult.Count >= 6)
                    {
                        winningTicket = true;
                        var jackpot = leftResult.Count == 10 && rightResult.Count == 10
                            ? " Jackpot!"
                            : string.Empty; 

                        Console.WriteLine($"ticket \"{ticket}\" - {Math.Min(leftResult.Count, rightResult.Count)}{leftResult.Symbol}{jackpot}");
                        continue;
                    }

                }
                
                if (!winningTicket)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");

                }

            }
            
        }

        private static Result GetCount(char[] symbols)
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

                if (count > maxCount)
                {
                    maxCount = count;
                    maxSymbol = previousSymbol;
                }
            }

            return new Result
            {
                Count = maxCount,
                Symbol = maxSymbol
            };
                
        }
    }

    public class Result
    {
        public int Count { get; set; }
        public char Symbol { get; set; }
    }


}
