using PokerFace.Data.Parser;
using PokerFace.Models;

namespace PokerFace.Data.DataSource.File;

public class TextFileDataSource : IDataSource
{
    private readonly IFileSystem _fileSystem;
    private readonly IParser _parser;
    private readonly string _filePath;

    public TextFileDataSource(IFileSystem fileSystem, IParser parser, string filePath)
    {
        ArgumentNullException.ThrowIfNull(fileSystem, nameof(fileSystem));
        ArgumentNullException.ThrowIfNull(parser, nameof(parser));
        ArgumentException.ThrowIfNullOrEmpty(filePath, nameof(filePath));

        _fileSystem = fileSystem;
        _parser = parser;
        _filePath = filePath;
    }

    public IEnumerable<Hand> GetHands()
    {
        ThrowIfFileDoesNotExist();

        IEnumerable<string> fileLines = _fileSystem.ReadLines(_filePath);

        List<Hand> hands = new();

        foreach (string line in fileLines)
        {
            hands.Add(_parser.Parse(line));
        }

        return hands;
    }


    private void ThrowIfFileDoesNotExist()
    {
        if (!_fileSystem.FileExists(_filePath))
        {
            throw new FileNotFoundException("The specified file could not be found.", _filePath);
        }
    }
}
