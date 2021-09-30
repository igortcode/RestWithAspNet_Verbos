using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsingVerbs.Business;
using UsingVerbs.Data;
using UsingVerbs.Model;

namespace UsingVerbs.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/{controller}/v{version:apiVersion}")]
    public class PersonController : Controller
    {
        private readonly IPersonBusiness _personBusiness;
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personService)
        {
            _logger = logger;
            _personBusiness = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {

            try
            {
                var person = _personBusiness.FindById(id);
                return Ok(person);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    return Ok(_personBusiness.Create(person));
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest("Dados inconsistentes!");

        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Person p = _personBusiness.Update(person);
                    if (p != null)
                        return Ok(p);
                    else
                        return NotFound();
                }
                catch (Exception)
                {
                    BadRequest();
                }

            }
            return BadRequest("Dados inconsistentes!");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                if (_personBusiness.Delete(id))
                    return NoContent();
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
