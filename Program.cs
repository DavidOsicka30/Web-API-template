// Author: David Osička
// Licence: https://buymeacoffee.com/davidosicka
using Microsoft.EntityFrameworkCore;
using DavidOsicka30.CSharp.WebApiTemplate.Database;
using DavidOsicka30.CSharp.WebApiTemplate.Extensions;
using DavidOsicka30.CSharp.WebApiTemplate.Interfaces.Repositories;
using DavidOsicka30.CSharp.WebApiTemplate.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddDbContext<TodoDbContext>(opt =>
    opt.UseInMemoryDatabase("TodoDB"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

app.UseSwaggerForDevelopment();
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Logger.LogInformation("Starting service hosting provider...");
await app.RunAsync();