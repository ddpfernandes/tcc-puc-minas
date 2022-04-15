using Customer.Domain;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infra.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context _context;
        public CustomerRepository(Context context)
        {
            _context = context;
        }

        public async Task Add(Domain.Customer aggregateRoot)
        {
            await _context.Customers.AddAsync(aggregateRoot);
        }

        public async Task Delete(Guid id)
        {
            var aggregateRoot = await GetById(id);

            if(aggregateRoot == null) throw new ArgumentException("Este cliente não existe!");

            _context.Customers.Remove(aggregateRoot);
        }

        public async Task<IEnumerable<Domain.Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Domain.Customer> GetById(Guid id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public void Update(Domain.Customer aggregateRoot)
        {
            _context.Customers.Update(aggregateRoot);
        }
    }
}