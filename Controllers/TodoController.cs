// Author: David Osička
// Licence: https://buymeacoffee.com/davidosicka
using DavidOsicka30.CSharp.WebApiTemplate.Entities;
using DavidOsicka30.CSharp.WebApiTemplate.Interfaces.Controllers;
using DavidOsicka30.CSharp.WebApiTemplate.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DavidOsicka30.CSharp.WebApiTemplate.Controllers;


[Route("api/[controller]/[action]")]
[ApiController]
public class TodoController(ITodoRepository repository) : ControllerBase, ITodoController
{
    // GET: api/Todo/GetTodoItems
    [HttpGet]
    [SwaggerOperation(Summary = "Return all items")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<TodoItem>>> GetTodoItems()
    {
        try
        {
            return Ok(await repository.GetTodoItemsAsync());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }


    // GET: api/Todo/GetTodoItem?id=1
    [HttpGet]
    [SwaggerOperation(Summary = "Get item by index")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
    {
        try
        {
            return Ok(await repository.GetTodoItemAsync(id));
        }
        catch (InvalidOperationException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    

    // POST: api/Todo/PostTodoItem
    // To protect from over posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [SwaggerOperation(Summary = "Insert new item")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
    {
        try
        {
            var item = await repository.PostTodoItemAsync(todoItem);
            return (item);
        }
        catch (InvalidOperationException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }


    // PUT: api/Todo/PutTodoItem?id=1
    // To protect from over posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut]
    [SwaggerOperation(Summary = "Update item by index")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PutTodoItem(int id, TodoItem todoItem)
    {
        try
        {
            await repository.PutTodoItemAsync(id, todoItem);
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }


    // DELETE: api/Todo/DeleteTodoItem?id=1
    [HttpDelete]
    [SwaggerOperation(Summary = "Delete item by index")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteTodoItem(int id)
    {
        try
        {
            await repository.DeleteTodoItemAsync(id);
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}

