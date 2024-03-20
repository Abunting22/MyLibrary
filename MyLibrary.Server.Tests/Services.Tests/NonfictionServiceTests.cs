using Microsoft.AspNetCore.Mvc;
using Moq;
using MyLibrary.Server.Interfaces;
using MyLibrary.Server.Models;
using MyLibrary.Server.Services;

namespace MyLibrary.Server.Tests.Services.Tests
{
    public class NonfictionServiceTests
    {
        [Fact]
        public async void GetAllNonfictionBooksRequest_Returns_ListBook_When_DependenciesSucceed()
        {
            var nonfictionRepositoryMock = new Mock<INonfictionRepository>();
            nonfictionRepositoryMock
                .Setup(x => x.ReturnAllNonfictionBooks())
                .ReturnsAsync(It.IsAny<List<Book>>);

            var sut = new NonfictionService(nonfictionRepositoryMock.Object);

            var actual = await sut.GetAllNonfictionBooksRequest();

            nonfictionRepositoryMock.VerifyAll();
        }

        [Fact]
        public async void AddNonfictionBookRequest_Returns_IActionResult_When_DependenciesSucceed()
        {
            var nonfictionRepositoryMock = new Mock<INonfictionRepository>();
            nonfictionRepositoryMock
                .Setup(x => x.AddNewNonfictionBook(It.IsAny<Book>()))
                .ReturnsAsync(It.IsAny<IActionResult>);

            var book = new Book();

            var sut = new NonfictionService(nonfictionRepositoryMock.Object);

            var actual = await sut.AddNonfictionBookRequest(book);

            nonfictionRepositoryMock.VerifyAll();
        }

        [Fact]
        public async void UpdateNonfictionBookRequest_Returns_IActionResult_When_DependenciesSucceed()
        {
            var nonfictionRepositoryMock = new Mock<INonfictionRepository>();
            nonfictionRepositoryMock
                .Setup(x => x.UpdateNonfictionBook(It.IsAny<Book>()))
                .ReturnsAsync(It.IsAny<IActionResult>);

            var book = new Book();

            var sut = new NonfictionService(nonfictionRepositoryMock.Object);

            var actual = await sut.UpdateNonfictionBookRequest(book);

            nonfictionRepositoryMock.VerifyAll();
        }

        [Fact]
        public async void DeleteNonfictionBookRequest_Returns_IActionResult_When_DependenciesSucceed()
        {
            var nonfictionRepositoryMock = new Mock<INonfictionRepository>();
            nonfictionRepositoryMock
                .Setup(x => x.DeleteNonfictionBook(It.IsAny<int>()))
                .ReturnsAsync(It.IsAny<IActionResult>);

            int bookId = 1;

            var sut = new NonfictionService(nonfictionRepositoryMock.Object);

            var actual = await sut.DeleteNonfictionBookRequest(bookId);

            nonfictionRepositoryMock.VerifyAll();
        }
    }
}
