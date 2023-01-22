using Microsoft.AspNetCore.Identity;

namespace Skinet.Domain.Identity
{
    public class AppUser : IdentityUser
    {

        public AppUser(string displayName, Address address, string userName, string email) : base(userName)
        {
            DisplayName = displayName;
            base.Email = email;
            Address = address;
        }

        protected AppUser()
        {
        }


        public string DisplayName { get; private set; }
        public Address Address { get; private set; }
    }
}
