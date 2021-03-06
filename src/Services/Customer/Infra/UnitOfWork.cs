using Seedwork.DomainObjects;
using EasyNetQ;

namespace Customer.Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;        

        public UnitOfWork(Context context)
        {
            _context = context;            
        }

        public async Task<bool> Commit()
        {
            var changeAmount = await _context.SaveChangesAsync();            

            return changeAmount > 0;
        }

        public void Dispose() => _context.Dispose();
    }
}