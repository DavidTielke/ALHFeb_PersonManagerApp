using DavidTielke.PMA.CrossCutting.DataClasses;
using Microsoft.AspNetCore.Mvc;
using DavidTielke.PMA.Logic.Domain.PersonManagement;

namespace ServiceClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonManager _manager;

        public PersonsController(IPersonManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [Route("/Persons/Adults")]
        public IQueryable<Person> GetAllAdults()
        {
            return _manager.GetAllAdults();
        }

        [HttpGet]
        [Route("/Persons/Children")]
        public IQueryable<Person> GetAllChildren()
        {
            return _manager.GetAllChildren();
        }
    }
}
