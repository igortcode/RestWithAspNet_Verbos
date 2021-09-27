using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsingVerbs.Data;
using UsingVerbs.Model;
using UsingVerbs.Services;

namespace UsingVerbs.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        private readonly Context _context;
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger, IPersonService personService, Context context)
        {
            _logger = logger;
            _personService = personService;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Person> people = _context.People.ToList();
            return Ok(people);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _context.People.Find(id);
            if (person == null) 
                return NotFound();
            else
                return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.People.Add(person); 
                _context.SaveChanges();
                return Ok(_context.People.OrderBy(p => p.Id).Last());
            }
            return BadRequest("Dados inconsistentes!");
            
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.People.Update(person);
                _context.SaveChanges();
               
                return Ok(_context.People.Find(person.Id));
            }
            return BadRequest("Dados inconsistentes!");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var pessoa = _context.People.Find(id);
            if(pessoa == null)
            {
                return NotFound();
            }

            _context.People.Remove(pessoa);
            _context.SaveChanges();
            return NoContent();
        }



    }
}
