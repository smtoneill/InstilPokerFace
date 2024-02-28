namespace PokerFace.Models;

public readonly struct Card(CardRank rank, CardSuit suit)
{
    public CardRank Rank { get; } = rank;

    public CardSuit Suit { get; } = suit;

    public override readonly string ToString()
    {
        return $"Rank: {Rank}, Suit: {Suit}";
    }
}