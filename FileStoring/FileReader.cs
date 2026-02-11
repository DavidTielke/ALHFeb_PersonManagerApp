namespace DavidTielke.PMA.Data.FileStoring;

public interface IFileReader
{
    IEnumerable<string> ReadLines(string path);
}

public class FileReader : IFileReader
{
    public IEnumerable<string> ReadLines(string path)
    {
        return File.ReadLines(path);
    }
}