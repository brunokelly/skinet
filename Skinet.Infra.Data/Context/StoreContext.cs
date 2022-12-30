using Microsoft.EntityFrameworkCore;
using Skinet.Domain.Product;

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
        public DbSet<ProductBrand> ProductBrands { get; set; }  
        public DbSet<ProductType>  ProductTypes { get; set; }
    }
}
