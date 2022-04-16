using EasyNetQ;
using MediatR;
using User.Application.Commands;

namespace User.Application.IntegrationEvents
{
    public class IntegrationEventsHandler : BackgroundService
    {
        private readonly IBus _bus;
        private readonly IMediator _mediator;

        public IntegrationEventsHandler(IMediator mediator)
        {
            _mediator = mediator;
            _bus = RabbitHutch.CreateBus(Environment.GetEnvironmentVariable("CONNECTION_STRING_RABBITMQ")
                                          ?? throw new ArgumentException("CONNECTION_STRING_RABBITMQ não foi definida em User"));            
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _bus.PubSub.Subscribe<CustomerCreatedIntegrationEvent>("CustomerCreatedIntegrationEvent", async msg => 
            {
                await _mediator.Send(new CreateUserCommand(msg.Name, msg.Email, GeneratePassword(), Domain.UserType.Customer, msg.Id));
            });

            _bus.PubSub.Subscribe<SupplierCreatedIntegrationEvent>("SupplierCreatedIntegrationEvent", async msg => 
            {
                await _mediator.Send(new CreateUserCommand(msg.Name, msg.Email, GeneratePassword(), Domain.UserType.Supplier, msg.Id));
            });

            return Task.CompletedTask;
        }

        private string GeneratePassword()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max).ToString();
        }
    }
}