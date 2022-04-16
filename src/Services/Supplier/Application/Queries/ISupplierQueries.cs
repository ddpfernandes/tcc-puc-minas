namespace Supplier.Application.Queries
{
    public interface ISupplierQueries
    {
        Task<Domain.Supplier> GetSupplier(Guid id);
        Task<IEnumerable<Domain.Supplier>> GetAllSupplier();
    }
}