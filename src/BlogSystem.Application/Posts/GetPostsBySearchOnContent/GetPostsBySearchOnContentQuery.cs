using MediatR;

namespace BlogSystem.Application.Posts.GetPostsBySearchOnContent;

public sealed record GetPostsBySearchOnContentQuery(string SearchTerm) : IRequest<IEnumerable<GetPostsBySearchOnContentResponse>>;