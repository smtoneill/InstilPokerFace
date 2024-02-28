using PokerFace.Models;

namespace PokerFace.Matchers;

public class OnePairHandMatcher : NOfRankHandMatcherBase
{
    public OnePairHandMatcher() : base(HandRank.OnePair, 2) { }
}
