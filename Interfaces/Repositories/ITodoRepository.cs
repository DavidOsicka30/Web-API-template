// Author: David Osička
// Licence: https://buymeacoffee.com/davidosicka
using DavidOsicka30.CSharp.WebApiTemplate.Entities;

namespace DavidOsicka30.CSharp.WebApiTemplate.Interfaces.Repositories;

public interface ITodoRepository
{
    Task<IEnumerable<TodoItem>> GetTodoItemsAsync();
    Task<TodoItem> GetTodoItemAsync(int id);
    Task<TodoItem> PostTodoItemAsync(TodoItem todoItem);
    Task PutTodoItemAsync(int id, TodoItem todoItem);
    Task DeleteTodoItemAsync(int id);
}