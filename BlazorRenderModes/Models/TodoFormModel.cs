namespace BlazorRenderModes.Models;

public class TodoFormModel
{
    public List<TodoCheckboxState> TodoStates { get; set; } = new();
}

public class TodoCheckboxState
{
    public int Id { get; set; }
    public bool IsCompleted { get; set; }
}