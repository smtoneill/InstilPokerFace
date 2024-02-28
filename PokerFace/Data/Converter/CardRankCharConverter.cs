using PokerFace.Models;

namespace PokerFace.Data.Converter;

public static class CardRankCharConverter
{
    private const char Ace = 'A';
    private const char Two = '2';
    private const char Three = '3';
    private const char Four = '4';
    private const char Five = '5';
    private const char Six = '6';
    private const char Seven = '7';
    private const char Eight = '8';
    private const char Nine = '9';
    private const char Ten = 'T';
    private const char Jack = 'J';
    private const char Queen = 'Q';
    private const char King = 'K';

    public static CardRank FromChar(char value) => value switch
    {
        Ace => CardRank.Ace,
        Two => CardRank.Two,
        Three => CardRank.Three,
        Four => CardRank.Four,
        Five => CardRank.Five,
        Six => CardRank.Six,
        Seven => CardRank.Seven,
        Eight => CardRank.Eight,
        Nine => CardRank.Nine,
        Ten => CardRank.Ten,
        Jack => CardRank.Jack,
        Queen => CardRank.Queen,
        King => CardRank.King,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, $"'{value}' is an invalid character.")
    };

    public static char ToChar(CardRank rank) => rank switch
    {
        CardRank.Ace => Ace,
        CardRank.Two => Two,
        CardRank.Three => Three,
        CardRank.Four => Four,
        CardRank.Five => Five,
        CardRank.Six => Six,
        CardRank.Seven => Seven,
        CardRank.Eight => Eight,
        CardRank.Nine => Nine,
        CardRank.Ten => Ten,
        CardRank.Jack => Jack,
        CardRank.Queen => Queen,
        CardRank.King => King,
        _ => throw new ArgumentOutOfRangeException(nameof(rank), rank, $"'{rank}' is not a supported value.")
    };
}
