using Microsoft.AspNetCore.Mvc;
using Moq;
using MyLibrary.Server.Controllers;
using MyLibrary.Server.Interfaces;
using MyLibrary.Server.Models;

namespace MyLibrary.Server.Tests.Controllers.Tests
{
    public class FictionControllerTests
    {
        [Fact]
        public async void GetAllFictionBooks_Returns_IActionResult_When_DependenciesSucceed()
        {
            var fictionServiceMock = new Mock<IFictionService>();
            fictionServiceMock
                .Setup(x => x.GetAllFictionBooksRequest())
                .ReturnsAsync(It.IsAny<List<Book>>);

            var sut = new FictionController(fictionServiceMock.Object);

            var actual = await sut.GetAllFictionBooks();

            fictionServiceMock.VerifyAll();
        }

        [Fact]
        public async void AddFictionBook_Returns_IActionResult_When_DependenciesSucceed()
        {
            var fictionServiceMock = new Mock<IFictionService>();
            fictionServiceMock
                .Setup(x => x.AddFictionBookRequest(It.IsAny<Book>()))
                .ReturnsAsync(It.IsAny<IActionResult>);
            var book = new Book();

            var sut = new FictionController(fictionServiceMock.Object);

            var actual = await sut.AddFictionBook(book);

            fictionServiceMock.VerifyAll();
        }

        [Fact]
        public async void UpdateFictionBook_Returns_IActionResult_When_DependenciesSucceed()
        {
            var fictionServiceMock = new Mock<IFictionService>();
            fictionServiceMock
                .Setup(x => x.UpdateFictionBookRequest(It.IsAny<Book>()))
                .ReturnsAsync(It.IsAny<IActionResult>);
            var book = new Book();

            var sut = new FictionController(fictionServiceMock.Object);

            var actual = await sut.UpdateFictionBook(book);

            fictionServiceMock.VerifyAll();
        }

        [Fact]
        public async void DeleteFictionBook_Returns_IActionResult_When_DependenciesSucceed()
        {
            var fictionServiceMock = new Mock<IFictionService>();
            fictionServiceMock
                .Setup(x => x.DeleteFictionBookRequest(It.IsAny<int>()))
                .ReturnsAsync(It.IsAny<IActionResult>);
            int id = 1;

            var sut = new FictionController(fictionServiceMock.Object);

            var actual = await sut.DeleteFictionBook(id);

            fictionServiceMock.VerifyAll();
        }
    }
}
