namespace User.Application.Queries
{
    public interface IUserQueries
    {
        Task<UserViewModel> GetUser(Guid id);
        Task<IEnumerable<UserViewModel>> GetAllUser();
        Task<UserViewModel> Auth(string email, string password);
    }
}