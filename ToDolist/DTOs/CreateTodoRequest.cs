using System.ComponentModel.DataAnnotations;

namespace ToDoList.DTOs;

public class CreateTodoRequest
{
    [Required]
    [StringLength(120, MinimumLength = 1)]
    public string Title { get; set; } = string.Empty;

    [StringLength(1000)]
    public string? Description { get; set; }
}
