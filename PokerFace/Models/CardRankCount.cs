using PokerFace.Models;

namespace PokerFace.Matchers;

public readonly struct RankCount(CardRank rank, int count)
{
    public CardRank Rank { get; } = rank;

    public int Count { get; } = count;
}