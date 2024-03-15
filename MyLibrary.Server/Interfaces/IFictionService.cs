using Microsoft.AspNetCore.Mvc;

using MyLibrary.Server.Models;

namespace MyLibrary.Server.Interfaces
{
    public interface IFictionService
    {
        public Task<List<Book>> GetAllFictionBooksRequest();
        public Task<IActionResult> AddFictionBookRequest(Book book);
        public Task<IActionResult> UpdateFictionBookRequest(Book book);
        public Task<IActionResult> DeleteFictionBookRequest(int id);
    }
}
