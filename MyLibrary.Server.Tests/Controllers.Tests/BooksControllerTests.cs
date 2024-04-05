using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Moq;

using MyLibrary.Server.Controllers;
using MyLibrary.Server.Interfaces;
using MyLibrary.Server.Models;
using MyLibrary.Server.Services;

namespace MyLibrary.Server.Tests.Controllers.Tests
{
    public class BooksControllerTests
    {
        [Fact]
        public async Task GetAllFictionBooks_Returns_IActionResult_When_DependenciesSucceed()
        {
            var booksServiceMock = new Mock<IBooksService>();
            booksServiceMock
                .Setup(x => x.GetAllFictionBooksRequest())
                .ReturnsAsync(It.IsAny<List<Book>>());
            var sut = new BooksController(booksServiceMock.Object);

            var actual = await sut.GetAllFictionBooks();

            booksServiceMock.VerifyAll();
        }

        [Fact]
        public async Task GetAllNonfictionBooks_Returns_IActionResult_When_DependenciesSucceed()
        {
            var booksServiceMock = new Mock<IBooksService>();
            booksServiceMock
                .Setup(x => x.GetAllNonfictionBooksRequest())
                .ReturnsAsync(It.IsAny<List<Book>>());
            var sut = new BooksController(booksServiceMock.Object);

            var actual = await sut.GetAllNonfictionBooks();

            booksServiceMock.VerifyAll();
        }

        [Fact]
        public async Task AddBook_Returns_IActionResult_When_DependenciesSucceed()
        {
            var booksServiceMock = new Mock<IBooksService>();
            booksServiceMock
                .Setup(x => x.AddBookRequest(It.IsAny<Book>()))
                .ReturnsAsync(It.IsAny<IActionResult>());
            var book = new Book();
            var sut = new BooksController(booksServiceMock.Object);

            var actual = await sut.AddBook(book);

            booksServiceMock.VerifyAll();
        }

        [Fact]
        public async Task UpdateBook_Returns_IActionResult_When_DependenciesSucceed()
        {
            var booksServiceMock = new Mock<IBooksService>();
            booksServiceMock
                .Setup(x => x.UpdateBookRequest(It.IsAny<Book>()))
                .ReturnsAsync(It.IsAny<IActionResult>());
            var book = new Book();
            var sut = new BooksController(booksServiceMock.Object);

            var actual = await sut.UpdateBook(book);

            booksServiceMock.VerifyAll();
        }

        [Fact]
        public async Task DeleteBook_Returns_IActionResult_When_DependenciesSucceed()
        {
            var booksServiceMock = new Mock<IBooksService>();
            booksServiceMock
                .Setup(x => x.DeleteBookRequest(It.IsAny<int>()))
                .ReturnsAsync(It.IsAny<IActionResult>());
            int id = 1;
            var sut = new BooksController(booksServiceMock.Object);

            var actual = await sut.DeleteBook(id);

            booksServiceMock.VerifyAll();
        }
    }
}
