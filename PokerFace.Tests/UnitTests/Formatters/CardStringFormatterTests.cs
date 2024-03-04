using PokerFace.Formatters;
using PokerFace.Models;

namespace PokerFace.Tests.UnitTests.Formatters;

public class CardStringFormatterTests
{
    [Fact]
    public void Format_ReturnsExpectedString()
    {
        Card card = new(CardRank.Ace, CardSuit.Spade);

        string expected = "AS";

        string actual = CardStringFormatter.Format(card);

        Assert.Equal(expected, actual);
    }
}
