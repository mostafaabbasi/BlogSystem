using BlogSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddInfrastructure(builder.Configuration);

app.MapGet("/", () => "Hello World!");

app.Run();
