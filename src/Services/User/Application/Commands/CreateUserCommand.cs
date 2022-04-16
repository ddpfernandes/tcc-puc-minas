using MediatR;
using Seedwork.DomainObjects;
using User.Domain;

namespace User.Application.Commands
{
    public class CreateUserCommand : IRequest<CreateUserCommandResponse>
    {
        public CreateUserCommand(string name, string email, string password, UserType userType, Guid? personId)
        {
            Name = name;
            Email = email;
            Password = password;
            UserType = userType;
            PersonId = personId;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public UserType UserType { get; private set; }
        public Guid? PersonId { get; private set; }
    }

    public class CreateUserCommandResponse
    {
        public CreateUserCommandResponse(Guid id, string name, string email, string password, Guid? personId)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            PersonId = personId;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Guid? PersonId { get; private set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _uow;

        public CreateUserCommandHandler(IUserRepository userRepository, 
                                        IUnitOfWork uow)
        {
            _userRepository = userRepository;
            _uow = uow;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = new User.Domain.User(command.Name, command.Password, command.Email, command.UserType, command.PersonId);

            _userRepository.Add(user);
            await _uow.Commit();

            return new CreateUserCommandResponse(user.Id, user.Name, user.Email, user.Password, user.PersonId);
        }
    }
}