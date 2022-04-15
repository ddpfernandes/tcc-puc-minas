using Seedwork.DomainObjects;

namespace User.Domain
{
    public class User : IAggregateRoot
    {
        public User(string name, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Password = password;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Password { get; private set; }

        public void ChangeName(string name)
        {
            Name = name;
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