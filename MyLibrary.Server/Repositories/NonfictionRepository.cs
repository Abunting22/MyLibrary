using Dapper;
using Microsoft.AspNetCore.Mvc;

using MyLibrary.Server.Interfaces;
using MyLibrary.Server.Models;

namespace MyLibrary.Server.Repositories
{
    public class NonfictionRepository(IBaseRepository repository) : INonfictionRepository
    {
        public async Task<List<Book>> ReturnAllNonfictionBooks()
        {
            try
            {
                const string sql = @"SELECT * FROM Nonfiction";

                using var connection = repository.GetConnection();
                var books = await connection.QueryAsync<Book>(sql);
                var listBooks = books.ToList();
                return listBooks;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IActionResult> AddNewNonfictionBook(Book book)
        {
            try
            {
                const string sql = @"INSERT INTO Nonfiction (Title, Author, Edition, Genre, Publication)
                    VALUES (@Title, @Author, @Edition, @Genre, @Publication)";

                using var connection = repository.GetConnection();
                await connection.ExecuteAsync(sql, book);
                return new OkResult();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IActionResult> UpdateNonfictionBook(Book book)
        {
            try
            {
                const string sql = @"UPDATE Nonfiction
                    SET Title = @Title, Author = @Author, Edition = @Edition, Genre = @Genre, Publication = @Publication
                    WHERE BookId = @BookId";

                using var connection = repository.GetConnection();
                await connection.ExecuteAsync(sql, book);
                return new OkResult();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IActionResult> DeleteNonfictionBook(int id)
        {
            try
            {
                const string sql = @"DELETE FROM Nonfiction
                    WHERE BookId = @BookId";

                using var connection = repository.GetConnection();
                await connection.ExecuteAsync(sql, new { BookId = id });

                return new OkResult();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
