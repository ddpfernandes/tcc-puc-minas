using MediatR;

namespace Acesso.Application.Commands
{
    public class CreateUserCommand : IRequest<CreateUserCommandResponse>
    {
        public CreateUserCommand(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }

    public class CreateUserCommandResponse
    {
        public CreateUserCommandResponse(Guid id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();

            return new CreateUserCommandResponse(id, command.Name, command.Email, command.Password);            
        }
    }
}