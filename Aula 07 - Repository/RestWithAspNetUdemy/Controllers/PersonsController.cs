using System.Collections.Generic;
using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Services;
using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNetUdemy.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonsController : Controller
    {
        private IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        // GET api/values/5
        [HttpGet("v1.0/{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        // POST api/values
        [HttpPost("v1.0")]
        public IActionResult Post([FromBody]Person person)
        {
            if (person == null)
                return BadRequest();

            return new OkObjectResult(_personService.Create(person));
        }

        // PUT api/values/
        [HttpPut("v1.0")]
        public IActionResult Put([FromBody]Person person)
        {
            if (person == null)
                return BadRequest();

            return new OkObjectResult(_personService.Update(person));
        }

        // DELETE api/values/5
        [HttpDelete("v1.0/{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);

            return NoContent();
        }
    }
}
