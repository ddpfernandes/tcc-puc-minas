using Microsoft.EntityFrameworkCore;
using Supplier.Domain;

namespace Supplier.Infra.Data
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly Context _context;
        public SupplierRepository(Context context)
        {
            _context = context;
        }

        public void Add(Domain.Supplier aggregateRoot)
        {
            _context.Suppliers.Add(aggregateRoot);
        }

        public async Task Delete(Guid id)
        {
            var aggregateRoot = await GetById(id);

            if(aggregateRoot == null) throw new ArgumentException("Este cliente não existe!");

            _context.Suppliers.Remove(aggregateRoot);
        }

        public async Task<IEnumerable<Domain.Supplier>> GetAll()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Domain.Supplier> GetById(Guid id)
        {
            return await _context.Suppliers.FindAsync(id);
        }

        public void Update(Domain.Supplier aggregateRoot)
        {
            _context.Suppliers.Update(aggregateRoot);
        }
    }
}