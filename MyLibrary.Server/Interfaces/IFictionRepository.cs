using Microsoft.AspNetCore.Mvc;

using MyLibrary.Server.Models;

namespace MyLibrary.Server.Interfaces
{
    public interface IFictionRepository
    {
        public Task<List<Book>> ReturnAllFictionBooks();
        public Task<IActionResult> AddNewFictionBook(Book book);
        public Task<IActionResult> UpdateFictionBook(Book book);
        public Task<IActionResult> DeleteFictionBook(int id);
    }
}
