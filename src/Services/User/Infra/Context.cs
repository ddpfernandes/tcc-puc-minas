using Microsoft.EntityFrameworkCore;

namespace User.Infra
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }

        public DbSet<Domain.User> Users { get; private set; }
    }
}