using PokerFace.Data.Converter;
using PokerFace.Models;

namespace PokerFace.Tests.UnitTests.Data.Converter;

public class CardRankCharConverterTests
{
    [Fact]
    public void FromChar_WhenValueIsInvalid_ThrowsArgumentOutOfRangeException()
    {
        char value = 'X';

        string expectedMessage = $"'{value}' is an invalid character.";

        ArgumentOutOfRangeException actual = Assert.Throws<ArgumentOutOfRangeException>(
            () => CardRankCharConverter.FromChar(value)
        );
        
        Assert.Contains(expectedMessage, actual.Message);
        Assert.Equal(value, actual.ActualValue);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void FromChar_WhenValueIsValidOption_ReturnsExpectedCardRank(char value, CardRank rank)
    {
        Assert.Equal(rank, CardRankCharConverter.FromChar(value));
    }

    [Fact]
    public void ToChar_WhenValueIsUnsupported_ThrowsArgumentOutOfRangeException()
    {
        CardRank rank = (CardRank)int.MaxValue;

        string expectedMessage = $"'{rank}' is not a supported value.";

        ArgumentOutOfRangeException actual = Assert.Throws<ArgumentOutOfRangeException>(
            () => CardRankCharConverter.ToChar(rank)
        );

        Assert.Contains(expectedMessage, actual.Message);
        Assert.Equal(rank, actual.ActualValue);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void ToChar_WhenCardRankIsSupportedValue_ReturnsExpectedChar(char value, CardRank rank)
    {
        Assert.Equal(value, CardRankCharConverter.ToChar(rank));
    }

    public static TheoryData<char, CardRank> TestData => new()
    {
        { 'A', CardRank.Ace },
        { '2', CardRank.Two },
        { '3', CardRank.Three },
        { '4', CardRank.Four },
        { '5', CardRank.Five },
        { '6', CardRank.Six },
        { '7', CardRank.Seven },
        { '8', CardRank.Eight },
        { '9', CardRank.Nine },
        { 'T', CardRank.Ten },
        { 'J', CardRank.Jack },
        { 'Q', CardRank.Queen },
        { 'K', CardRank.King }
    };
}
