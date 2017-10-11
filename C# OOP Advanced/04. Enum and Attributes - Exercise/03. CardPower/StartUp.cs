namespace _03.CardPower
{
    using System;
    using _03.CardPower.Enums;

    public class StartUp
    {
        public static void Main()
        {
            string rank = Console.ReadLine();
            string suit = Console.ReadLine();

            CardRank cardRank = (CardRank)Enum.Parse(typeof(CardRank), rank);
            CardSuits cardSuit = (CardSuits)Enum.Parse(typeof(CardSuits), suit);

            Console.WriteLine($"Card name: {cardRank} of {cardSuit}; Card power: {(int)cardRank + (int)cardSuit}");
        }
    }
}
