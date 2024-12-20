using BlogSystem.Application.Data;
using Dapper;
using MediatR;

namespace BlogSystem.Application.Tags.GetTags;

internal sealed class GetTagsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    : IRequestHandler<GetTagsQuery, IEnumerable<GetTagsResponse>>
{
    public async Task<IEnumerable<GetTagsResponse>> Handle(GetTagsQuery query, CancellationToken cancellationToken)
    {
        using var connection = await sqlConnectionFactory.CreateConnectionAsync(cancellationToken);

        const string sql = """
                           SELECT t.Name FROM Tags t
                           """;
        var tagNames = await connection.QueryAsync<GetTagsResponse>(sql);

        return tagNames;
    }
}