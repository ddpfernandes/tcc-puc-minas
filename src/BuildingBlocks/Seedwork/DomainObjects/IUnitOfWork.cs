namespace Seedwork.DomainObjects
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}