using PokerFace.Consumers;
using PokerFace.Data.DataSource;
using PokerFace.Evaluators;
using PokerFace.Models;

namespace PokerFace.Service;

public class PokerHandService
{
    private readonly IDataSource _dataSource;
    private readonly IHandEvaluator _evaluator;
    private readonly IHandConsumer _consumer;

    public PokerHandService(IDataSource dataSource, IHandEvaluator evaluator, IHandConsumer consumer)
    {
        ArgumentNullException.ThrowIfNull(dataSource, nameof(dataSource));
        ArgumentNullException.ThrowIfNull(evaluator, nameof(evaluator));
        ArgumentNullException.ThrowIfNull(consumer, nameof(consumer));

        _dataSource = dataSource;
        _evaluator = evaluator;
        _consumer = consumer;
    }

    public void Process()
    {
        foreach (Hand hand in _dataSource.GetHands())
        {
            _evaluator.Evaluate(hand);
            _consumer.Consume(hand);
        }
    }
}
