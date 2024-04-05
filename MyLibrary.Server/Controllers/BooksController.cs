using Microsoft.AspNetCore.Mvc;
using MyLibrary.Server.Interfaces;
using MyLibrary.Server.Models;

namespace MyLibrary.Server.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController(IBooksService service) : ControllerBase
    {
        [HttpGet("GetAllFiction")]
        public async Task<IActionResult> GetAllFictionBooks()
        {
            var books = await service.GetAllFictionBooksRequest();
            return Ok(books);
        }

        [HttpGet("GetAllNonfiction")]
        public async Task<IActionResult> GetAllNonfictionBooks()
        {
            var books = await service.GetAllNonfictionBooksRequest();
            return Ok(books);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            var result = await service.AddBookRequest(book);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateBook([FromBody] Book book)
        {
            var result = await service.UpdateBookRequest(book);
            return Ok(result);
        }

        [HttpDelete("Delete/{bookId}")]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            var result = await service.DeleteBookRequest(bookId);
            return Ok(result);
        }
    }
}
