using User.Domain;

namespace User.Application.Queries
{
    public class UserQueries : IUserQueries
    {
        private readonly IUserRepository _repository;

        public UserQueries(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Domain.User>> GetAllUser()
        {
            return await _repository.GetAll();
        }

        public async Task<Domain.User> GetUser(Guid id)
        {
            return await _repository.GetById(id);
        }
    }
}