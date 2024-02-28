using PokerFace.Models;

namespace PokerFace.Tests.UnitTests.Models;

public class CardTests
{
    [Fact]
    public void ToString_ReturnsExpectedValue()
    {
        CardRank rank = CardRank.King;
        CardSuit suit = CardSuit.Spade;

        Card card = new(rank, suit);

        string expected = $"Rank: {rank}, Suit: {suit}";

        Assert.Equal(expected, card.ToString());
    }
}
