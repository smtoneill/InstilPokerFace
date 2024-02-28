using PokerFace.Formatters;
using PokerFace.Models;

namespace PokerFace.Tests.UnitTests.Formatters;

public class SimpleStringFormatterTests
{
    [Fact]
    public void Format_WhenHandIsNull_ThrowsArgumentNullException()
    {
        SimpleStringFormatter sut = new();

        Assert.Throws<ArgumentNullException>(() => sut.Format(null));
    }

    [Fact]
    public void Format_ReturnsExpectedString()
    {
        List<Card> cards =
        [
            new Card(CardRank.Ace, CardSuit.Spade),
            new Card(CardRank.King, CardSuit.Spade),
            new Card(CardRank.Queen, CardSuit.Spade),
            new Card(CardRank.Jack, CardSuit.Spade),
            new Card(CardRank.Ten, CardSuit.Spade)
        ];

        Hand hand = new(cards);
        hand.HandRank = HandRank.RoyalFlush;

        string expected = "AS KS QS JS TS => Royal flush";

        SimpleStringFormatter sut = new();

        string actual = sut.Format(hand);

        Assert.Equal(expected, actual);
    }
}
