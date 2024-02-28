using PokerFace.Formatters;
using PokerFace.Models;

namespace PokerFace.Consumers.Console;

public class ConsoleHandConsumer : IHandConsumer
{
    private readonly IStringFormatter _formatter;

    public ConsoleHandConsumer(IStringFormatter formatter)
    {
        ArgumentNullException.ThrowIfNull(formatter, nameof(formatter));
        
        _formatter = formatter;
    }

    public void Consume(Hand hand)
    {
        ArgumentNullException.ThrowIfNull(hand, nameof(hand));
        System.Console.WriteLine(_formatter.Format(hand));
    }
}
