using PokerFace.Models;

namespace PokerFace.Matchers;

public interface IHandMatcher
{
    HandRank Rank { get; }

    bool IsMatch(Hand hand);
}
