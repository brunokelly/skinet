using Skinet.Application.Accounts.Models.Response;

namespace Skinet.Application.Accounts.Models.Request
{
    public class AddressRequest 
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Street { get;  set; }
        public string City { get;  set; }
        public string State { get;  set; }
        public string ZipCode { get;  set; }
    }
}
