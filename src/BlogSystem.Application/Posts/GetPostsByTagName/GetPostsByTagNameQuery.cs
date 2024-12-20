using MediatR;

namespace BlogSystem.Application.Posts.GetPostsByTagName;

public sealed record GetPostsByTagNameQuery(string TagName) : IRequest<List<GetPostsByTagNameResponse>>;