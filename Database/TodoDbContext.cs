// Author: David Osička
// Licence: https://buymeacoffee.com/davidosicka
using Microsoft.EntityFrameworkCore;
using DavidOsicka30.CSharp.WebApiTemplate.Entities;
using DavidOsicka30.CSharp.WebApiTemplate.Interfaces.Database;

namespace DavidOsicka30.CSharp.WebApiTemplate.Database;

/// <summary>
/// Database context class
/// </summary>
/// <param name="options"></param>
public class TodoDbContext(DbContextOptions<TodoDbContext> options) : DbContext(options), ITodoDbContext
{
    /// <summary>
    /// Collection of all entities in the context
    /// </summary>
    public DbSet<TodoItem> TodoItems { get; init; } = null!;
}