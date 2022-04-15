using Seedwork.DomainObjects;

namespace Supplier.Domain
{
    public class Supplier : IAggregateRoot
    {
        public Supplier(string name, string address, string phone)
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