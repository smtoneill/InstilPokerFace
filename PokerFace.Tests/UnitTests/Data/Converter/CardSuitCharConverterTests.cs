using PokerFace.Data.Converter;
using PokerFace.Models;

namespace PokerFace.Tests.UnitTests.Data.Converter;

public class HandRankStringFormatterTests
{
    [Fact]
    public void FromChar_WhenValueIsInvalid_ThrowsArgumentOutOfRangeException()
    {
        char value = 'X';

        string expectedMessage = $"'{value}' is an invalid character.";

        ArgumentOutOfRangeException actual = Assert.Throws<ArgumentOutOfRangeException>(
            () => CardSuitCharConverter.FromChar(value)
        );

        Assert.Contains(expectedMessage, actual.Message);
        Assert.Equal(value, actual.ActualValue);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void FromChar_WhenValueIsValidOption_ReturnsExpectedCardSuit(char value, CardSuit suit)
    {
        Assert.Equal(suit, CardSuitCharConverter.FromChar(value));
    }

    [Fact]
    public void ToChar_WhenValueIsUnsupported_ThrowsArgumentOutOfRangeException()
    {
        CardSuit suit = (CardSuit)int.MaxValue;

        string expectedMessage = $"'{suit}' is not a supported value.";

        ArgumentOutOfRangeException actual = Assert.Throws<ArgumentOutOfRangeException>(
            () => CardSuitCharConverter.ToChar(suit)
        );

        Assert.Contains(expectedMessage, actual.Message);
        Assert.Equal(suit, actual.ActualValue);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void ToChar_WhenCardRankIsSupportedValue_ReturnsExpectedChar(char value, CardSuit suit)
    {
        Assert.Equal(value, CardSuitCharConverter.ToChar(suit));
    }

    public static TheoryData<char, CardSuit> TestData => new()
    {
        { 'H', CardSuit.Heart },
        { 'D', CardSuit.Diamond },
        { 'S', CardSuit.Spade },
        { 'C', CardSuit.Club }
    };
}
