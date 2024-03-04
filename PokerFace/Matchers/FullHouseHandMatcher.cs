using PokerFace.Models;

namespace PokerFace.Matchers;

public class FullHouseHandMatcher : IHandMatcher
{
    public FullHouseHandMatcher() { }

    public HandRank Rank { get; } = HandRank.FullHouse;

    public bool IsMatch(Hand hand)
    {
        ArgumentNullException.ThrowIfNull(hand, nameof(hand));

        return (hand.RankCount.Count() == 2) &&
            hand.RankCount.Any(rankCount => rankCount.Count == 2) &&
            hand.RankCount.Any(rankCount => rankCount.Count == 3);
    }
}
