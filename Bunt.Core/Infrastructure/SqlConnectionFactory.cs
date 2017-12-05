using System.Data;
using System.Data.SqlClient;

namespace Bunt.Core.Infrastructure
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }

    public class SqlConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection Create()
        {
            return new SqlConnection(_connectionString);
        }
    }
}