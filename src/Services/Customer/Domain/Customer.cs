using Seedwork.DomainObjects;

namespace Customer.Domain
{
    public class Customer : IAggregateRoot
    {
        public Customer(string name, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public void ChangeData(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}