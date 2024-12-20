using Microsoft.AspNetCore.Mvc;

namespace BlogSystem.API.Endpoints.Posts.GetByTagName;

public sealed record GetPostsByTagNameRequest([FromQuery(Name ="tagName")] string TagName);