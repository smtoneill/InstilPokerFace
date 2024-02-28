using PokerFace.Data.Converter;
using PokerFace.Models;

namespace PokerFace.Formatters;

public static class CardStringFormatter
{
    public static string Format(Card card)
    {
        char[] cardChars =
        [
            CardRankCharConverter.ToChar(card.Rank),
            CardSuitCharConverter.ToChar(card.Suit)
        ];

        return new string(cardChars);
    }

}
