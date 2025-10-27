using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Presistence.Coonfiguration
{
    public class CityPackagesConfiguration : IEntityTypeConfiguration<CityPackage>
    {
        public void Configure(EntityTypeBuilder<CityPackage> builder)
        {
            builder.ToTable("CityPackage");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.CityId);
            builder.Property(p => p.PackageId);
            builder.Property(p => p.CreatedById).HasMaxLength(45).IsRequired();
            builder.Property(p => p.ModifiedById).HasMaxLength(45);
            builder.Property(p => p.CreationDate).HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()").IsRequired();
            builder.Property(p => p.ModificationDate).HasColumnType("DATETIME");
            builder.Property(p => p.Active).HasDefaultValue(true);
            builder.Property(p => p.Deleted).HasDefaultValue(false);
            builder.HasQueryFilter(p => !p.Deleted);
        }
    }
}
