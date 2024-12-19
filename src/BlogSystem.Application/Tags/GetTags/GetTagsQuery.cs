using Mediator;

namespace BlogSystem.Application.Tags.GetTags;

public sealed record GetTagsQuery() : IQuery<IEnumerable<GetTagsResponse>>;