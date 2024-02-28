using PokerFace.Models;

namespace PokerFace.Matchers
{
    public class RoyalFlushHandMatcher : IHandMatcher
    {
        public RoyalFlushHandMatcher() { }

        public HandRank Rank { get; } = HandRank.RoyalFlush;

        public bool IsMatch(Hand hand)
        {
            ArgumentNullException.ThrowIfNull(hand, nameof(hand));

            return hand.IsStraight && hand.HasSameSuit && (hand.OrderedRank.First() == CardRank.Ten);
        }
    }
}
