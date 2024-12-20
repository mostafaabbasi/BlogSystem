using BlogSystem.Application.Data;
using Dapper;
using MediatR;

namespace BlogSystem.Application.Posts.GetPostsBySearchOnContent;

public class GetPostsBySearchOnContentQueryHandler(ISqlConnectionFactory sqlConnectionFactory) : IRequestHandler<GetPostsBySearchOnContentQuery, IEnumerable<GetPostsBySearchOnContentResponse>>
{
    public async Task<IEnumerable<GetPostsBySearchOnContentResponse>> Handle(GetPostsBySearchOnContentQuery query, CancellationToken cancellationToken)
    {
        using var connection = await sqlConnectionFactory.CreateConnectionAsync(cancellationToken);

        const string sql = """
                           SELECT 
                               p.Id,
                               p.Title,
                               p.Summary,
                               p.Content,
                               p.Author,
                               p.CreatedAt,
                               t.Name as TagName
                           FROM Posts p
                           LEFT JOIN PostTags pt ON p.Id = pt.PostId
                           LEFT JOIN Tags t ON pt.TagId = t.Id
                           WHERE p.Content LIKE @SearchPattern
                           ORDER BY p.CreatedAt DESC
                           """;

        var postDictionary = new Dictionary<Guid, GetPostsBySearchOnContentResponse>();

        await connection.QueryAsync<GetPostsBySearchOnContentResponse, string, GetPostsBySearchOnContentResponse>(
            sql,
            (post, tagName) =>
            {
                if (!postDictionary.TryGetValue(post.Id, out var existingPost))
                {
                    existingPost = post;
                    existingPost.TagNames = new List<string>();
                    postDictionary.Add(post.Id, existingPost);
                }

                if (!string.IsNullOrEmpty(tagName))
                {
                    existingPost.TagNames.Add(tagName);
                }

                return existingPost;
            },
            new { SearchPattern = $"%{query.SearchTerm}%" },
            splitOn: "TagName");

        return postDictionary.Values;
    }
}