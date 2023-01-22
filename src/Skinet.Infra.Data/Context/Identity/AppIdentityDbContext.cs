using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Skinet.Domain.Identity;

namespace Skinet.Infra.Data.Context.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=identity.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUser>()
                .HasOne<Address>(x => x.Address)
                .WithOne(x => x.AppUser)
                .HasForeignKey<Address>(x => x.Id).HasConstraintName("AppUserId");

            base.OnModelCreating(builder);
        }
    }
}
