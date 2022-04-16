using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace User.Infra.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<Domain.User>
    {
        public void Configure(EntityTypeBuilder<Domain.User> builder)
        {
            #region Colunas
            builder.Property(e => e.Id)
                .HasColumnType("uuid");

            builder.Property(e => e.Name)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.Password)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.Email)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.UserType)
                .HasColumnType("int(11)");

            builder.Property(e => e.PersonId)
                .HasColumnType("Id")
                .IsRequired(false);
            #endregion

            #region Primary Key
            builder.HasKey(e => e.Id)
                .HasName("PRIMARY");
            #endregion

            #region Table
            builder.ToTable("Users");
            #endregion
        }
    }
}