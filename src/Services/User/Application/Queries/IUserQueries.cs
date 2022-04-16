namespace User.Application.Queries
{
    public interface IUserQueries
    {
        Task<Domain.User> GetUser(Guid id);
        Task<IEnumerable<Domain.User>> GetAllUser();
    }
}