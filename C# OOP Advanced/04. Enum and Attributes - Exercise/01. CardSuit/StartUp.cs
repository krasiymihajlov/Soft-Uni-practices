namespace _01.CardSuit
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string cards = "Card Suits:";
            string[] enumCard = typeof(CardSuits).GetEnumNames();

            Console.WriteLine(cards);

            foreach (string item in enumCard)
            {
                CardSuits card = (CardSuits)Enum.Parse(typeof(CardSuits), item);
                Console.WriteLine($"Ordinal value: {(int)card}; Name value: {card}");
            }
        }
    }
}
