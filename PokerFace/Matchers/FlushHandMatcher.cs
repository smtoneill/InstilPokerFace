using PokerFace.Models;

namespace PokerFace.Matchers
{
    public class FlushHandMatcher : IHandMatcher
    {
        public FlushHandMatcher() { }

        public HandRank Rank { get; } = HandRank.Flush;

        public bool IsMatch(Hand hand)
        {
            ArgumentNullException.ThrowIfNull(hand, nameof(hand));

            return hand.HasSameSuit;
        }
    }
}
