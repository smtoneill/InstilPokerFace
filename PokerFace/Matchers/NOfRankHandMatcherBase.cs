using PokerFace.Models;

namespace PokerFace.Matchers
{
    public class NOfRankHandMatcherBase : IHandMatcher
    {
        protected NOfRankHandMatcherBase(HandRank rank, int rankCount, int matchCount = 1)
        {
            Rank = rank;
            RankCount = rankCount;
            MatchCount = matchCount;
        }

        public HandRank Rank { get; }

        protected int RankCount { get; }

        protected int MatchCount { get; }

        public bool IsMatch(Hand hand)
        {
            ArgumentNullException.ThrowIfNull(hand, nameof(hand));

            // Using RankCount to provide the card count by rank.
            // Filter by card count equals RankCount, to count the number of matching ranks.
            // Return true of the count of matching ranks equals MatchCount.

            return hand.RankCount
                .Count(rankCount => rankCount.Count == RankCount) == MatchCount;
        }
    }
}
