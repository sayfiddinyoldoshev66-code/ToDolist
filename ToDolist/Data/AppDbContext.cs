using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.HasKey(todo => todo.Id);
            entity.Property(todo => todo.Title).IsRequired().HasMaxLength(120);
            entity.Property(todo => todo.Description).HasMaxLength(1000);
            entity.HasIndex(todo => todo.IsCompleted);
        });
    }
}
