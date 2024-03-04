using Moq;
using PokerFace.Consumers;
using PokerFace.Data.DataSource;
using PokerFace.Evaluators;
using PokerFace.Models;
using PokerFace.Service;

namespace PokerFace.Tests.UnitTests.Service;

public class PokerHandServiceTests
{
    [Fact]
    public void Constructor_WhenDataSourceIsNull_ThrowsArgumentNullException()
    {
        Mock<IHandEvaluator> evaluatorMock = new();
        Mock<IHandConsumer> consumerMock = new();

        string expectedParamName = "dataSource";

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => new PokerHandService(null, evaluatorMock.Object, consumerMock.Object)
        );

        Assert.Equal(expectedParamName, exception.ParamName);
    }

    [Fact]
    public void Constructor_WhenEvaluatorIsNull_ThrowsArgumentNullException()
    {
        Mock<IDataSource> dataSourceMock = new();
        Mock<IHandConsumer> consumerMock = new();

        string expectedParamName = "evaluator";

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => new PokerHandService(dataSourceMock.Object, null, consumerMock.Object)
        );

        Assert.Equal(expectedParamName, exception.ParamName);
    }

    [Fact]
    public void Constructor_WhenConsumerIsNull_ThrowsArgumentNullException()
    {
        Mock<IDataSource> dataSourceMock = new();
        Mock<IHandEvaluator> evaluatorMock = new();

        string expectedParamName = "consumer";

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => new PokerHandService(dataSourceMock.Object, evaluatorMock.Object, null)
        );

        Assert.Equal(expectedParamName, exception.ParamName);
    }

    [Fact]
    public void Process()
    {
        Card[] cards1 = [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Two, CardSuit.Diamond),
            new Card(CardRank.Three, CardSuit.Club),
            new Card(CardRank.Four, CardSuit.Spade),
            new Card(CardRank.Five, CardSuit.Heart)
        ];

        Card[] cards2 = [
            new Card(CardRank.Ten, CardSuit.Spade),
            new Card(CardRank.Ten, CardSuit.Heart),
            new Card(CardRank.Ten, CardSuit.Diamond),
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Ace, CardSuit.Spade)
        ];

        Hand hand1 = new(cards1);
        Hand hand2 = new(cards2);

        List<Hand> expectedHands = [hand1, hand2];

        Mock<IDataSource> dataSourceMock = new();
        dataSourceMock.Setup(mock => mock.GetHands()).Returns(expectedHands);

        Mock<IHandEvaluator> evaluatorMock = new();

        Mock<IHandConsumer> consumerMock = new();

        PokerHandService sut = new(dataSourceMock.Object, evaluatorMock.Object, consumerMock.Object);
        sut.Process();

        dataSourceMock.Verify(mock => mock.GetHands(), Times.Once);
        evaluatorMock.Verify(mock => mock.Evaluate(hand1), Times.Once);
        evaluatorMock.Verify(mock => mock.Evaluate(hand2), Times.Once);
        consumerMock.Verify(mock => mock.Consume(hand1), Times.Once);
    }
}
