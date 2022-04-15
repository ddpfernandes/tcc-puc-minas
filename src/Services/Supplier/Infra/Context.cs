using Microsoft.EntityFrameworkCore;

namespace Supplier.Infra
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

        public DbSet<Domain.Supplier> Suppliers { get; private set; }
    }
}