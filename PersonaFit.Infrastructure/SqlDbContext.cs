using Microsoft.Data.SqlClient;
using PersonaFit.Infrastructure;
using System.Data;

namespace PersonaFit.Infrastructure
{
    public class SqlDbContext : IDisposable
    {
        private readonly string _connectionString;
        private IDbConnection? _connection;

        public SqlDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                    _connection = new SqlConnection(_connectionString);
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();

                return _connection;
            }
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State != ConnectionState.Closed)
            {
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}

//public class SprocUserRepository : IUserRepository
//{
//    private readonly SqlDbContext _dbContext;

//    public async Task<User> GetByIdAsync(Guid id)
//    {
//        // _dbContext.Connection returns the generic IDbConnection
//        return await _dbContext.Connection.QueryFirstOrDefaultAsync<User>(
//            "sp_GetUserById",
//            new { UserId = id },
//            commandType: CommandType.StoredProcedure
//        );
//    }
//}