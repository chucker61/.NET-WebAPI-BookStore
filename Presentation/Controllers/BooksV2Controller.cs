using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiExplorerSettings(GroupName = "v2")]
    [ApiController]
    [Route("api/books")]
    public class BooksV2Controller : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksV2Controller(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            var books = await _manager.BookServices.GetAllBooksAsync(false);
            var booksv2 = books.Select(b => new
            {
                Name = b.Name,
                Price = b.Price,
            });
            return Ok(booksv2);
        }
    }
}
