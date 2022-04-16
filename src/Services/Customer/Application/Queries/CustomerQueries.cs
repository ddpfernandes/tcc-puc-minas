using Customer.Domain;

namespace Customer.Application.Queries
{
    public class CustomerQueries : ICustomerQueries
    {
        private readonly ICustomerRepository _repository;

        public CustomerQueries(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Domain.Customer>> GetAllCustomer()
        {
            return await _repository.GetAll();
        }

        public async Task<Domain.Customer> GetCustomer(Guid id)
        {
            return await _repository.GetById(id);
        }
    }
}