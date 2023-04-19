using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC_WEBAPI_CORE.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<ToDoItem> TodoItems { get; set; } = null!;
    }
}
