﻿using Entity.Models;
using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Entities.DataTransferObjects;
using Presentation.ActionFilters;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Http.Headers;
using System.Text.Json;

namespace Presentation.Controllers
{
    [ServiceFilter(typeof(LoggerFilterAttribute))]
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
        public async Task<IActionResult> GetAllBooksAsync([FromQuery] BookParameters bookParams)
        {
            var pagedResult = await _manager.BookServices.GetAllBooksAsync(bookParams,false);
            Response.Headers.Add("X-Pagination",JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.books);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneBookAsync([FromRoute] int id)
        {
            var book = await _manager.BookServices.GetOneBookByIdAsync(id, false);
            return Ok(book);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneBookAsync([FromBody] BookDtoForInsertion bookDto)
        {   
            var book = await _manager.BookServices.CreateOneBookAsync(bookDto);
            return StatusCode(201, book);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneBookAsync([FromRoute] int id, [FromBody] BookDtoForUpdate bookDto)
        {
            await _manager.BookServices.UpdateOneBookAsync(id, bookDto, false);
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneBooksAsync([FromRoute] int id)
        {
            await _manager.BookServices.DeleteOneBookAsync(id, true);

            return NoContent();
        }
    }
}
