using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Presistence.Coonfiguration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasMaxLength(45).IsRequired();
            builder.Property(p => p.Active).HasDefaultValue(true);
            builder.Property(p => p.ModifiedById).HasMaxLength(45);
            builder.Property(p => p.Code).HasMaxLength(45).IsRequired();
            builder.Property(p => p.NameAr).HasMaxLength(45).IsRequired();
            builder.Property(p => p.NameEn).HasMaxLength(45).IsRequired();
            builder.Property(p => p.CreatedById).HasMaxLength(45).IsRequired();
            builder.Property(p => p.CreationDate).HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()").IsRequired();
            builder.Property(p => p.Deleted).HasDefaultValue(false);
            builder.Property(p => p.ModificationDate).HasColumnType("DATETIME");
            builder.HasQueryFilter(p => !p.Deleted);
        }
    }
}
