using PokerFace.Models;

namespace PokerFace.Matchers;

public class FourOfAKindHandMatcher : NOfRankHandMatcherBase
{
    public FourOfAKindHandMatcher() : base(HandRank.FourOfAKind, 4) { }
}
