using DavidTielke.PMA.CrossCutting.DataClasses;
using DavidTielke.PMA.Data.DataStoring;

namespace DavidTielke.PMA.Logic.Domain.PersonManagement;

public class PersonManager : IPersonManager
{
    private readonly IPersonRepository _repository;

    public PersonManager(IPersonRepository repository)
    {
        _repository = repository;
    }

    public IQueryable<Person> GetAllAdults()
    {
        return from t in _repository.Query()
            where t.Age >= 18
            select t;
    }

    public IQueryable<Person> GetAllChildren()
    {
        return _repository
            .Query()
            .Where(p => p.Age < 18);
    }
}