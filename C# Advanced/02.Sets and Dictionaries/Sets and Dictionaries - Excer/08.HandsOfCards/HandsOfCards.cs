namespace _08.HandsOfCards
{
    using System;
    using System.Collections.Generic;

    public class HandsOfCards
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var game = new Dictionary<string, HashSet<string>>();
            var print = new Dictionary<string, int>();

            while (input != "JOKER")
            {
                var hands = input.Split(new[] { ' ', ',', ':' }, StringSplitOptions.RemoveEmptyEntries);
                var name = hands[0];

                for (int i = 1; i < hands.Length; i++)
                {
                    if (!game.ContainsKey(name))
                    {
                        game[name] = new HashSet<string>();
                    }

                    game[name].Add(hands[i]);
                }                

                input = Console.ReadLine();
            }

            foreach (var kvp in game)
            {
                var name = kvp.Key;
                var cards = kvp.Value;

                foreach (var card in cards)
                {
                    var power = card.Substring(0, 1);
                    var type = card.Substring(card.Length - 1);

                    var sum = GetPowerOfCArds(power) * GetTypeOfCards(type);

                    if(!print.ContainsKey(name))
                    {
                        print[name] = sum;
                    }
                    else
                    {
                        print[name] += sum;
                    }
                }
            }

            foreach (var kvp in print)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

        }
        
        public static int GetPowerOfCArds(string power)
        {
            var value = 0;

            switch (power)
            {
                case "1":
                    value = 10;
                    break;
                case "2":
                    value = 2;
                    break;
                case "3":
                    value = 3;
                    break;
                case "4":
                    value = 4;
                    break;
                case "5":
                    value = 5;
                    break;
                case "6":
                    value = 6;
                    break;
                case "7":
                    value = 7;
                    break;
                case "8":
                    value = 8;
                    break;
                case "9":
                    value = 9;
                    break;
                case "J":
                    value = 11;
                    break;
                case "Q":
                    value = 12;
                    break;
                case "K":
                    value = 13;
                    break;
                case "A":
                    value = 14;
                    break;
                default:
                    break;
            }

            return value;
        }

        public static int GetTypeOfCards(string type)
        {
            int value = 0;

            switch (type)
            {
                case "S":
                    value = 4;
                    break;
                case "H":
                    value = 3;
                    break;
                case "D":
                    value = 2;
                    break;
                case "C":
                    value = 1;
                    break;
                default:
                    break;
            }

            return value;
        }
    }
}
