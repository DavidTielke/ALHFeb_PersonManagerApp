using DavidTielke.PMA.CrossCutting.DataClasses;
using DavidTielke.PMA.Data.DataStoring;

namespace DavidTielke.PMA.Logic.PersonManagement;

public class PersonManager
{
    private readonly PersonRepository _repository;

    public PersonManager()
    {
        _repository = new PersonRepository();
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