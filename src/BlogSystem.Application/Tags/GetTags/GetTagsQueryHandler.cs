using BlogSystem.Application.Data;
using Dapper;
using Mediator;

namespace BlogSystem.Application.Tags.GetTags;

internal sealed class GetTagsQueryHandler(ISqlConnectionFactory sqlConnectionFactory) : IQueryHandler<GetTagsQuery, IEnumerable<GetTagsResponse>>
{
    public async ValueTask<IEnumerable<GetTagsResponse>> Handle(GetTagsQuery query, CancellationToken cancellationToken)
    {
        return await PrivateHandle(query,cancellationToken);
    }

    private async ValueTask<IEnumerable<GetTagsResponse>> PrivateHandle(GetTagsQuery query, CancellationToken cancellationToken)
    {
        using var connection = await sqlConnectionFactory.CreateConnectionAsync(cancellationToken);

        const string sql = """
        SELECT t.Name FROM Tags t
        """;
        var tagNames = await connection.QueryAsync<GetTagsResponse>(sql);

        return tagNames;
    }
}