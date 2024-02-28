namespace PokerFace.Data.DataSource.File;

public class FileSystem : IFileSystem
{
    public FileSystem() { }

    public bool FileExists(string path)
    {
        ArgumentException.ThrowIfNullOrEmpty(path, nameof(path));

        return System.IO.File.Exists(path);
    }

    public IEnumerable<string> ReadLines(string path)
    {
        ArgumentException.ThrowIfNullOrEmpty(path, nameof(path));

        return System.IO.File.ReadLines(path);
    }
}
