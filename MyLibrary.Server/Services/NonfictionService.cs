using Microsoft.AspNetCore.Mvc;

using MyLibrary.Server.Interfaces;
using MyLibrary.Server.Models;

namespace MyLibrary.Server.Services
{
    public class NonfictionService(INonfictionRepository repository) : INonfictionService
    {
        public async Task<List<Book>> GetAllNonfictionBooksRequest()
        {
            try
            {
                var books = await repository.ReturnAllNonfictionBooks();
                return books;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IActionResult> AddNonfictionBookRequest(Book book)
        {
            try
            {
                return await repository.AddNewNonfictionBook(book);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IActionResult> UpdateNonfictionBookRequest(Book book)
        {
            try
            {
                return await repository.UpdateNonfictionBook(book);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IActionResult> DeleteNonfictionBookRequest(int id)
        {
            try
            {
                return await repository.DeleteNonfictionBook(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
