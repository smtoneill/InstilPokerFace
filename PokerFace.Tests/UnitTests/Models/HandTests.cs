using PokerFace.Matchers;
using PokerFace.Models;

namespace PokerFace.Tests.UnitTests.Models;

public class HandTests
{
    [Fact]
    public void Constructor_WhenCardsIsNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new Hand(null));
    }

    [Fact]
    public void Constructor_WhenCardsContainsUnexpectedCount_ThrowsArgumentOutOfRangeException()
    {
        List<Card> cards = [
            new Card(CardRank.Ace, CardSuit.Spade),
            new Card(CardRank.Ace, CardSuit.Spade),
            new Card(CardRank.Ace, CardSuit.Spade)
        ];

        Assert.Throws<ArgumentOutOfRangeException>(() => new Hand(cards));
    }

    [Theory]
    [MemberData(nameof(GetSameSuitTestData))]
    public void HasSameSuit_ReturnsExpectedValue(IEnumerable<Card> cards, bool expected)
    {
        Hand hand = new(cards);
        Assert.Equal(expected, hand.HasSameSuit);
    }

    [Theory]
    [MemberData(nameof(GetStraightTestData))]
    public void IsStraight_ReturnsExpectedValue(IEnumerable<Card> cards, bool expected)
    {
        Hand hand = new(cards);
        Assert.Equal(expected, hand.IsStraight);
    }

    [Fact]
    public void RankCount_ReturnsExpectedRankCounts()
    {
        List<Card> cards =
        [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Ace, CardSuit.Diamond),
            new Card(CardRank.King, CardSuit.Heart),
            new Card(CardRank.King, CardSuit.Diamond),
            new Card(CardRank.King, CardSuit.Club)
        ];

        List<RankCount> expected =
        [
            new RankCount(CardRank.Ace, 2),
            new RankCount(CardRank.King, 3)
        ];

        Hand hand = new(cards);

        Assert.Equal(expected, hand.RankCount);
    }

    [Fact]
    public void OrderedRank_ReturnsExpectedValue()
    {
        List<Card> cards = [
            new Card(CardRank.Two, CardSuit.Heart),
            new Card(CardRank.Six, CardSuit.Spade),
            new Card(CardRank.King, CardSuit.Diamond),
            new Card(CardRank.Three, CardSuit.Club),
            new Card(CardRank.Nine, CardSuit.Club)
        ];

        IEnumerable<CardRank> expected = cards.Select(card => card.Rank).OrderBy(rank => rank);

        Hand hand = new(cards);
        Assert.Equal(expected, hand.OrderedRank);
    }


    public static TheoryData<IEnumerable<Card>, bool> GetSameSuitTestData()
    {
        TheoryData<IEnumerable<Card>, bool> data = new();

        List<Card> trueCaseCards = [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Two, CardSuit.Heart),
            new Card(CardRank.Three, CardSuit.Heart),
            new Card(CardRank.King, CardSuit.Heart),
            new Card(CardRank.Queen, CardSuit.Heart)
        ];

        data.Add(trueCaseCards, true);

        List<Card> falseCaseCards = [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Two, CardSuit.Diamond),
            new Card(CardRank.Three, CardSuit.Club),
            new Card(CardRank.King, CardSuit.Spade),
            new Card(CardRank.Queen, CardSuit.Heart)
        ];

        data.Add(falseCaseCards, false);

        return data;
    }

    public static TheoryData<IEnumerable<Card>, bool> GetStraightTestData()
    {
        TheoryData<IEnumerable<Card>, bool> data = new();

        // [2, 2, 3, 4, 8] -> false, not a straight
        List<Card> notStraight = [
            new Card(CardRank.Two, CardSuit.Heart),
            new Card(CardRank.Two, CardSuit.Diamond),
            new Card(CardRank.Three, CardSuit.Club),
            new Card(CardRank.Four, CardSuit.Spade),
            new Card(CardRank.Eight, CardSuit.Club)
        ];

        data.Add(notStraight, false);

        // [2, 3, 4, 5, 6] -> true, straight, ordered
        List<Card> straight = [
            new Card(CardRank.Two, CardSuit.Heart),
            new Card(CardRank.Three, CardSuit.Diamond),
            new Card(CardRank.Four, CardSuit.Club),
            new Card(CardRank.Five, CardSuit.Spade),
            new Card(CardRank.Six, CardSuit.Club)
        ];

        data.Add(straight, true);

        // [3, 6, 2, 5, 4] -> true, straight, not ordered
        List<Card> mixedOrder = [
            new Card(CardRank.Three, CardSuit.Heart),
            new Card(CardRank.Six, CardSuit.Diamond),
            new Card(CardRank.Two, CardSuit.Club),
            new Card(CardRank.Five, CardSuit.Spade),
            new Card(CardRank.Four, CardSuit.Club)
        ];

        data.Add(mixedOrder, true);

        // [2, 3, 4, 5, A] -> true, straight, ace-low
        List<Card> aceLow = [
            new Card(CardRank.Two, CardSuit.Heart),
            new Card(CardRank.Three, CardSuit.Diamond),
            new Card(CardRank.Four, CardSuit.Club),
            new Card(CardRank.Five, CardSuit.Spade),
            new Card(CardRank.Ace, CardSuit.Club)
        ];

        data.Add(aceLow, true);

        // [T, J, K, Q, A] -> true, straight, ace-high
        List<Card> aceHigh = [
            new Card(CardRank.Ten, CardSuit.Heart),
            new Card(CardRank.Jack, CardSuit.Diamond),
            new Card(CardRank.King, CardSuit.Club),
            new Card(CardRank.Queen, CardSuit.Spade),
            new Card(CardRank.Ace, CardSuit.Club)
        ];

        data.Add(aceHigh, true);

        // [A, J, K, Q, A] -> false, not straight, pair of aces
        List<Card> pairOfAces = [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Jack, CardSuit.Diamond),
            new Card(CardRank.King, CardSuit.Club),
            new Card(CardRank.Queen, CardSuit.Spade),
            new Card(CardRank.Ace, CardSuit.Club)
        ];

        data.Add(pairOfAces, false);

        return data;
    }
}
