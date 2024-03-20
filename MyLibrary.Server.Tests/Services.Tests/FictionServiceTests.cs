using Microsoft.AspNetCore.Mvc;
using Moq;
using MyLibrary.Server.Interfaces;
using MyLibrary.Server.Models;
using MyLibrary.Server.Services;

namespace MyLibrary.Server.Tests.Services.Tests
{
    public class FictionServiceTests
    {
        [Fact]
        public async void GetAllFictionBooksRequest_Returns_ListBook_When_DependenciesSucceed()
        {
            var fictionRepositoryMock = new Mock<IFictionRepository>();
            fictionRepositoryMock
                .Setup(x => x.ReturnAllFictionBooks())
                .ReturnsAsync(It.IsAny<List<Book>>);

            var sut = new FictionService(fictionRepositoryMock.Object);

            var actual = await sut.GetAllFictionBooksRequest();

            fictionRepositoryMock.VerifyAll();
        }

        [Fact]
        public async void AddFictionBookRequest_Returns_IActionResult_When_DependenciesSucceed()
        {
            var fictionRepositoryMock = new Mock<IFictionRepository>();
            fictionRepositoryMock
                .Setup(x => x.AddNewFictionBook(It.IsAny<Book>()))
                .ReturnsAsync(It.IsAny<IActionResult>);

            var book = new Book();

            var sut = new FictionService(fictionRepositoryMock.Object);

            var actual = await sut.AddFictionBookRequest(book);

            fictionRepositoryMock.VerifyAll();
        }

        [Fact]
        public async void UpdateFictionBookRequest_Returns_IActionResult_When_DependenciesSucceed()
        {
            var fictionRepositoryMock = new Mock<IFictionRepository>();
            fictionRepositoryMock
                .Setup(x => x.UpdateFictionBook(It.IsAny<Book>()))
                .ReturnsAsync(It.IsAny<IActionResult>);

            var book = new Book();

            var sut = new FictionService(fictionRepositoryMock.Object);

            var actual = await sut.UpdateFictionBookRequest(book);

            fictionRepositoryMock.VerifyAll();
        }

        [Fact]
        public async void DeleteFictionBookRequest_Returns_IActionResult_When_DependenciesSucceed()
        {
            var fictionRepositoryMock = new Mock<IFictionRepository>();
            fictionRepositoryMock
                .Setup(x => x.DeleteFictionBook(It.IsAny<int>()))
                .ReturnsAsync(It.IsAny<IActionResult>);

            int bookId = 1;

            var sut = new FictionService(fictionRepositoryMock.Object);

            var actual = await sut.DeleteFictionBookRequest(bookId);

            fictionRepositoryMock.VerifyAll();
        }
    }
}
