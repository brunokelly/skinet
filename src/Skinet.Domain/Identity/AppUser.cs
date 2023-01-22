using Microsoft.AspNetCore.Identity;

namespace Skinet.Domain.Identity
{
    public class AppUser : IdentityUser
    {
        protected AppUser()
        {

        }
        public string DisplayName { get; private set; }
        public Address Address { get; private set; }
    }
}
