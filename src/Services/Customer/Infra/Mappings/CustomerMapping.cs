using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer.Infra.Data.Mappings
{
    public class CustomerMapping : IEntityTypeConfiguration<Domain.Customer>
    {
        public void Configure(EntityTypeBuilder<Domain.Customer> builder)
        {
            #region Colunas
            builder.Property(e => e.Id)
                .HasColumnType("uuid");

            builder.Property(e => e.Address)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.Name)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.Phone)
                .HasColumnType("varchar(200)");
            #endregion

            #region Primary Key
            builder.HasKey(e => e.Id)
                .HasName("PRIMARY");
            #endregion

            #region Table
            builder.ToTable("Customers");
            #endregion
        }
    }
}