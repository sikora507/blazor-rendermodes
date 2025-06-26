using BlazorRenderModes.Models;

namespace BlazorRenderModes.Services;

public class TodoService
{
    private static readonly List<TodoItem> _todos = new()
    {
        new() { Id = 1, Title = "Learn Blazor SSR", IsCompleted = false, CreatedAt = DateTime.Now.AddDays(-3) },
        new() { Id = 2, Title = "Build TODO app", IsCompleted = true, CreatedAt = DateTime.Now.AddDays(-2) },
        new() { Id = 3, Title = "Test different render modes", IsCompleted = false, CreatedAt = DateTime.Now.AddDays(-1) },
        new() { Id = 4, Title = "Deploy to production", IsCompleted = false, CreatedAt = DateTime.Now }
    };

    private static int _nextId = 5;

    public List<TodoItem> GetTodos() => _todos;

    public void AddTodo(string title)
    {
        if (!string.IsNullOrWhiteSpace(title))
        {
            var newTodo = new TodoItem
            {
                Id = _nextId++,
                Title = title.Trim(),
                IsCompleted = false,
                CreatedAt = DateTime.Now
            };
            _todos.Add(newTodo);
        }
    }

    public void ToggleTodo(int id)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if (todo != null)
        {
            todo.IsCompleted = !todo.IsCompleted;
        }
    }

    public void DeleteTodo(int id)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if (todo != null)
        {
            _todos.Remove(todo);
        }
    }
}