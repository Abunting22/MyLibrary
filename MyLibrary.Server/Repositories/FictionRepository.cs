using MyLibrary.Server.Interfaces;
using MyLibrary.Server.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace MyLibrary.Server.Repositories
{
    public class FictionRepository(IBaseRepository repository) : IFictionRepository
    {
        public async Task<List<Book>> ReturnAllFictionBooks()
        {
            try
            {
                const string sql = @"SELECT * FROM Fiction";

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

        public async Task<IActionResult> AddNewFictionBook(Book book)
        {
            try
            {
                const string sql = @"INSERT INTO Fiction (Title, Author, Genre, Publication)
                    VALUES (@Title, @Author, @Genre, @Publication)";

                using var connection = repository.GetConnection();
                await connection.ExecuteAsync(sql, book);

                return new OkResult();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IActionResult> UpdateFictionBook(Book book)
        {
            try
            {
                const string sql = @"UPDATE Fiction
                    SET Title = @Title, Author = @Author, Genre = @Genre, Publication = @Publication
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

        public async Task<IActionResult> DeleteFictionBook(int id)
        {
            try
            {
                const string sql = @"DELETE FROM Fiction
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
