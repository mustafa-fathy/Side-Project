using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Presistence.Coonfiguration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.ContactPerson)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.PhoneNumber)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.Address)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.CreatedById)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.ModifiedById)
                .HasMaxLength(50);

            builder.Property(p => p.CreationDate)
                .HasColumnType("DateTime")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            builder.Property(p => p.ModificationDate)
                .HasColumnType("DateTime");

            builder.Property(p => p.Active)
                .HasDefaultValue(true);

            builder.Property(p => p.Deleted)
                .HasDefaultValue(false);

            builder.HasQueryFilter(f => !f.Deleted);
        }
    }
}
