using EasyNetQ;
using MediatR;
using User.Application.Commands;
using Seedwork.IntegrationsEventsMessages;

namespace User.Application.IntegrationEvents
{
    public class IntegrationEventsHandler : BackgroundService
    {        
        private IBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public IntegrationEventsHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {            
            await TryConnect();

            _bus.PubSub.Subscribe<CustomerCreatedIntegrationEvent>("CustomerCreated_User", async msg => 
            {
                using var serviceScope = _serviceProvider.GetService<IServiceScopeFactory>().CreateScope();
                var _mediator = serviceScope.ServiceProvider.GetRequiredService<IMediator>();
                await _mediator.Send(new CreateUserCommand(msg.Name, msg.Email, GeneratePassword(), Domain.UserType.Customer, msg.Id));
            });

            _bus.PubSub.Subscribe<SupplierCreatedIntegrationEvent>("SupplierCreated_User", async msg => 
            {
                using var serviceScope = _serviceProvider.GetService<IServiceScopeFactory>().CreateScope();
                var _mediator = serviceScope.ServiceProvider.GetRequiredService<IMediator>();
                await _mediator.Send(new CreateUserCommand(msg.Name, msg.Email, GeneratePassword(), Domain.UserType.Supplier, msg.Id));
            });
        }

        private async Task TryConnect()
        {         
            await Task.Delay(TimeSpan.FromSeconds(15));
            _bus = RabbitHutch.CreateBus(Environment.GetEnvironmentVariable("CONNECTION_STRING_RABBITMQ") ?? throw new ArgumentException("CONNECTION_STRING_RABBITMQ não foi definida em User"));
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