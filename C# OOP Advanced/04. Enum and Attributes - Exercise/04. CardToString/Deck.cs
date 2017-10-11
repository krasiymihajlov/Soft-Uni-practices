namespace _04.CardToString
{
    using _04.CardToString.Enums;
    using System;

    public class Deck
    {
        private CardRank cardRank;
        private CardSuits cardSuit;

        public Deck()
        {
        }
        
        public void GetCardInfo(string rank, string suit)
        {
            this.cardRank = (CardRank)Enum.Parse(typeof(CardRank), rank);
            this.cardSuit = (CardSuits)Enum.Parse(typeof(CardSuits), suit);
        }

        public override string ToString()
        {
            return $"Card name: {this.cardRank} of {this.cardSuit}; Card power: {(int)this.cardRank + (int)this.cardSuit}";
        }

    }
}
