using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.DTOs;
using ToDoList.Models;

namespace ToDoList.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoItemsController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItem>>> GetAll()
    {
        var todos = await dbContext.TodoItems
            .AsNoTracking()
            .OrderByDescending(todo => todo.CreatedAtUtc)
            .ToListAsync();

        return Ok(todos);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TodoItem>> GetById(int id)
    {
        var todo = await dbContext.TodoItems
            .AsNoTracking()
            .FirstOrDefaultAsync(todo => todo.Id == id);

        return todo is null ? NotFound() : Ok(todo);
    }

    [HttpPost]
    public async Task<ActionResult<TodoItem>> Create(CreateTodoRequest request)
    {
        var todo = new TodoItem
        {
            Title = request.Title.Trim(),
            Description = request.Description?.Trim()
        };

        dbContext.TodoItems.Add(todo);
        await dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateTodoRequest request)
    {
        var todo = await dbContext.TodoItems.FindAsync(id);
        if (todo is null)
            return NotFound();

        todo.Title = request.Title.Trim();
        todo.Description = request.Description?.Trim();
        todo.IsCompleted = request.IsCompleted;
        todo.UpdatedAtUtc = DateTime.UtcNow;

        await dbContext.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var todo = await dbContext.TodoItems.FindAsync(id);
        if (todo is null)
            return NotFound();

        dbContext.TodoItems.Remove(todo);
        await dbContext.SaveChangesAsync();

        return NoContent();
    }
}
