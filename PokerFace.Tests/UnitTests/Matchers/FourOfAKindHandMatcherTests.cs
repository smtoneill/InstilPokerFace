using PokerFace.Matchers;
using PokerFace.Models;

namespace PokerFace.Tests.UnitTests.Matchers;

public class FourOfAKindHandMatcherTests
{
    [Fact]
    public void Rank_ReturnsFourOfAKind()
    {
        FourOfAKindHandMatcher sut = new();

        Assert.Equal(HandRank.FourOfAKind, sut.Rank);
    }

    [Fact]
    public void IsMatch_WhenHandIsNull_ThrowsArgumentNullException()
    {
        FourOfAKindHandMatcher sut = new();

        Assert.Throws<ArgumentNullException>(() => sut.IsMatch(null));
    }

    [Theory]
    [MemberData(nameof(GetTestData))]
    public void IsMatch_ReturnsExpectedValue(Hand hand, bool expected)
    {
        FourOfAKindHandMatcher sut = new();

        Assert.Equal(expected, sut.IsMatch(hand));
    }


    public static TheoryData<Hand, bool> GetTestData()
    {
        TheoryData<Hand, bool> data = new();
        
        List<Card> noFours =
        [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Two, CardSuit.Diamond),
            new Card(CardRank.Three, CardSuit.Club),
            new Card(CardRank.Four, CardSuit.Spade),
            new Card(CardRank.Five, CardSuit.Heart)
        ];

        data.Add(new Hand(noFours), false);

        
        List<Card> fours =
        [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Ace, CardSuit.Diamond),
            new Card(CardRank.Ace, CardSuit.Club),
            new Card(CardRank.Ace, CardSuit.Spade),
            new Card(CardRank.Two, CardSuit.Heart)
        ];

        data.Add(new Hand(fours), true);

        return data;
    }
}
