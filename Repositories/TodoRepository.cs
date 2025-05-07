// Author: David Osička
// Licence: https://buymeacoffee.com/davidosicka
using DavidOsicka30.CSharp.WebApiTemplate.Database;
using DavidOsicka30.CSharp.WebApiTemplate.Entities;
using DavidOsicka30.CSharp.WebApiTemplate.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DavidOsicka30.CSharp.WebApiTemplate.Repositories;

public class TodoRepository(TodoDbContext context) : ITodoRepository
{
    public async Task<IEnumerable<TodoItem>> GetTodoItemsAsync()
    {
        return await context.TodoItems.ToListAsync();
    }
    
    public async Task<TodoItem> GetTodoItemAsync(int id)
    {
        var todoItem = await context.TodoItems.FindAsync(id);

        if (todoItem == null)
            throw new InvalidOperationException();

        return todoItem;
    }
    
    public async Task PutTodoItemAsync(int id, TodoItem todoItem)
    {
        if (id != todoItem.Id)
            throw new InvalidOperationException();

        context.Entry(todoItem).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TodoItemExists(id))
                throw new DbUpdateConcurrencyException();
            throw;
        }
    }
    
    
    public async Task<TodoItem> PostTodoItemAsync(TodoItem todoItem)
    {
        context.TodoItems.Add(todoItem);
        await context.SaveChangesAsync();

        return todoItem;
    }
    
    
    
    
    public async Task DeleteTodoItemAsync(int id)
    {
        var todoItem = await context.TodoItems.FindAsync(id);
        if (todoItem == null)
            throw new InvalidOperationException();

        context.TodoItems.Remove(todoItem);
        await context.SaveChangesAsync();
    }
    
    
    
    private bool TodoItemExists(int id)
    {
        return context.TodoItems.Any(e => e.Id == id);
    }
    
}