namespace PokerFace.Models
{
    public class Card(CardSuit suit, CardRank rank) : IEquatable<Card>
    {
        public CardSuit Suit { get; } = suit;

        public CardRank Rank { get; } = rank;

        public string RankShortName
        {
            get
            {
                return Rank switch
                {
                    CardRank.Ace => "A",
                    CardRank.Two => "2",
                    CardRank.Three => "3",
                    CardRank.Four => "4",
                    CardRank.Five => "5",
                    CardRank.Six => "6",
                    CardRank.Seven => "7",
                    CardRank.Eight => "8",
                    CardRank.Nine => "9",
                    CardRank.Ten => "T",
                    CardRank.Jack => "J",
                    CardRank.Queen => "Q",
                    CardRank.King => "K",
                    _ => throw new ArgumentOutOfRangeException(nameof(Rank), $"Unrecognized CardRank value: {Rank}")
                };
            }
        }

        public string SuitShortName
        {
            get
            {
                return Suit switch
                {
                    CardSuit.Hearts => "H",
                    CardSuit.Diamonds => "D",
                    CardSuit.Spades => "S",
                    CardSuit.Clubs => "C",
                    _ => throw new ArgumentOutOfRangeException(nameof(Suit), $"unrecognized CardSuit value: {Suit}")
                };
            }
        }

        public String ShortName 
        { 
            get
            {
                return RankShortName + SuitShortName;
            }
        }

        public String LongName
        {
            get
            {
                return $"{Rank} of {Suit}";
            }
        }

        public override string ToString() 
        {
            return $"{LongName} => {ShortName}";
        }

        public bool Equals(Card? other)
        {
            if(other == null) 
            {
                return false;
            }

            return Suit == other.Suit && Rank == other.Rank;
        }
    }
}