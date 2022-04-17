using MediatR;
using Seedwork.DomainObjects;
using Customer.Domain;
using EasyNetQ;
using Seedwork.IntegrationsEventsMessages;

namespace Customer.Application.Commands
{
    public class CreateCustomerCommand : IRequest<CreateCustomerCommandResponse>
    {
        public CreateCustomerCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
    }

    public class CreateCustomerCommandResponse
    {
        public CreateCustomerCommandResponse(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
    {
        private readonly ILogger<CreateCustomerCommandHandler> _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _uow;
        public CreateCustomerCommandHandler(ICustomerRepository customerRepository,
                                            IUnitOfWork uow,
                                            ILogger<CreateCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository;
            _uow = uow;
            _logger = logger;
        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = new Customer.Domain.Customer(command.Name, command.Email);

            _customerRepository.Add(customer);
            await _uow.Commit();

            using (var bus = RabbitHutch.CreateBus(Environment.GetEnvironmentVariable("CONNECTION_STRING_RABBITMQ") ?? throw new ArgumentException("CONNECTION_STRING_RABBITMQ não foi definida em Customer")))
            {
                _logger.LogInformation("----- enviando evento de integracao -----");
                bus.PubSub.Publish(new CustomerCreatedIntegrationEvent(customer.Id, customer.Name, customer.Email));
                _logger.LogInformation("----- evento enviado -----");
            }

            return new CreateCustomerCommandResponse(customer.Id, customer.Name, customer.Email);
        }
    }
}