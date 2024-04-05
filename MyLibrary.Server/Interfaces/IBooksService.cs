using Microsoft.AspNetCore.Mvc;

using MyLibrary.Server.Models;

namespace MyLibrary.Server.Interfaces
{
    public interface IBooksService
    {
        public Task<List<Book>> GetAllFictionBooksRequest();

        public Task<List<Book>> GetAllNonfictionBooksRequest();

        public Task<IActionResult> AddBookRequest(Book book);

        public Task<IActionResult> UpdateBookRequest(Book book);

        public Task<IActionResult> DeleteBookRequest(int id);
    }
}
