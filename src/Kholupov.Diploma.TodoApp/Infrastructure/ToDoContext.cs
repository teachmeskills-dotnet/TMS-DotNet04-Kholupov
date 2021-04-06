using Kholupov.Diploma.TodoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Kholupov.Diploma.TodoApp.Infrastructure
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }

        public DbSet<TodoList> Todos { get; set; }
    }
}
