using PokerFace.Models;
using System.Text;

namespace PokerFace.Formatters;

public class SimpleStringFormatter : IStringFormatter
{
    private const char CardSeparator = ' ';
    private const string HandRankSeparator = "=> ";

    public SimpleStringFormatter() { }

    public string Format(Hand hand)
    {
        ArgumentNullException.ThrowIfNull(hand, nameof(hand));

        StringBuilder builder = new();

        foreach (Card card in hand.Cards)
        {
            builder.Append(CardStringFormatter.Format(card));
            builder.Append(CardSeparator);
        }

        builder.Append(HandRankSeparator);
        
        builder.Append(HandRankStringFormatter.Format(hand.HandRank));
        
        return builder.ToString();
    }
}
