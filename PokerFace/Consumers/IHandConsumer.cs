using PokerFace.Models;

namespace PokerFace.Consumers;

public interface IHandConsumer
{
    void Consume(Hand hand);
}
