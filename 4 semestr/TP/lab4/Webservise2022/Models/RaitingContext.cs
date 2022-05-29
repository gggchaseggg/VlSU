using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Webservise2022.Models
{
    public class RaitingContext : DbContext
    {
        public RaitingContext(DbContextOptions<RaitingContext> options)
            : base(options)
        {
        }

        public DbSet<RaitingItem> RaitingItems { get; set; } = null!;
    }
}
