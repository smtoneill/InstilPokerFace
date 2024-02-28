using PokerFace.Matchers;
using PokerFace.Models;

namespace PokerFace.Evaluators;

public class HandEvaluator : IHandEvaluator
{
    private readonly IEnumerable<IHandMatcher> _orderedMatchers;

    public HandEvaluator()
    {
        List<IHandMatcher> matchers = [
            new HighCardHandMatcher(),
            new OnePairHandMatcher(),
            new TwoPairHandMatcher(),
            new ThreeOfAKindHandMatcher(),
            new StraightHandMatcher(),
            new FlushHandMatcher(),
            new FullHouseHandMatcher(),
            new FourOfAKindHandMatcher(),
            new StraightFlushHandMatcher(),
            new RoyalFlushHandMatcher()
        ];

        _orderedMatchers = matchers.OrderByDescending(matcher => matcher.Rank).ToList();
    }

    public void Evaluate(Hand hand)
    {
        ArgumentNullException.ThrowIfNull(hand, nameof(hand));

        foreach (IHandMatcher matcher in _orderedMatchers)
        {
            if (matcher.IsMatch(hand))
            {
                hand.HandRank = matcher.Rank;
                break;
            }
        }
    }
}
