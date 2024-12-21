using Microsoft.AspNetCore.Mvc;

namespace BlogSystem.API.Endpoints.Posts.SearchOnContent;

public sealed record GetPostsBySearchOnContentRequest([FromQuery(Name ="searchTerm")] string SearchTerm);