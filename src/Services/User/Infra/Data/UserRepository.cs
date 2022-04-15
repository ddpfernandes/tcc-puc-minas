using Microsoft.EntityFrameworkCore;
using User.Domain;

namespace User.Infra.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task Add(Domain.User aggregateRoot)
        {
            await _context.Users.AddAsync(aggregateRoot);
        }

        public async Task Delete(Guid id)
        {
            var aggregateRoot = await GetById(id);

            if(aggregateRoot == null) throw new ArgumentException("Este cliente não existe!");

            _context.Users.Remove(aggregateRoot);
        }

        public async Task<IEnumerable<Domain.User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Domain.User> GetById(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void Update(Domain.User aggregateRoot)
        {
            _context.Users.Update(aggregateRoot);
        }
    }
}