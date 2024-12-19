using BlogSystem.Application.Data;
using Dapper;
using Mediator;

namespace BlogSystem.Application.Posts.GetPostsByTagName;

internal sealed class GetPostsByTagNameHandler(ISqlConnectionFactory sqlConnectionFactory) : IQueryHandler<GetPostsByTagNameQuery, List<GetPostsByTagNameResponse>>
{
    public async ValueTask<List<GetPostsByTagNameResponse>> Handle(GetPostsByTagNameQuery query, CancellationToken cancellationToken)
    {
        return await PrivateHandle(query, cancellationToken);
    }

    private async Task<List<GetPostsByTagNameResponse>> PrivateHandle(GetPostsByTagNameQuery query, CancellationToken cancellationToken)
    {
        using var connection = await sqlConnectionFactory.CreateConnectionAsync(cancellationToken);

        const string sql = """
        SELECT 
                p.Id, 
                p.Title, 
                p.Content, 
                p.Summary, 
                p.Author, 
                p.CreatedAt,
                t.Name AS TagName
            FROM Posts p
            INNER JOIN PostTags pt ON p.Id = pt.PostId
            INNER JOIN Tags t ON pt.TagId = t.Id
            WHERE t.Name = @TagName
        """;

        var postDictionary = new Dictionary<Guid, GetPostsByTagNameResponse>();

        IEnumerable<GetPostsByTagNameResponse> posts = await connection.QueryAsync<GetPostsByTagNameResponse, string, GetPostsByTagNameResponse>(
            sql,
            (post, tagName) =>
            {
                if (!postDictionary.TryGetValue(post.Id, out var postEntry))
                {
                    postEntry = post;
                    postEntry.TagNames = new List<string>();
                    postDictionary.Add(postEntry.Id, postEntry);
                }
                postEntry.TagNames.Add(tagName);
                return postEntry;
            },
            new { TagName = query.TagName },
            splitOn: "TagName"
        );

        return postDictionary.Values.ToList();
    }
}