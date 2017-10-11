namespace _05.CardCompareTo
{
    using _05.CardCompareTo.Enums;
    using System;

    public class Deck : IComparable<Deck>
    {
        private CardRank cardRank;
        private CardSuits cardSuit;
        private int power;

        public Deck(string rank, string suit)
        {
            this.Rank = rank;
            this.Suit = suit;
            GetCardInfo();
        }

        private string Rank {get; set;}
        private string Suit { get; set; }

        public int CompareTo(Deck other)
        {
            int result = this.power.CompareTo(other.power);
            return result;
        }

        public void GetCardInfo()
        {
            this.cardRank = (CardRank)Enum.Parse(typeof(CardRank), this.Rank);
            this.cardSuit = (CardSuits)Enum.Parse(typeof(CardSuits), this.Suit);
            this.power = (int)this.cardRank + (int)this.cardSuit;
        }

        public override string ToString()
        {
            return $"Card name: {this.cardRank} of {this.cardSuit}; Card power: {this.power}";
        }

    }
}
