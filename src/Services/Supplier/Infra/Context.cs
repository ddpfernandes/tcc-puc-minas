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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? throw new ArgumentException("CONNECTION_STRING não foi definida para Api Supplier");
            // var connectionString = @"Host=localhost;Port=5052;Database=postgres;UID=postgres;PWD=postgres";

            optionsBuilder.UseNpgsql(connectionString, 
                     sqlServerDbContextOptionsBuilder => sqlServerDbContextOptionsBuilder.EnableRetryOnFailure());    
            optionsBuilder.EnableSensitiveDataLogging();                
        }

        public DbSet<Domain.Supplier> Suppliers { get; private set; }
    }
}