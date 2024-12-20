using BlogSystem.API;
using BlogSystem.API.Extensions;
using BlogSystem.Application;
using BlogSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddCustomCors()
    .AddValidator()
    .AddEndpoints()
    .AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowOrigin");

app.UseSwagger();
app.UseSwaggerUI();

app.ApplyMigrations();

app.MapEndpoints();

app.Run();
