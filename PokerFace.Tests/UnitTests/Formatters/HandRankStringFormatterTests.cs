using PokerFace.Formatters;
using PokerFace.Models;

namespace PokerFace.Tests.UnitTests.Formatters;

public class HandRankStringFormatterTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Format_ReturnsExpectedString(HandRank rank, string expected)
    {
        Assert.Equal(expected, HandRankStringFormatter.Format(rank));
    }

    public static TheoryData<HandRank, string> TestData => new()
    {
        { HandRank.Unknown, HandRankStringFormatter.Unknown },
        { HandRank.HighCard, HandRankStringFormatter.HighCard },
        { HandRank.OnePair, HandRankStringFormatter.OnePair },
        { HandRank.TwoPair, HandRankStringFormatter.TwoPair },
        { HandRank.ThreeOfAKind, HandRankStringFormatter.ThreeOfAKind },
        { HandRank.Straight, HandRankStringFormatter.Straight },
        { HandRank.Flush, HandRankStringFormatter.Flush },
        { HandRank.FullHouse, HandRankStringFormatter.FullHouse },
        { HandRank.FourOfAKind, HandRankStringFormatter.FourOfAKind },
        { HandRank.StraightFlush, HandRankStringFormatter.StraightFlush },
        { HandRank.RoyalFlush, HandRankStringFormatter.RoyalFlush }
    };
}
