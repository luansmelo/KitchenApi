using System.Data;
using Npgsql;

namespace Kitchen.Infra.Context;

public class DbContext : IDbContext, IDisposable
{
    private readonly string _connectionString;
    private NpgsqlConnection? _connection;
    
    public DbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection Connection()
    {
        var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        return connection;
    }

    public void Dispose()
    {
        _connection?.Dispose();
    }
}
