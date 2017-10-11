namespace _04.CardToString
{
    using System;
    using _04.CardToString.Enums;

    public class StartUp
    {
        public static void Main()
        {
            string rank = Console.ReadLine();
            string suit = Console.ReadLine();

            Deck deck = new Deck();
            deck.GetCardInfo(rank, suit);
            Console.WriteLine(deck);
        }
    }
}
