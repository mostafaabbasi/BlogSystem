using Mediator;

namespace BlogSystem.Application.Posts.GetPostsByTagName;

public sealed record GetPostsByTagNameQuery(string TagName) : IQuery<List<GetPostsByTagNameResponse>>;