using Microsoft.AspNetCore.Mvc;
using MyLibrary.Server.Models;

namespace MyLibrary.Server.Interfaces
{
    public interface INonfictionRepository
    {
        public Task<List<Book>> ReturnAllNonfictionBooks();
        public Task<IActionResult> AddNewNonfictionBook(Book book);
        public Task<IActionResult> UpdateNonfictionBook(Book book);
        public Task<IActionResult> DeleteNonfictionBook(int id);
    }
}
