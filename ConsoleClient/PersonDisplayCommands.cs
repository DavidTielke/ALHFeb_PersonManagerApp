using DavidTielke.PMA.Logic.Domain.PersonManagement;

namespace DavidTielke.PMA.UI.ConsoleClient;

public class PersonDisplayCommands : IPersonDisplayCommands
{
    private readonly IPersonManager _manager;

    public PersonDisplayCommands(IPersonManager manager)
    {
        _manager = manager;
    }

    public void DisplayAllAdults()
    {
        var adults = _manager.GetAllAdults().ToList();
        Console.WriteLine($"### Erwachsene({adults.Count})###");
        adults.ForEach(a => Console.WriteLine(a.Name));
    }

    public void DisplayAllChildren()
    {
        var children = _manager.GetAllChildren().ToList();
        Console.WriteLine($"### Kinder({children.Count})###");
        children.ForEach(c => Console.WriteLine(c.Name));
    }
}