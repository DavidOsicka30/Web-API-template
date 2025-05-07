// Author: David Osička
// Licence: https://buymeacoffee.com/davidosicka
using DavidOsicka30.CSharp.WebApiTemplate.Entities;
using Microsoft.EntityFrameworkCore;

namespace DavidOsicka30.CSharp.WebApiTemplate.Interfaces.Database;


public interface ITodoDbContext
{
    DbSet<TodoItem> TodoItems { get; }
}