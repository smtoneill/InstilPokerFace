using PokerFace.Models;

namespace PokerFace.Matchers;

public class ThreeOfAKindHandMatcher : NOfRankHandMatcherBase
{
    public ThreeOfAKindHandMatcher() : base(HandRank.ThreeOfAKind, 3) { }
}
