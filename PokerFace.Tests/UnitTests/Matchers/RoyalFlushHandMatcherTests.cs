using PokerFace.Matchers;
using PokerFace.Models;

namespace PokerFace.Tests.UnitTests.Matchers;

public class RoyalFlushHandMatcherTests
{
    [Fact]
    public void Rank_ReturnsRoyalFlush()
    {
        RoyalFlushHandMatcher sut = new();

        Assert.Equal(HandRank.RoyalFlush, sut.Rank);
    }

    [Fact]
    public void IsMatch_WhenHandIsNull_ThrowsArgumentNullException()
    {
        RoyalFlushHandMatcher sut = new();

        Assert.Throws<ArgumentNullException>(() => sut.IsMatch(null));
    }

    [Theory]
    [MemberData(nameof(GetTestData))]
    public void IsMatch_ReturnsExpectedValue(Hand hand, bool expected)
    {
        RoyalFlushHandMatcher sut = new();

        Assert.Equal(expected, sut.IsMatch(hand));
    }


    public static TheoryData<Hand, bool> GetTestData()
    {
        TheoryData<Hand, bool> data = new();

        List<Card> notStraightFlush =
        [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Two, CardSuit.Heart),
            new Card(CardRank.Six, CardSuit.Heart),
            new Card(CardRank.Jack, CardSuit.Heart),
            new Card(CardRank.King, CardSuit.Heart)
        ];

        data.Add(new Hand(notStraightFlush), false);


        List<Card> straightNotFlush =
        [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Two, CardSuit.Diamond),
            new Card(CardRank.Three, CardSuit.Club),
            new Card(CardRank.Four, CardSuit.Spade),
            new Card(CardRank.Five, CardSuit.Heart)
        ];

        data.Add(new Hand(straightNotFlush), false);

        List<Card> lowAceStraightFlush =
        [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Two, CardSuit.Heart),
            new Card(CardRank.Three, CardSuit.Heart),
            new Card(CardRank.Four, CardSuit.Heart),
            new Card(CardRank.Five, CardSuit.Heart)
        ];

        data.Add(new Hand(lowAceStraightFlush), false);

        List<Card> aceHighStraightNotFlush =
        [
            new Card(CardRank.Ten, CardSuit.Heart),
            new Card(CardRank.Jack, CardSuit.Diamond),
            new Card(CardRank.Queen, CardSuit.Spade),
            new Card(CardRank.King, CardSuit.Club),
            new Card(CardRank.Ace, CardSuit.Heart)
        ];

        data.Add(new Hand(aceHighStraightNotFlush), false);

        List<Card> royalFlush =
        [
            new Card(CardRank.Ten, CardSuit.Heart),
            new Card(CardRank.Jack, CardSuit.Heart),
            new Card(CardRank.Queen, CardSuit.Heart),
            new Card(CardRank.King, CardSuit.Heart),
            new Card(CardRank.Ace, CardSuit.Heart)
        ];

        data.Add(new Hand(royalFlush), true);

        return data;
    }
}
