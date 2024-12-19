using System.Data;
using BlogSystem.Application.Data;
using Microsoft.Data.SqlClient;

namespace BlogSystem.Infrastructure.Persistence;

internal sealed class SqlConnectionFactory(string connectionString) : ISqlConnectionFactory
{
    public async Task<IDbConnection> CreateConnectionAsync(CancellationToken cancellationToken = default)
    {
        var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(cancellationToken);
        return connection;
    }
}