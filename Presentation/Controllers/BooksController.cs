using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _manager.BookServices.GetAllBooks(false);
            return Ok(books);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute] int id)
        {
                throw new Exception("!!!");
                var book = _manager.BookServices.GetOneBookById(id, false);
                if (book == null)
                    return NotFound();

                return Ok(book);
        }
        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            if (book == null)
                return NotFound(nameof(book));

            _manager.BookServices.CreateOneBook(book);
            return StatusCode(201, book);
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute] int id, [FromBody] Book book)
        {
            if (book is null)
                return NotFound(nameof(book));

            _manager.BookServices.UpdateOneBook(id, book, true);

            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBooks([FromRoute] int id)
        {
            _manager.BookServices.DeleteOneBook(id, true);

            return NoContent();
        }
    }
}
