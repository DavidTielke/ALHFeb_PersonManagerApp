using DavidTielke.PMA.CrossCutting.DataClasses;
using DavidTielke.PMA.Data.FileStoring;

namespace DavidTielke.PMA.Data.DataStoring;

public class PersonRepository : IPersonRepository
{
    private readonly IPersonParser _parser;
    private readonly IFileReader _reader;

    public PersonRepository(IPersonParser parser, IFileReader reader)
    {
        _parser = parser;
        _reader = reader;
    }

    public IQueryable<Person> Query()
    {
        var dataLines = _reader.ReadLines("data.csv");
        var persons = dataLines.Select(_parser.Parse);
        return persons.AsQueryable();
    }
}