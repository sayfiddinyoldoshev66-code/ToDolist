using System.ComponentModel.DataAnnotations;

namespace ToDoList.DTOs;

public class UpdateTodoRequest
{
    [Required]
    [StringLength(120, MinimumLength = 1)]
    public string Title { get; set; } = string.Empty;

    [StringLength(1000)]
    public string? Description { get; set; }

    public bool IsCompleted { get; set; }
}
