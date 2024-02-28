using PokerFace.Models;

namespace PokerFace.Matchers;

public class TwoPairHandMatcher : NOfRankHandMatcherBase
{
    public TwoPairHandMatcher() : base(HandRank.TwoPair, 2, 2) { }
}
