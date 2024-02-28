using PokerFace.Models;

namespace PokerFace.Matchers
{
    public class HighCardHandMatcher : IHandMatcher
    {
        public HighCardHandMatcher() { }

        public HandRank Rank => HandRank.HighCard;

        public bool IsMatch(Hand hand) => true;
    }
}