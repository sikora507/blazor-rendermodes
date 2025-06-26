using Microsoft.AspNetCore.Mvc;
using BlazorRenderModes.Models;
using BlazorRenderModes.Services;

namespace BlazorRenderModes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly TodoService _todoService;

    public TodoController(TodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public ActionResult<List<TodoItem>> GetTodos()
    {
        return Ok(_todoService.GetTodos());
    }

    [HttpPost]
    public ActionResult AddTodo([FromBody] AddTodoRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            return BadRequest("Title is required");
        }

        _todoService.AddTodo(request.Title);
        return Ok();
    }

    [HttpPut("{id}/toggle")]
    public ActionResult ToggleTodo(int id)
    {
        _todoService.ToggleTodo(id);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteTodo(int id)
    {
        _todoService.DeleteTodo(id);
        return Ok();
    }
}

public class AddTodoRequest
{
    public string Title { get; set; } = string.Empty;
}