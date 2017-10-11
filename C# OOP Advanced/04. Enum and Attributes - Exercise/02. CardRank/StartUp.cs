namespace _02.CardRank
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string cards = "Card Ranks:";
            string[] enumCard = typeof(CardRank).GetEnumNames();

            Console.WriteLine(cards);

            foreach (string item in enumCard)
            {
                CardRank card = (CardRank)Enum.Parse(typeof(CardRank), item);
                Console.WriteLine($"Ordinal value: {(int)card}; Name value: {card}");
            }
        }
    }
}
