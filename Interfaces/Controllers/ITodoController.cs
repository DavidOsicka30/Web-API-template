// Author: David Osička
// Licence: https://buymeacoffee.com/davidosicka
using Microsoft.AspNetCore.Mvc;
using DavidOsicka30.CSharp.WebApiTemplate.Entities;

namespace DavidOsicka30.CSharp.WebApiTemplate.Interfaces.Controllers;


/// <summary>
/// Interface for basic CRUD operations
/// </summary>
public interface ITodoController
{
    Task<ActionResult<List<TodoItem>>> GetTodoItems();
    Task<ActionResult<TodoItem>> GetTodoItem(int id);
    Task<IActionResult> PutTodoItem(int id, TodoItem todoItem);
    Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem);
    Task<IActionResult> DeleteTodoItem(int id);
}