using PokerFace.Matchers;

namespace PokerFace.Models;

public class Hand
{
    private const int HandLength = 5;

    private readonly Lazy<bool> _isStraight;
    private readonly Lazy<bool> _sameSuit;
    private readonly Lazy<IEnumerable<RankCount>> _rankCount;
    private readonly Lazy<IEnumerable<CardRank>> _orderedRank;

    public Hand(IEnumerable<Card> cards)
    {
        ArgumentNullException.ThrowIfNull(cards, nameof(cards));
        ArgumentOutOfRangeException.ThrowIfNotEqual(cards.Count(), HandLength, nameof(cards));

        Cards = cards;

        _isStraight = new Lazy<bool>(EvaluateStraight);
        _sameSuit = new Lazy<bool>(EvaluateSameSuit);
        _rankCount = new Lazy<IEnumerable<RankCount>>(EvaluateRankCount);
        _orderedRank = new Lazy<IEnumerable<CardRank>>(EvaluateOrderedRank);
    }

    public IEnumerable<Card> Cards { get; }

    public HandRank HandRank { get; set; } = HandRank.Unknown;

    public bool HasSameSuit => _sameSuit.Value;

    public bool IsStraight => _isStraight.Value;

    public IEnumerable<RankCount> RankCount => _rankCount.Value;

    public IEnumerable<CardRank> OrderedRank => _orderedRank.Value;

    private bool EvaluateSameSuit()
    {
        return Cards.GroupBy(card => card.Suit).Count() == 1;
    }

    private bool EvaluateStraight()
    {
        List<CardRank> ordered = OrderedRank.ToList();
        CardRank firstCard = ordered.First();

        // Special case for low-ace straight. When first card is Two, only evaluate that the remaining cards are a straight.
        bool hasLowAce = (firstCard == CardRank.Two) && (ordered.Last() == CardRank.Ace);

        int count = ordered.Count - (hasLowAce ? 1 : 0);

        bool isStraight = true;

        for (int i = 1; i < count; i++)
        {
            if (ordered[i] != ordered[i - 1] + 1)
            {
                isStraight = false;
                break;
            }
        }

        return isStraight;
    }

    private IEnumerable<RankCount> EvaluateRankCount()
    {
        return Cards
            .GroupBy(hand => hand.Rank)
            .Select(group => new RankCount(group.Key, group.Count()));
    }

    private IEnumerable<CardRank> EvaluateOrderedRank()
    {
        return Cards.Select(card => card.Rank).OrderBy(rank => rank);
    }
}
