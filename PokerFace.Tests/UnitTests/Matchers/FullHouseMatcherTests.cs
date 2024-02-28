using PokerFace.Matchers;
using PokerFace.Models;

namespace PokerFace.Tests.UnitTests.Matchers;

public class FullHouseMatcherTests
{
    [Fact]
    public void Rank_ReturnsFullHouse()
    {
        FullHouseHandMatcher sut = new();

        Assert.Equal(HandRank.FullHouse, sut.Rank);
    }

    [Fact]
    public void IsMatch_WhenHandIsNull_ThrowsArgumentNullException()
    {
        FullHouseHandMatcher sut = new();

        Assert.Throws<ArgumentNullException>(() => sut.IsMatch(null));
    }

    [Theory]
    [MemberData(nameof(GetTestData))]
    public void IsMatch_ReturnsExpectedValue(Hand hand, bool expected)
    {
        FullHouseHandMatcher sut = new();

        Assert.Equal(expected, sut.IsMatch(hand));
    }


    public static TheoryData<Hand, bool> GetTestData()
    {
        TheoryData<Hand, bool> data = new();
        
        List<Card> noFullHouse =
        [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Two, CardSuit.Diamond),
            new Card(CardRank.Three, CardSuit.Club),
            new Card(CardRank.Four, CardSuit.Spade),
            new Card(CardRank.Five, CardSuit.Heart)
        ];

        data.Add(new Hand(noFullHouse), false);

        List<Card> fullHouse =
        [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Ace, CardSuit.Diamond),
            new Card(CardRank.King, CardSuit.Club),
            new Card(CardRank.King, CardSuit.Spade),
            new Card(CardRank.King, CardSuit.Heart)
        ];

        data.Add(new Hand(fullHouse), true);

        return data;
    }
}
