namespace PokerFace.Models
{
    public class Hand(IEnumerable<Card> cards)
    {
        public IEnumerable<Card> Cards { get; set; } = cards;

        public string? HandRank { get; set;}
    }
}
