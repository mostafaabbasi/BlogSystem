using MediatR;

namespace BlogSystem.Application.Tags.GetTags;

public sealed record GetTagsQuery() : IRequest<IEnumerable<GetTagsResponse>>;