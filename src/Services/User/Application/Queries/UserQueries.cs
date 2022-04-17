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

        public async Task<UserViewModel> Auth(string email, string password)
        {
            var _ = (await _repository.GetAll())?.FirstOrDefault(_ => _.Email == email && _.Password == password);

            return new UserViewModel()
            {
                Login = _.Email,
                Name = _.Name,
                Password = _.Password,
                AccessType = Enum.GetName(typeof(UserType),_.UserType) ?? "Not defined"
            };
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUser()
        {
            var result = await _repository.GetAll();

            return result.Select(_ => new UserViewModel()
            {
                Login = _.Email,
                Name = _.Name,
                Password = _.Password,
                AccessType = Enum.GetName(typeof(UserType),_.UserType) ?? "Not defined"
            });
        }

        public async Task<UserViewModel> GetUser(Guid id)
        {
            var _ = await _repository.GetById(id);

            return new UserViewModel()
            {
                Login = _.Email,
                Name = _.Name,
                Password = _.Password,
                AccessType = Enum.GetName(typeof(UserType),_.UserType) ?? "Not defined"
            };
        }
    }
}