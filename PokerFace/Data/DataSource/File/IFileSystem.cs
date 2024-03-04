namespace PokerFace.Data.DataSource.File;

public interface IFileSystem
{
    bool FileExists(string path);

    IEnumerable<string> ReadLines(string path);
}
