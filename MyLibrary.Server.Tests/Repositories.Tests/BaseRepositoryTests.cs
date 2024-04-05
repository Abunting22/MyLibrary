using System.Runtime;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Moq;

using MyLibrary.Server.Interfaces;
using MyLibrary.Server.Repositories;
using MyLibrary.Server.Services;

namespace MyLibrary.Server.Tests.Repositories.Tests
{
    public class BaseRepositoryTests
    {
        [Fact]
        public void GetConnection_Returns_SqlConnection_When_DependenciesSucceed()
        {
            var configSecMock = new Mock<IConfigurationSection>();
            configSecMock
                 .SetupGet(m => m[It.Is<string>(s => s == "TestConnection")])
                 .Returns("TestConnection");

            var configMock = new Mock<IConfiguration>();
            configMock
                .Setup(x => x.GetSection("ConnectionStrings"))
                .Returns(configSecMock.Object);

            var sut = new BaseRepository(configMock.Object);

            var actual = sut.GetConnection();

            Assert.NotNull(actual);
            Assert.IsType<SqlConnection>(actual);
        }
    }
}