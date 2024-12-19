using System.Data;

namespace BlogSystem.Application.Data;

public interface ISqlConnectionFactory
{
    Task<IDbConnection> CreateConnectionAsync(CancellationToken cancellationToken = default);
}