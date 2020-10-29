using Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System.Linq;

namespace RestService.Controllers
{
    [Route("person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repository;

        public PersonController(IPersonRepository repo)
        {
            _repository = repo;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            var query = _repository.Get().Skip(skip).Take(take);

            return Ok(query.ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            Person person = _repository.Get().FirstOrDefault(p => p.Id == id);

            return Ok(person);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create(Person person)
        {
            _repository.Insert(person);

            return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute]int id, [FromBody]Person person)
        {
            person.Id = id;
            bool success = _repository.Update(person);

            if (success)
            {
                return Ok(person);
            }
             else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            bool success = _repository.Delete(id);

            if (success)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
