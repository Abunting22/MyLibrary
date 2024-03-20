using System.Data;

using Dapper;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Moq;
using MyLibrary.Server.Interfaces;
using MyLibrary.Server.Models;
using MyLibrary.Server.Repositories;

namespace MyLibrary.Server.Tests.Repositories.Tests
{
    public class FictionRepositoryTests
    {
        //private readonly IConfiguration configStub = new Mock<IConfiguration>().Object;

        //[Fact]
        //public async void ReturnAlLFictionBooks_Returns_TaskListBook_When_DependenciesSucceed()
        //{
        //    var bookList = new List<Book>();
        //    var testString = "TestConnection";

        //    var dbMock = new Mock<IDbConnection>();
        //    dbMock
        //        .Setup(c => c.QueryAsync<Book>(It.IsAny<string>(), null, null, null))
        //        .ReturnsAsync(bookList);

        //    var baseRespositoryMock = new Mock<IBaseRepository>();
        //    baseRespositoryMock
        //        .Setup(x => x.GetConnection())
        //        .Returns(() =>
        //        {
        //            var connection = new SqlConnection(testString);
        //            return connection;
        //        });

        //    var sut = new FictionRepository(baseRespositoryMock.Object);

        //    var actual = await sut.ReturnAllFictionBooks();

        //    Assert.Equal(bookList, actual);
        //}
    }
}
