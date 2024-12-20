namespace BlogSystem.API.Endpoints.Posts.Update;

public sealed record UpdatePostRequest(
    string Title,
    string Content,
    string Summary,
    string Author,
    List<string> TagNames);