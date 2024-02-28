using PokerFace.Data.Parser;
using PokerFace.Models;

namespace PokerFace.Tests.UnitTests.Data.Parser;

public class StringParserTests
{
    [Fact]
    public void Parse_WhenRecordIsNullOrEmptyString_ThrowsArgumentException()
    {
        StringParser sut = new();

        Assert.Throws<ArgumentException>(() => sut.Parse(string.Empty));
    }

    [Theory]
    [InlineData("AS 2C 3D 4H", 4)]
    [InlineData("AS 2C 3D 4H 5S 6H", 6)]
    public void Parse_WhenRecordHasIncorrectNumberOfTokens_ThrowsParserException(string record, int received)
    {
        StringParser sut = new();

        string expectedMessage = $"Record contains an unexpected number of tokens. Expected 5, received {received}.";

        ParserException exception = Assert.Throws<ParserException>(() => sut.Parse(record));

        Assert.Equal(expectedMessage, exception.Message);
    }

    [Theory]
    [InlineData("A 2S 3D 4H 5C", "A")]
    [InlineData("ABS 2S 3D 4H 5S", "ABS")]
    public void Parse_WhenTokenLengthIsInvalid_ThrowsParserException(string record, string errorToken)
    {
        StringParser sut = new();

        string expectedMessage = $"Token length is invalid, expected 2 characters but received {errorToken.Length} characters for token '{errorToken}'.";

        ParserException exception = Assert.Throws<ParserException>(() => sut.Parse(record));

        Assert.Equal(expectedMessage, exception.Message);
    }


    [Fact]
    public void Parse_WhenTokenHasInvalidRankCharacter_ThrowsParserException()
    {
        StringParser sut = new();

        string errorToken = "XS";
        string record = errorToken + " 2D 3H 4C 5S";

        string expectedmessage = $"Error parsing card rank for token '{errorToken}'.";

        ParserException exception = Assert.Throws<ParserException>(() => sut.Parse(record));

        Assert.Equal(expectedmessage, exception.Message);
        Assert.IsAssignableFrom<ArgumentException>(exception.InnerException);
    }

    [Fact]
    public void Parse_WhenTokenHasInvalidSuitCharacter_ThrowsParserException()
    {
        StringParser sut = new();

        string errorToken = "AX";
        string record = errorToken + " 2D 3H 4C 5S";

        string expectedmessage = $"Error parsing card suit for token '{errorToken}'.";

        ParserException exception = Assert.Throws<ParserException>(() => sut.Parse(record));

        Assert.Equal(expectedmessage, exception.Message);
        Assert.IsAssignableFrom<ArgumentException>(exception.InnerException);
    }

    [Fact]
    public void Parse_WhenRecordIsValid_ReturnsHandWithExpectedCards()
    {
        string record = "AH 2D 3S 4C 5S";

        List<Card> expectedCards =
        [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Two, CardSuit.Diamond),
            new Card(CardRank.Three, CardSuit.Spade),
            new Card(CardRank.Four, CardSuit.Club),
            new Card(CardRank.Five, CardSuit.Spade)
        ];

        StringParser sut = new();

        Hand actual = sut.Parse(record);

        Assert.Equal(expectedCards, actual.Cards);
    }
}
