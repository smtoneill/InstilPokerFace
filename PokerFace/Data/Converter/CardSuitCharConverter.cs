using PokerFace.Models;

namespace PokerFace.Data.Converter;

public static class CardSuitCharConverter
{
    private const char Heart = 'H';
    private const char Diamond = 'D';
    private const char Spade = 'S';
    private const char Club = 'C';

    public static CardSuit FromChar(char value) => value switch
    {
        Heart => CardSuit.Heart,
        Diamond => CardSuit.Diamond,
        Spade => CardSuit.Spade,
        Club => CardSuit.Club,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, $"'{value}' is an invalid character.")
    };

    public static char ToChar(CardSuit suit) => suit switch
    {
        CardSuit.Heart => Heart,
        CardSuit.Diamond => Diamond,
        CardSuit.Spade => Spade,
        CardSuit.Club => Club,
        _ => throw new ArgumentOutOfRangeException(nameof(suit), suit, $"'{suit}' is not a supported value.")
    };
}
