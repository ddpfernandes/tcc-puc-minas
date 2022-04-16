using Supplier.Domain;

namespace Supplier.Application.Queries
{
    public class SupplierQueries : ISupplierQueries
    {
        private readonly ISupplierRepository _repository;

        public SupplierQueries(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Domain.Supplier>> GetAllSupplier()
        {
            return await _repository.GetAll();
        }

        public async Task<Domain.Supplier> GetSupplier(Guid id)
        {
            return await _repository.GetById(id);
        }
    }
}