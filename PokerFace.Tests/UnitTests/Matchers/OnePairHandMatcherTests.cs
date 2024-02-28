using PokerFace.Matchers;
using PokerFace.Models;

namespace PokerFace.Tests.UnitTests.Matchers;

public class OnePairHandMatcherTests
{
    [Fact]
    public void Rank_ReturnsOnePair()
    {
        OnePairHandMatcher sut = new();

        Assert.Equal(HandRank.OnePair, sut.Rank);
    }

    [Fact]
    public void IsMatch_WhenHandIsNull_ThrowsArgumentNullException()
    {
        OnePairHandMatcher sut = new();

        Assert.Throws<ArgumentNullException>(() => sut.IsMatch(null));
    }

    [Theory]
    [MemberData(nameof(GetTestData))]
    public void IsMatch_ReturnsExpectedValue(Hand hand, bool expected)
    {
        OnePairHandMatcher sut = new();

        Assert.Equal(expected, sut.IsMatch(hand));
    }


    public static TheoryData<Hand, bool> GetTestData()
    {
        TheoryData<Hand, bool> data = new();
        
        List<Card> noPairs =
        [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Two, CardSuit.Diamond),
            new Card(CardRank.Three, CardSuit.Club),
            new Card(CardRank.Four, CardSuit.Spade),
            new Card(CardRank.Five, CardSuit.Heart)
        ];

        data.Add(new Hand(noPairs), false);

        List<Card> onePair =
        [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Ace, CardSuit.Diamond),
            new Card(CardRank.Two, CardSuit.Club),
            new Card(CardRank.Three, CardSuit.Spade),
            new Card(CardRank.Four, CardSuit.Heart)
        ];

        data.Add(new Hand(onePair), true);

        List<Card> twoPairs =
        [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Ace, CardSuit.Diamond),
            new Card(CardRank.Two, CardSuit.Club),
            new Card(CardRank.Two, CardSuit.Spade),
            new Card(CardRank.Three, CardSuit.Heart)
        ];

        data.Add(new Hand(twoPairs), false);

        return data;
    }
}
