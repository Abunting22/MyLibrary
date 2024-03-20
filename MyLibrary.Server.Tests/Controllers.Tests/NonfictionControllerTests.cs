using Microsoft.AspNetCore.Mvc;
using Moq;
using MyLibrary.Server.Controllers;
using MyLibrary.Server.Interfaces;
using MyLibrary.Server.Models;

namespace MyLibrary.Server.Tests.Controllers.Tests
{
    public class NonfictionControllerTests
    {
        [Fact]
        public async void GetAllNonfictionBooks_Returns_IActionResult_When_DependenciesSucceed()
        {
            var nonfictionServiceMock = new Mock<INonfictionService>();
            nonfictionServiceMock
                .Setup(x => x.GetAllNonfictionBooksRequest())
                .ReturnsAsync(It.IsAny<List<Book>>);

            var sut = new NonfictionController(nonfictionServiceMock.Object);

            var actual = await sut.GetAllNonfictionBooks();

            nonfictionServiceMock.VerifyAll();
        }

        [Fact]
        public async void AddNonfictionBook_Returns_IActionResult_When_DependenciesSucceed()
        {
            var nonfictionServiceMock = new Mock<INonfictionService>();
            nonfictionServiceMock
                .Setup(x => x.AddNonfictionBookRequest(It.IsAny<Book>()))
                .ReturnsAsync(It.IsAny<IActionResult>);
            var book = new Book();

            var sut = new NonfictionController(nonfictionServiceMock.Object);

            var actual = await sut.AddNonfictionBook(book);

            nonfictionServiceMock.VerifyAll();
        }

        [Fact]
        public async void UpdateNonfictionBook_Returns_IActionResult_When_DependenciesSucceed()
        {
            var nonfictionServiceMock = new Mock<INonfictionService>();
            nonfictionServiceMock
                .Setup(x => x.UpdateNonfictionBookRequest(It.IsAny<Book>()))
                .ReturnsAsync(It.IsAny<IActionResult>);
            var book = new Book();

            var sut = new NonfictionController(nonfictionServiceMock.Object);

            var actual = await sut.UpdateNonfictionBook(book);

            nonfictionServiceMock.VerifyAll();
        }

        [Fact]
        public async void DeleteNonfictionBook_Returns_IActionResult_When_DependenciesSucceed()
        {
            var nonfictionServiceMock = new Mock<INonfictionService>();
            nonfictionServiceMock
                .Setup(x => x.DeleteNonfictionBookRequest(It.IsAny<int>()))
                .ReturnsAsync(It.IsAny<IActionResult>);
            int id = 1;

            var sut = new NonfictionController(nonfictionServiceMock.Object);

            var actual = await sut.DeleteNonfictionBook(id);

            nonfictionServiceMock.VerifyAll();
        }
    }
}
