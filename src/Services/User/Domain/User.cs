using Seedwork.DomainObjects;

namespace User.Domain
{
    public class User : IAggregateRoot
    {
        public User(string name, string email, string password, UserType userType, Guid? personId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
            UserType = userType;
            PersonId = personId;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public UserType UserType { get; private set; }
        public Guid? PersonId { get; private set; }

        public void ChangeData(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public void ChangePassword(string password, string passwordConfirmation)
        {
            if (password != passwordConfirmation)
            {
                throw new ArgumentException("As senhas não coincidem!");
            }

            if (Password == password || Password == passwordConfirmation)
            {
                throw new ArgumentException("Não é possível repetir a nova senha com a antiga!");
            }

            Password = password;
        }
    }
}