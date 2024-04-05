using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;
using MyLibrary.Server.Interfaces;
using MyLibrary.Server.Models;
using MyLibrary.Server.Repositories;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using Dapper;

namespace MyLibrary.Server.Tests.Repositories.Tests
{
    public class BooksRepositoryTests
    {
        //[Fact]
        //public async void ReturnAllFictionBooks_Returns_ListBook_When_DependenciesSucceed()
        //{
        //    var booksTest = new List<Book> 
        //    {
        //        new Book {BookId = 100},
        //        new Book {BookId = 101},
        //        new Book {BookId = 102},
        //    };

            

        //    var sut = new BooksRepository();

        //    var actual = await sut.ReturnAllFictionBooks();

        //    booksRepositoryMock.VerifyAll();
        //}
    }
}
