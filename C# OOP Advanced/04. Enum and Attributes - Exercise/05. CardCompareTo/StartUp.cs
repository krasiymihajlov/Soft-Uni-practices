namespace _05.CardCompareTo
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string rank1 = Console.ReadLine();
            string suit1 = Console.ReadLine();
            string rank2 = Console.ReadLine();
            string suit2 = Console.ReadLine();

            Deck deck1 = new Deck(rank1, suit1);
            Deck deck2 = new Deck(rank2, suit2);
           
            Console.WriteLine(deck1.CompareTo(deck2) > 0 ? deck1 : deck2);
        }
    }
}
