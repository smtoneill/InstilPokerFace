using Moq;
using PokerFace.Data.DataSource.File;
using PokerFace.Data.Parser;
using PokerFace.Models;
using System;

namespace PokerFace.Tests.UnitTests.Data.DataSource.File;

public class TextFileDataSourceTests
{
    [Fact]
    public void Constructor_WhenFileSystemIsNull_ThrowsArgumentNullException()
    {
        Mock<IParser> parserMock = new();
        string filePath = "c:\\path\\hands.txt";

        string expectedParamName = "fileSystem";

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => new TextFileDataSource(null, parserMock.Object, filePath)
        );

        Assert.Equal(expectedParamName, exception.ParamName);
    }

    [Fact]
    public void Constructor_WhenParserIsNull_ThrowsArgumentNullException()
    {
        Mock<IFileSystem> fileSystemMock = new();
        string filePath = "c:\\path\\hands.txt";

        string expectedParamName = "parser";

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => new TextFileDataSource(fileSystemMock.Object, null, filePath)
        );

        Assert.Equal(expectedParamName, exception.ParamName);
    }

    [Fact]
    public void Constructor_WhenFilePathIsNull_ThrowsArgumentException()
    {
        Mock<IFileSystem> fileSystemMock = new();
        Mock<IParser> parserMock = new();

        string expectedParamName = "filePath";

        ArgumentException exception = Assert.ThrowsAny<ArgumentException>(
            () => new TextFileDataSource(fileSystemMock.Object, parserMock.Object, null)
        );

        Assert.Equal(expectedParamName, exception.ParamName);
    }

    [Fact]
    public void GetHands_WhenFilePathDoesNotExist_ThrowsFileNotFoundException()
    {
        Mock<IFileSystem> fileSystemMock = new();
        fileSystemMock.Setup(mock => mock.FileExists(It.IsAny<string>())).Returns(false);

        Mock<IParser> parserMock = new();
        string filePath = "c:\\path\\hands.txt";

        TextFileDataSource sut = new(fileSystemMock.Object, parserMock.Object, filePath);

        string expectedMessage = "The specified file could not be found.";

        FileNotFoundException exception = Assert.Throws<FileNotFoundException>(
            () => sut.GetHands()
        );

        Assert.Equal(expectedMessage, exception.Message);
        Assert.Equal(filePath, exception.FileName);
    }

    [Fact]
    public void GetHands_ReturnsExpectedValues()
    {
        string[] fileLines = [
            "AH 2D 3C 4S 5H",
            "TS TH TD AH AS"
        ];

        Card[] line1Cards = [
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Two, CardSuit.Diamond),
            new Card(CardRank.Three, CardSuit.Club),
            new Card(CardRank.Four, CardSuit.Spade),
            new Card(CardRank.Five, CardSuit.Heart)
        ];

        Card[] line2Cards = [
            new Card(CardRank.Ten, CardSuit.Spade),
            new Card(CardRank.Ten, CardSuit.Heart),
            new Card(CardRank.Ten, CardSuit.Diamond),
            new Card(CardRank.Ace, CardSuit.Heart),
            new Card(CardRank.Ace, CardSuit.Spade)
        ];

        Hand[] expectedHands = [
            new Hand(line1Cards),
            new Hand(line2Cards)
        ];

        Mock<IFileSystem> fileSystemMock = new();
        fileSystemMock.Setup(mock => mock.FileExists(It.IsAny<string>())).Returns(true);
        fileSystemMock.Setup(mock => mock.ReadLines(It.IsAny<string>())).Returns(fileLines);

        Mock<IParser> parserMock = new();
        parserMock.Setup(mock => mock.Parse(fileLines[0])).Returns(expectedHands[0]);
        parserMock.Setup(mock => mock.Parse(fileLines[1])).Returns(expectedHands[1]);

        string filePath = "c:\\path\\hands.txt";

        TextFileDataSource sut = new(fileSystemMock.Object, parserMock.Object, filePath);

        IEnumerable<Hand> actual = sut.GetHands();

        Assert.Equal(actual, expectedHands);
        fileSystemMock.Verify(mock => mock.FileExists(filePath), Times.Once);
        fileSystemMock.Verify(mock => mock.ReadLines(filePath), Times.Once);
        parserMock.Verify(mock => mock.Parse(It.IsAny<string>()), Times.Exactly(2));
    }
}
