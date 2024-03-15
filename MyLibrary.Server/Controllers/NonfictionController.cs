using Microsoft.AspNetCore.Mvc;

using MyLibrary.Server.Interfaces;
using MyLibrary.Server.Models;

namespace MyLibrary.Server.Controllers
{
    [Route("api/nonfiction")]
    [ApiController]
    public class NonfictionController(INonfictionService service) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllNonfictionBooks()
        {
            var books = await service.GetAllNonfictionBooksRequest();
            return Ok(books);
        }

        [HttpPost("AddNew")]
        public async Task<IActionResult> AddNonfictionBook([FromBody] Book book)
        {
            var result = await service.AddNonfictionBookRequest(book);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateNonfictionBook([FromBody] Book book)
        {
            var result = await service.UpdateNonfictionBookRequest(book);
            return Ok(result);
        }

        [HttpDelete("Delte")]
        public async Task<IActionResult> DeleteNonfictionBook(int id)
        {
            var result = await service.DeleteNonfictionBookRequest(id);
            return Ok(result);
        }
    }
}
