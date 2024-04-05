using Microsoft.AspNetCore.Mvc;

using MyLibrary.Server.Models;

namespace MyLibrary.Server.Interfaces
{
    public interface IBooksRepository
    {
        public Task<List<Book>> ReturnAllFictionBooks();

        public Task<List<Book>> ReturnAllNonfictionBooks();

        public Task<IActionResult> AddNewBook(Book book);

        public Task<IActionResult> UpdateBook(Book book);

        public Task<IActionResult> DeleteBook(int id);
    }
}
