namespace BlogSystem.API.Endpoints.Posts.Create;

public sealed record CreatePostRequest(
    string Title,
    string Content,
    string Summary,
    string Author,
    List<string> TagNames);