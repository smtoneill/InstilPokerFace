using PokerFace.Evaluators;
using PokerFace.Models;

namespace PokerFace.Tests.UnitTests.Evaluators;

public class HandEvaluatorTests
{
    [Fact]
    public void Evaluate_WhenHandIsNull_ThrowsArgumentNullException()
    {
        HandEvaluator sut = new();

        Assert.Throws<ArgumentNullException>(() => sut.Evaluate(null));
    }


    [Theory]
    [MemberData(nameof(GetData))]
    public void Evaluate_SetsExpectedRank(Hand hand, HandRank expected)
    {
        HandEvaluator sut = new();

        sut.Evaluate(hand);

        Assert.Equal(expected, hand.HandRank);
    }

    public static TheoryData<Hand, HandRank> GetData()
    {
        TheoryData<Hand, HandRank> data = new();

        List<Card> royalFlush =
        [
            new Card(CardRank.Ten, CardSuit.Heart),
            new Card(CardRank.Jack, CardSuit.Heart),
            new Card(CardRank.Queen, CardSuit.Heart),
            new Card(CardRank.King, CardSuit.Heart),
            new Card(CardRank.Ace, CardSuit.Heart)
        ];

        data.Add(new Hand(royalFlush), HandRank.RoyalFlush);

        List<Card> straightFlush =
        [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Two, CardSuit.Heart),
            new Card(CardRank.Three, CardSuit.Heart),
            new Card(CardRank.Four, CardSuit.Heart),
            new Card(CardRank.Five, CardSuit.Heart)
        ];

        data.Add(new Hand(straightFlush), HandRank.StraightFlush);

        List<Card> fourOfAKind =
        [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Ace, CardSuit.Diamond),
            new Card(CardRank.Ace, CardSuit.Club),
            new Card(CardRank.Ace, CardSuit.Spade),
            new Card(CardRank.Two, CardSuit.Heart)
        ];

        data.Add(new Hand(fourOfAKind), HandRank.FourOfAKind);

        List<Card> fullHouse =
        [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Ace, CardSuit.Diamond),
            new Card(CardRank.King, CardSuit.Club),
            new Card(CardRank.King, CardSuit.Spade),
            new Card(CardRank.King, CardSuit.Heart)
        ];

        data.Add(new Hand(fullHouse), HandRank.FullHouse);

        List<Card> flush =
        [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Two, CardSuit.Heart),
            new Card(CardRank.Six, CardSuit.Heart),
            new Card(CardRank.Jack, CardSuit.Heart),
            new Card(CardRank.King, CardSuit.Heart)
        ];

        data.Add(new Hand(flush), HandRank.Flush);

        List<Card> straight =
        [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Two, CardSuit.Diamond),
            new Card(CardRank.Three, CardSuit.Club),
            new Card(CardRank.Four, CardSuit.Spade),
            new Card(CardRank.Five, CardSuit.Heart)
        ];

        data.Add(new Hand(straight), HandRank.Straight);

        List<Card> threeOfAKind =
        [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Ace, CardSuit.Diamond),
            new Card(CardRank.Ace, CardSuit.Club),
            new Card(CardRank.Two, CardSuit.Spade),
            new Card(CardRank.Three, CardSuit.Heart)
        ];

        data.Add(new Hand(threeOfAKind), HandRank.ThreeOfAKind);

        List<Card> twoPairs =
       [
           new Card(CardRank.Ace, CardSuit.Heart),
           new Card(CardRank.Ace, CardSuit.Diamond),
           new Card(CardRank.Two, CardSuit.Club),
           new Card(CardRank.Two, CardSuit.Spade),
           new Card(CardRank.Three, CardSuit.Heart)
       ];

        data.Add(new Hand(twoPairs), HandRank.TwoPair);

        List<Card> onePair =
        [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Ace, CardSuit.Diamond),
            new Card(CardRank.Two, CardSuit.Club),
            new Card(CardRank.Three, CardSuit.Spade),
            new Card(CardRank.Four, CardSuit.Heart)
        ];

        data.Add(new Hand(onePair), HandRank.OnePair);

        IEnumerable<Card> highCard = [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Two, CardSuit.Diamond),
            new Card(CardRank.Six, CardSuit.Club),
            new Card(CardRank.Eight, CardSuit.Spade),
            new Card(CardRank.Jack, CardSuit.Spade)
        ];

        data.Add(new Hand(highCard), HandRank.HighCard);

        return data;
    }
}
