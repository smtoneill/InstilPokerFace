using PokerFace.Data.Converter;
using PokerFace.Models;

namespace PokerFace.Data.Parser;

public class StringParser : IParser
{
    private const char TokenSeparator = ' ';
    private const int TokenCount = 5;
    private const int TokenLength = 2;

    public StringParser() { }

    public Hand Parse(string record)
    {
        ArgumentException.ThrowIfNullOrEmpty(record, nameof(record));

        string[] tokens = Tokenize(record);

        List<Card> cards = new(TokenCount);

        foreach (string token in tokens)
        {
            cards.Add(ParseToken(token));
        }

        return new Hand(cards.AsReadOnly());
    }


    private static string[] Tokenize(string record)
    {
        string[] tokens = record.Split(TokenSeparator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        if (tokens.Length != TokenCount)
        {
            throw new ParserException($"Record contains an unexpected number of tokens. Expected {TokenCount}, received {tokens.Length}.");
        }

        return tokens;
    }

    private static Card ParseToken(string token)
    {
        if (token.Length != TokenLength)
        {
            throw new ParserException($"Token length is invalid, expected {TokenLength} characters but received {token.Length} characters for token '{token}'.");
        }

        CardRank rank;

        try
        {
            rank = CardRankCharConverter.FromChar(token[0]);
        }
        catch (ArgumentException ex)
        {
            throw new ParserException($"Error parsing card rank for token '{token}'.", ex);
        }

        CardSuit suit;

        try
        {
            suit = CardSuitCharConverter.FromChar(token[1]);
        }
        catch (ArgumentException ex)
        {
            throw new ParserException($"Error parsing card suit for token '{token}'.", ex);
        }

        return new Card(rank, suit);
    }
}
