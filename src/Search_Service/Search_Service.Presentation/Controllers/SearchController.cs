using Microsoft.AspNetCore.Mvc;
using Search_Service.Domain.Entities;
using Search_Service.Application.Services.Interfaces;

namespace Search_Service.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return BadRequest("Query cannot be empty");
            }

            try
            {
                var results = await _searchService.SearchDocumentAsync(query);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("index")]
        public async Task<IActionResult> IndexDocument([FromBody] SearchDocument document)
        {
            if (document == null)
            {
                return BadRequest("Document cannot be null");
            }

            try
            {
                await _searchService.IndexDocumentAsync(document);
                return Ok("Document indexed successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}