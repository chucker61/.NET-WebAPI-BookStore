using Entity.Models;
using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Entities.DataTransferObjects;

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
            var book = _manager.BookServices.GetOneBookById(id, false);

            return Ok(book);
        }
        [HttpPost]
        public IActionResult CreateOneBook([FromBody] BookDtoForInsertion bookDto)
        {
            if (bookDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            
            var book = _manager.BookServices.CreateOneBook(bookDto);
            return StatusCode(201, book);
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute] int id, [FromBody] BookDtoForUpdate bookDto)
        {
            if (bookDto is null)
                return BadRequest();
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _manager.BookServices.UpdateOneBook(id, bookDto, false);
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
