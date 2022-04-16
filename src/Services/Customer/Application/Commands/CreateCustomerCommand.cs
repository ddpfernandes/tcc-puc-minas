using MediatR;
using Seedwork.DomainObjects;
using Customer.Domain;

namespace Customer.Application.Commands
{
    public class CreateCustomerCommand : IRequest<CreateCustomerCommandResponse>
    {
        public CreateCustomerCommand(string name, string address, string phone)
        {
            Name = name;
            Address = address;
            Phone = phone;
        }

        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }     
    }

    public class CreateCustomerCommandResponse
    {
        public CreateCustomerCommandResponse(Guid id, string name, string address, string phone)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }   
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _uow;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, 
                                        IUnitOfWork uow)
        {
            _customerRepository = customerRepository;
            _uow = uow;
        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = new Customer.Domain.Customer(command.Name, command.Address, command.Phone);

            _customerRepository.Add(customer);
            await _uow.Commit();

            return new CreateCustomerCommandResponse(customer.Id, customer.Name, customer.Address, customer.Phone);            
        }
    }
}