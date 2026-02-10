namespace ConsoleClient
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        {
            
        }
    }

    public class FileReader
    {
        public IEnumerable<string> ReadLines(string path)
        {
            return File.ReadLines(path);
        }
    }

    public class PersonParser
    {
        public Person Parse(string dataLine)
        {
            var parts = dataLine.Split(",");
            var person = new Person
            {
                Id = int.Parse(parts[0]),
                Name = parts[1],
                Age = int.Parse(parts[2])
            };

            return person;
        }
    }

    public class PersonRepository
    {
        private readonly PersonParser _parser;
        private readonly FileReader _reader;

        public PersonRepository()
        {
            _parser = new PersonParser();
            _reader = new FileReader();
        }

        public IQueryable<Person> Query()
        {
            var dataLines = _reader.ReadLines("data.csv");
            var persons = dataLines.Select(_parser.Parse);
            return persons.AsQueryable();
        }
    }

    public class PersonManager
    {
        private readonly PersonRepository _repository;

        public PersonManager()
        {
            _repository = new PersonRepository();
        }

        public IQueryable<Person> GetAllAdults()
        {
            return _repository
                .Query()
                .Where(p => p.Age >= 18);
        }

        public IQueryable<Person> GetAllChildren()
        {
            return _repository
                .Query()
                .Where(p => p.Age < 18);
        }
    }

    public class PersonDisplayCommands
    {
        private readonly PersonManager _manager;

        public PersonDisplayCommands()
        {
            _manager = new PersonManager();
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

    internal class Program
    {
        static void Main(string[] args)
        {
            var displayCommands = new PersonDisplayCommands();
            displayCommands.DisplayAllAdults();
            displayCommands.DisplayAllChildren();
        }
    }
}
