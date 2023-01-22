using Skinet.Application.Common;
using Skinet.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Application.Accounts.Models.Response
{
    public class AddressResponse : BaseResponse
    {
        public string Id { get; set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }

        public static implicit operator AddressResponse(Address address)
        {
            if (address is null) return null;

            return new AddressResponse
            {
                Id = address.Id,
                Name = address.Name,
                LastName = address.LastName,
                Street = address.Street,
                City = address.City,
                State = address.State,
                ZipCode = address.ZipCode,
            };
        }
    }
}
