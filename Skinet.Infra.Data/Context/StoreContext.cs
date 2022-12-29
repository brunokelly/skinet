using Microsoft.EntityFrameworkCore;
using Skinet.Domain.Entities;

namespace Skinet.Infra.Data.Context
{
    public class StoreContext : DbContext
    {
        public StoreContext()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=skinet.db");
        }

        public DbSet<Product> Products { get; set; }

    }
}
