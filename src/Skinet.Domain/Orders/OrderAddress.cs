using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Domain.Orders
{
    public class OrderAddress
    {
        public OrderAddress()
        {
            
        }
        public OrderAddress(string name, string lastName, string street, string city, string state, string zipCode)
        {
            Name = name;
            LastName = lastName;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
    }
}
