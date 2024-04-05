using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Moq;

using MyLibrary.Server.Interfaces;
using MyLibrary.Server.Models;
using MyLibrary.Server.Services;

namespace MyLibrary.Server.Tests.Services.Tests
{
    public class BooksServiceTests
    {
        [Fact]
        public async Task GetAllFictionBooksRequest_Returns_List_When_DependenciesSucceed()
        {
            var testList = new List<Book>() 
            {
                new() { BookId = 1, Category = 1, Title = "Test", Author = "FooBar", PublicationYear = 2024, Genre = "Test", Edition = "1st"},
                new() { BookId = 2, Category = 1, Title = "Test2", Author = "FooBar", PublicationYear = 2024, Genre = "Test", Edition = "1st"},
                new() { BookId = 3, Category = 2, Title = "Test3", Author = "FooBar", PublicationYear = 2024, Genre = "Test", Edition = "1st"},
            };
            var booksRepoMock = new Mock<IBooksRepository>();
            booksRepoMock
                .Setup(x => x.ReturnAllFictionBooks())
                .ReturnsAsync(It.IsAny<List<Book>>());
            var sut = new BooksService(booksRepoMock.Object);

            var actual = await sut.GetAllFictionBooksRequest();

            booksRepoMock.VerifyAll();
        }

        [Fact]
        public async Task GetAllFictionBooksRequest_Returns_Exception_When_ErrorThrown()
        {
            var booksRepoMock = new Mock<IBooksRepository>();
            booksRepoMock
                .Setup(x => x.ReturnAllFictionBooks())
                .ThrowsAsync(new Exception("Test exception thrown"));
            var sut = new BooksService(booksRepoMock.Object);

            Func<Task<List<Book>>> actual = sut.GetAllFictionBooksRequest;

            await Assert.ThrowsAsync<Exception>(actual);
        }

        [Fact]
        public async Task GetAllNonfictionBooksRequest_Returns_List_When_DependenciesSucceed()
        {
            var booksRepoMock = new Mock<IBooksRepository>();
            booksRepoMock
                .Setup(x => x.ReturnAllNonfictionBooks())
                .ReturnsAsync(It.IsAny<List<Book>>());
            var sut = new BooksService(booksRepoMock.Object);

            var actual = await sut.GetAllNonfictionBooksRequest();

            booksRepoMock.VerifyAll();
        }

        [Fact]
        public async Task GetAllNonfictionBooksRequest_Returns_Exception_When_ErrorThrown()
        {
            var booksRepoMock = new Mock<IBooksRepository>();
            booksRepoMock
                .Setup(x => x.ReturnAllNonfictionBooks())
                .ThrowsAsync(new Exception("Test exception thrown"));
            var sut = new BooksService(booksRepoMock.Object);

            Func<Task<List<Book>>> actual = sut.GetAllNonfictionBooksRequest;

            await Assert.ThrowsAsync<Exception>(actual);
        }

        [Fact]
        public async Task AddBookRequest_Returns_IActionResult_When_DependenciesSucceed()
        {
            var booksRepoMock = new Mock<IBooksRepository>();
            booksRepoMock
                .Setup(x => x.AddNewBook(It.IsAny<Book>()))
                .ReturnsAsync(It.IsAny<IActionResult>());
            var book = new Book();
            var sut = new BooksService(booksRepoMock.Object);

            var actual = await sut.AddBookRequest(book);

            booksRepoMock.VerifyAll();
        }

        [Fact]
        public async Task AddBookRequest_Returns_Exception_When_ErrorThrown()
        {
            var booksRepoMock = new Mock<IBooksRepository>();
            booksRepoMock
                .Setup(x => x.AddNewBook(It.IsAny<Book>()))
                .ThrowsAsync(new Exception("Test exception thrown"));
            var book = new Book();
            var sut = new BooksService(booksRepoMock.Object);

            Task<IActionResult> actual = sut.AddBookRequest(new Book());

            await Assert.ThrowsAsync<Exception>(() => actual);
        }

        [Fact]
        public async Task UpdateBookRequest_Returns_IActionResult_When_DependenciesSucceed()
        {
            var booksRepoMock = new Mock<IBooksRepository>();
            booksRepoMock
                .Setup(x => x.UpdateBook(It.IsAny<Book>()))
                .ReturnsAsync(It.IsAny<IActionResult>());
            var book = new Book();
            var sut = new BooksService(booksRepoMock.Object);

            var actual = await sut.UpdateBookRequest(book);

            booksRepoMock.VerifyAll();
        }

        [Fact]
        public async Task UpdateBookRequest_Returns_Exception_When_ErrorThrown()
        {
            var booksRepoMock = new Mock<IBooksRepository>();
            booksRepoMock
                .Setup(x => x.UpdateBook(It.IsAny<Book>()))
                .ThrowsAsync(new Exception("Test exception thrown"));
            var book = new Book();
            var sut = new BooksService(booksRepoMock.Object);

            Task<IActionResult> actual = sut.UpdateBookRequest(new Book());

            await Assert.ThrowsAsync<Exception>(() => actual);
        }

        [Fact]
        public async Task DeleteBookRequest_Returns_IActionResult_When_DependenciesSucceed()
        {
            var booksRepoMock = new Mock<IBooksRepository>();
            booksRepoMock
                .Setup(x => x.DeleteBook(It.IsAny<int>()))
                .ReturnsAsync(It.IsAny<IActionResult>());
            int id = 1;
            var sut = new BooksService(booksRepoMock.Object);

            var actual = await sut.DeleteBookRequest(id);

            booksRepoMock.VerifyAll();
        }

        [Fact]
        public async Task DeleteBookRequest_Returns_Exception_When_ErrorThrown()
        {
            var booksRepoMock = new Mock<IBooksRepository>();
            booksRepoMock
                .Setup(x => x.DeleteBook(It.IsAny<int>()))
                .ThrowsAsync(new Exception("Test exception thrown"));
            int id = 1;
            var sut = new BooksService(booksRepoMock.Object);

            Task<IActionResult> actual = sut.DeleteBookRequest(id);

            await Assert.ThrowsAsync<Exception>(() => actual);
        }
    }
}
