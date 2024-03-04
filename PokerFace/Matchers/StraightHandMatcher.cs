using PokerFace.Models;

namespace PokerFace.Matchers;

public class StraightHandMatcher : IHandMatcher
{
    public StraightHandMatcher() { }

    public HandRank Rank { get; } = HandRank.Straight;

    public bool IsMatch(Hand hand)
    {
        ArgumentNullException.ThrowIfNull(hand, nameof(hand));

        return hand.IsStraight;
    }
}
