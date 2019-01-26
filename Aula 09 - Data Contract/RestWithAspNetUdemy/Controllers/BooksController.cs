using RestWithAspNetUdemy.Services;
using Microsoft.AspNetCore.Mvc;
using RestWithAspNetUdemy.Data.VO;

namespace RestWithAspNetUdemy.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BooksController : Controller
    {
        private IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
           return Ok(_bookService.FindAll());
        }

        // GET api/values/5
        //[HttpGet("v1.0/{id}")]
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var bookVO = _bookService.FindById(id);

            if (bookVO == null)
                return NotFound();

            return Ok(bookVO); 
        }

        // POST api/values
        //[HttpPost("v1.0")]
        [HttpPost]
        public IActionResult Post([FromBody]BookVO bookVO)
        {
            if (bookVO == null)
                return BadRequest();

            return new OkObjectResult(_bookService.Create(bookVO));
        }

        // PUT api/values/
        //[HttpPut("v1.0")]
        [HttpPut]
        public IActionResult Put([FromBody]BookVO bookVO)
        {
            if (bookVO == null)
                return BadRequest();

            return new OkObjectResult(_bookService.Update(bookVO));
        }

        // DELETE api/values/5
        //[HttpDelete("v1.0/{id}")]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookService.Delete(id);

            return NoContent();
        }
    }
}
