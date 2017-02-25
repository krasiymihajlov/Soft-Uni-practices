namespace _05.Hands_of_Cards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DictLambdaLinqExer
    {
        public static void Main()
        {
            var powerCards = GetPowerCars();
            var typeCards = GetTypeCars();

            var cardsHands = new Dictionary<string, HashSet<int>>();

            string line = Console.ReadLine();

            while (line != "JOKER")
            {
                var separateLines = line.Split(':');

                var person = separateLines[0];
                var cards = separateLines[1].Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                foreach (var card in cards)
                {
                    var power = card.Substring(0, card.Length - 1);
                    var type = card.Substring(card.Length - 1);

                    int sum = powerCards[power] * typeCards[type];

                    if (!cardsHands.ContainsKey(person))
                    {
                        cardsHands[person] = new HashSet<int>();
                    }

                    cardsHands[person].Add(sum);
                }

                line = Console.ReadLine();
            }

            foreach (var name in cardsHands)
            {
                Console.WriteLine($"{name.Key}: {name.Value.Sum()}");
            }
        }

        private static Dictionary<string, int> GetTypeCars()
        {
            var type = new Dictionary<string, int>();

            type["S"] = 4;
            type["H"] = 3;
            type["D"] = 2;
            type["C"] = 1;

            return type;
        }

        private static Dictionary<string, int> GetPowerCars()
        {
            var powers = new Dictionary<string, int>();

            for (int i = 2; i <= 10; i++)
            {
                powers[i.ToString()] = i;
            }

            powers["J"] = 11;
            powers["Q"] = 12;
            powers["K"] = 13;
            powers["A"] = 14;

            return powers;
        }

    }
}