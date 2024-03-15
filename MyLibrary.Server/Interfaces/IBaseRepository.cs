using System.Data;

namespace MyLibrary.Server.Interfaces
{
    public interface IBaseRepository
    {
        public IDbConnection GetConnection();
    }
}
