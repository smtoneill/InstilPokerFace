using PokerFace.Matchers;
using PokerFace.Models;

namespace PokerFace.Tests.UnitTests.Matchers;

public class HighCardHandMatcherTests
{
    [Fact]
    public void Rank_ReturnsHighCard()
    {
        HighCardHandMatcher sut = new();

        Assert.Equal(HandRank.HighCard, sut.Rank);
    }

    [Fact]
    public void IsMatch_ReturnsTrue()
    {
        HighCardHandMatcher sut = new();

        IEnumerable<Card> cards = [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Two, CardSuit.Diamond),
            new Card(CardRank.Three, CardSuit.Club),
            new Card(CardRank.Four, CardSuit.Spade),
            new Card(CardRank.Five, CardSuit.Spade)
        ];

        Hand hand = new(cards);

        Assert.True(sut.IsMatch(hand));
    }
}
