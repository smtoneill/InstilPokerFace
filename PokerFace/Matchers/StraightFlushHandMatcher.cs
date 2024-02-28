using PokerFace.Models;

namespace PokerFace.Matchers
{
    public class StraightFlushHandMatcher : IHandMatcher
    {
        public StraightFlushHandMatcher() { }

        public HandRank Rank { get; } = HandRank.StraightFlush;

        public bool IsMatch(Hand hand)
        {
            ArgumentNullException.ThrowIfNull(hand, nameof(hand));

            return hand.IsStraight && hand.HasSameSuit;
        }
    }
}
