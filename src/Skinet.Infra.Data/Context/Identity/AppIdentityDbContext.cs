using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Skinet.Domain.Identity;

namespace Skinet.Infra.Data.Context.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        private readonly IConfiguration _configuration;

        public AppIdentityDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = _configuration["ConnectionStrings:IdentityConnection"];
            optionsBuilder.UseSqlite(connString);
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
