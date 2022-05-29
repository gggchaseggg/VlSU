using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Models.Raitings;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<Raitings> TodoItems { get; set; } = null!;
    }
}