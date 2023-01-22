using Microsoft.AspNetCore.Identity;
using Skinet.Domain.Identity;

namespace Skinet.Infra.Data.Context.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
           if (!userManager.Users.Any())
            {
                var address = new Address("Bob", "Bobbity", "10 The street", "New York", "NY", "90210");

                var user = new AppUser("Bob", address, "bob@test.com", "bob@test.com");

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}
