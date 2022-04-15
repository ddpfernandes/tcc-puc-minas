using Seedwork.DomainObjects;

namespace Customer.Domain
{
    public class Customer : IAggregateRoot
    {
        public Customer(string name, string address, string phone)
        {
            Id = Guid.NewGuid();
            Name = name;
            Address = address;
            Phone = phone;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }

        public void ChangeData(string name, string address, string phone)
        {
            Name = name;
            Address = address;
            Phone = phone;
        }
    }
}