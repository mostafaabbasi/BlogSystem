using Mediator;

namespace BlogSystem.Application.Posts.GetPostsBySearchOnContent;

public sealed record GetPostsBySearchOnContentQuery(string SearchTerm) : IQuery<IEnumerable<GetPostsBySearchOnContentResponse>>;