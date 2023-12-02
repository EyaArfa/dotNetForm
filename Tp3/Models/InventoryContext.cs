

using Microsoft.EntityFrameworkCore;

namespace Tp3.Models
{
    public class InventoryContext:DbContext

    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { } 

        public DbSet<Concerts> Concerts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Concerts>();

        }
    
    }
}

