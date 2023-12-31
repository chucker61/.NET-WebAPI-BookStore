﻿using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Entities.DataTransferObjects;
using Presentation.ActionFilters;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Http.Headers;
using System.Text.Json;
using NLog.Config;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [ServiceFilter(typeof(LoggerFilterAttribute))]
    [ApiController]
    [Route("api/books")]
    //[ResponseCache(CacheProfileName = "5mins")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }
        [Authorize]
        [HttpHead]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        [HttpGet(Name ="GetAllBooksAsync")]
        public async Task<IActionResult> GetAllBooksAsync([FromQuery] BookParameters bookParams)
        {
            var linkParameters = new LinkParameters
            {
                BookParameters = bookParams,
                HttpContext = HttpContext
            };
            var result = await _manager.BookServices.GetAllBooksAsync(linkParameters,false);
            Response.Headers.Add("X-Pagination",JsonSerializer.Serialize(result.metaData));

            return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) : Ok(result.linkResponse.ShapedEntities);
        }
        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneBookAsync([FromRoute] int id)
        {
            var book = await _manager.BookServices.GetOneBookByIdAsync(id, false);
            return Ok(book);
        }
        [Authorize(Roles = "Editor, Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost(Name ="CreateOneBookAsync")]
        public async Task<IActionResult> CreateOneBookAsync([FromBody] BookDtoForInsertion bookDto)
        {   
            var book = await _manager.BookServices.CreateOneBookAsync(bookDto);
            return StatusCode(201, book);
        }
        [Authorize(Roles = "Editor, Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneBookAsync([FromRoute] int id, [FromBody] BookDtoForUpdate bookDto)
        {
            await _manager.BookServices.UpdateOneBookAsync(id, bookDto, false);
            return NoContent();
        }
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneBooksAsync([FromRoute] int id)
        {
            await _manager.BookServices.DeleteOneBookAsync(id, true);

            return NoContent();
        }
        [HttpOptions]
        public IActionResult GetBookOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE, HEAD, OPTIONS");
            return Ok();
        }
    }
}
