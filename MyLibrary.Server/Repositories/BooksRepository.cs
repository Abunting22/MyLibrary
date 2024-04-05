using Dapper;

using Microsoft.AspNetCore.Mvc;

using MyLibrary.Server.Interfaces;
using MyLibrary.Server.Models;

namespace MyLibrary.Server.Repositories
{
    public class BooksRepository(IBaseRepository repository) : IBooksRepository
    {
        public async Task<List<Book>> ReturnAllFictionBooks()
        {
            try
            {
                const string sql = @"SELECT * FROM Books WHERE Category = 1;";

                using var connection = repository.GetConnection();
                var books = await connection.QueryAsync<Book>(sql);
                var listFictionBooks = books.ToList();

                return listFictionBooks;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Book>> ReturnAllNonfictionBooks()
        {
            try
            {
                const string sql = @"SELECT * FROM Books WHERE Category = 2;";

                using var connection = repository.GetConnection();
                var books = await connection.QueryAsync<Book>(sql);
                var listNonfictionBooks = books.ToList();

                return listNonfictionBooks;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IActionResult> AddNewBook(Book book)
        {
            try
            {
                const string sql = @"INSERT INTO Books (Category, Title, Author, PublicationYear, Genre, Edition)
                    VALUES (@Category, @Title, @Author, @PublicationYear, @Genre, @Edition)";

                using var connection = repository.GetConnection();
                await connection.ExecuteAsync(sql, book);

                return new OkResult();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IActionResult> UpdateBook(Book book)
        {
            try
            {
                const string sql = @"UPDATE Books
                    SET Category = @Category, Title = @Title, Author = @Author, PublicationYear = @PublicationYear, Edition = @Edition
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

        public async Task<IActionResult> DeleteBook(int bookId)
        {
            try
            {
                const string sql = @"DELETE FROM Books
                    WHERE BookId = @BookId";

                using var connection = repository.GetConnection();
                await connection.ExecuteAsync(sql, new { BookId = bookId });

                return new OkResult();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
