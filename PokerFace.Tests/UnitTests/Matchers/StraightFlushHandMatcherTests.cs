using PokerFace.Matchers;
using PokerFace.Models;

namespace PokerFace.Tests.UnitTests.Matchers;

public class StraightFlushHandMatcherTests
{
    [Fact]
    public void Rank_ReturnsStraightFlush()
    {
        StraightFlushHandMatcher sut = new();

        Assert.Equal(HandRank.StraightFlush, sut.Rank);
    }

    [Fact]
    public void IsMatch_WhenHandIsNull_ThrowsArgumentNullException()
    {
        StraightFlushHandMatcher sut = new();

        Assert.Throws<ArgumentNullException>(() => sut.IsMatch(null));
    }

    [Theory]
    [MemberData(nameof(GetTestData))]
    public void IsMatch_ReturnsExpectedValue(Hand hand, bool expected)
    {
        StraightFlushHandMatcher sut = new();

        Assert.Equal(expected, sut.IsMatch(hand));
    }


    public static TheoryData<Hand, bool> GetTestData()
    {
        TheoryData<Hand, bool> data = new();

        List<Card> noStraight =
        [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Two, CardSuit.Heart),
            new Card(CardRank.Six, CardSuit.Heart),
            new Card(CardRank.Jack, CardSuit.Heart),
            new Card(CardRank.King, CardSuit.Heart)
        ];

        data.Add(new Hand(noStraight), false);


        List<Card> straightNotFlush =
        [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Two, CardSuit.Diamond),
            new Card(CardRank.Three, CardSuit.Club),
            new Card(CardRank.Four, CardSuit.Spade),
            new Card(CardRank.Five, CardSuit.Heart)
        ];

        data.Add(new Hand(straightNotFlush), false);

        List<Card> straightFlush =
        [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Two, CardSuit.Heart),
            new Card(CardRank.Three, CardSuit.Heart),
            new Card(CardRank.Four, CardSuit.Heart),
            new Card(CardRank.Five, CardSuit.Heart)
        ];

        data.Add(new Hand(straightFlush), true);

        return data;
    }
}
