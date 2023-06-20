using Microsoft.EntityFrameworkCore;
using TodoDemo.Api.Models;

namespace TodoDemo.Api.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Todo> TodoItems { get; set; }
    }
}
