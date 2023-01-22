namespace Skinet.Domain.Identity
{
    public class Address
    {
        protected Address()
        {

        }
        public Address(string name, string lastName, 
            string street, string city, string state, string zipCode)
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
        public AppUser AppUser { get; private set; }

    }
}
