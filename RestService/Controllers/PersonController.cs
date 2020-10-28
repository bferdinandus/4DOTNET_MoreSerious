using Entities;
using Fakes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RestService.Controllers
{
    [Route("person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [Route("all")]
        public List<Person> Get()
        {
            PersonBuilder fk = new PersonBuilder();
            return fk.Generate(20);
        }

        [Route("{id}")]
        public Person Get(int id)
        {
            PersonBuilder fk = new PersonBuilder();
            return fk.Generate(20).FirstOrDefault(p => p.Id == id);
        }

    }
}
