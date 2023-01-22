using Microsoft.AspNetCore.Identity;

namespace Skinet.Domain.Identity
{
    public class AppUser : IdentityUser
    {

        protected AppUser()
        {
        }

        public AppUser(string displayName, string userName, string email) : base(userName)
        {
            DisplayName = displayName;
            base.Email = email;
        }

        public AppUser(string displayName, Address address, string userName, string email) : base(userName)
        {
            DisplayName = displayName;
            base.Email = email;
            Address = address;
        }

        public string DisplayName { get; private set; }
        public Address Address { get; private set; }

        public void AddUserAddress(Address address)
        {
            if (address is null) return;

            this.Address = address;
        }
    }
}
