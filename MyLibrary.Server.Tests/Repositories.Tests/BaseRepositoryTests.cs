using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Moq;
using MyLibrary.Server.Repositories;

namespace MyLibrary.Server.Tests.Repositories.Tests
{
    public class BaseRepositoryTests
    {
        [Fact]
        public void Connect_Returns_SqlConnection_When_DependenciesSucceed()
        {
            var configSecMock = new Mock<IConfigurationSection>();
            configSecMock
                 .SetupGet(m => m[It.Is<string>(s => s == "TestConnection")])
                 .Returns("TestConnection");

            var configurationMock = new Mock<IConfiguration>();
            configurationMock
                .Setup(x => x.GetSection("ConnectionStrings"))
                .Returns(configSecMock.Object);

            var sut = new BaseRepository(configurationMock.Object);

            var actual = sut.GetConnection();

            Assert.NotNull(actual);
            Assert.IsType<SqlConnection>(actual);
        }
    }
}