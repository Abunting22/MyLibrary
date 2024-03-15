using Microsoft.AspNetCore.Mvc;

using MyLibrary.Server.Models;

namespace MyLibrary.Server.Interfaces
{
    public interface INonfictionService
    {
        public Task<List<Book>> GetAllNonfictionBooksRequest();
        public Task<IActionResult> AddNonfictionBookRequest(Book book);
        public Task<IActionResult> UpdateNonfictionBookRequest(Book book);
        public Task<IActionResult> DeleteNonfictionBookRequest(int id);
    }
}
