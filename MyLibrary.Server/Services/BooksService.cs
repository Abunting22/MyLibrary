using Microsoft.AspNetCore.Mvc;

using MyLibrary.Server.Interfaces;
using MyLibrary.Server.Models;

namespace MyLibrary.Server.Services
{
    public class BooksService(IBooksRepository repository) : IBooksService
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
                Console.WriteLine($"Error in GetAllFictionBooksRequest: {ex.Message}");
                throw new Exception("Error returning fiction books.");
            }
        }

        public async Task<List<Book>> GetAllNonfictionBooksRequest()
        {
            try
            {
                var books = await repository.ReturnAllNonfictionBooks();
                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllNonfictionBooksRequest: {ex.Message}");
                throw new Exception("Error returning nonfiction books.");
            }
        }

        public async Task<IActionResult> AddBookRequest(Book book)
        {
            try
            {
                return await repository.AddNewBook(book);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddBookRequest: {ex.Message}");
                throw new Exception("Error adding new book.");
            }
        }

        public async Task<IActionResult> UpdateBookRequest(Book book)
        {
            try
            {
                return await repository.UpdateBook(book);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateBookRequest: {ex.Message}");
                throw new Exception("Error updating book.");
            }
        }

        public async Task<IActionResult> DeleteBookRequest(int bookId)
        {
            try
            {
                return await repository.DeleteBook(bookId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteBookRequest: {ex.Message}");
                throw new Exception("Error deleting book.");
            }
        }
    }
}
