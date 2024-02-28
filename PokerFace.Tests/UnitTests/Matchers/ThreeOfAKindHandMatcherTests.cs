using PokerFace.Matchers;
using PokerFace.Models;

namespace PokerFace.Tests.UnitTests.Matchers;

public class ThreeOfAKindHandMatcherTests
{
    [Fact]
    public void Rank_ReturnsThreeOfAKind()
    {
        ThreeOfAKindHandMatcher sut = new();

        Assert.Equal(HandRank.ThreeOfAKind, sut.Rank);
    }

    [Fact]
    public void IsMatch_WhenHandIsNull_ThrowsArgumentNullException()
    {
        ThreeOfAKindHandMatcher sut = new();

        Assert.Throws<ArgumentNullException>(() => sut.IsMatch(null));
    }

    [Theory]
    [MemberData(nameof(GetTestData))]
    public void IsMatch_ReturnsExpectedValue(Hand hand, bool expected)
    {
        ThreeOfAKindHandMatcher sut = new();

        Assert.Equal(expected, sut.IsMatch(hand));
    }


    public static TheoryData<Hand, bool> GetTestData()
    {
        TheoryData<Hand, bool> data = new();
        
        List<Card> noThrees =
        [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Two, CardSuit.Diamond),
            new Card(CardRank.Three, CardSuit.Club),
            new Card(CardRank.Four, CardSuit.Spade),
            new Card(CardRank.Five, CardSuit.Heart)
        ];

        data.Add(new Hand(noThrees), false);

        List<Card> threes =
        [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Ace, CardSuit.Diamond),
            new Card(CardRank.Ace, CardSuit.Club),
            new Card(CardRank.Two, CardSuit.Spade),
            new Card(CardRank.Three, CardSuit.Heart)
        ];

        data.Add(new Hand(threes), true);

        return data;
    }
}
