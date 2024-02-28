using PokerFace.Models;

namespace PokerFace.Evaluators;

public interface IHandEvaluator
{
    void Evaluate(Hand hand);
}