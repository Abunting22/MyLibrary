using Microsoft.AspNetCore.Mvc;

using MyLibrary.Server.Interfaces;
using MyLibrary.Server.Models;

namespace MyLibrary.Server.Controllers
{
    [Route("api/fiction")]
    [ApiController]
    public class FictionController(IFictionService service) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllFictionBooks()
        {
            var books = await service.GetAllFictionBooksRequest();
            return Ok(books);
        }

        [HttpPost("AddNew")]
        public async Task<IActionResult> AddFictionBook([FromBody]Book book)
        {
            var result = await service.AddFictionBookRequest(book);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateFictionBook([FromBody] Book book)
        {
            var result = await service.UpdateFictionBookRequest(book);
            return Ok(result);
        }

        [HttpDelete("Delte")]
        public async Task<IActionResult> DeleteFictionBook(int id)
        {
            var result = await service.DeleteFictionBookRequest(id);
            return Ok(result);
        }
    }
}