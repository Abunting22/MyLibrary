using Microsoft.AspNetCore.Mvc;

using MyLibrary.Server.Interfaces;
using MyLibrary.Server.Models;

namespace MyLibrary.Server.Services
{
    public class FictionService(IFictionRepository repository) : IFictionService
    {
        public async Task<List<Book>> GetAllFictionBooksRequest()
        {
            try
            {
                var books = await repository.ReturnAllFictionBooks();
                return books;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IActionResult> AddFictionBookRequest(Book book)
        {
            try
            {
                return await repository.AddNewFictionBook(book);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IActionResult> UpdateFictionBookRequest(Book book)
        {
            try
            {
                return await repository.UpdateFictionBook(book);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IActionResult> DeleteFictionBookRequest(int id)
        {
            try
            {
                return await repository.DeleteFictionBook(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        


    }
}
