namespace Customer.Application.Queries
{
    public interface ICustomerQueries
    {
        Task<Domain.Customer> GetCustomer(Guid id);
        Task<IEnumerable<Domain.Customer>> GetAllCustomer();
    }
}