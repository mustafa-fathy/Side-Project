using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Presistence.Coonfiguration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id)
                .HasMaxLength(255);

            builder.Property(p => p.Active)
                .HasDefaultValue(true);

            builder.Property(p => p.Deleted);

            builder.Property(p => p.NameAr)
                .HasMaxLength(45)
                .IsRequired();

            builder.Property(p => p.NameEn)
                .HasMaxLength(45)
                .IsRequired();

            builder.HasQueryFilter(p => !p.Deleted);
            builder.Property(p => p.CountryId)
                .HasMaxLength(45);

            builder.Property(p => p.CreatedById)
                .HasMaxLength(45);

            builder.Property(p => p.CreationDate)
                .HasColumnType("DateTime")
                .HasDefaultValueSql("GETDATE()");

            builder.Property(p => p.ModificationDate)
                .HasColumnType("DateTime");

            builder.Property(p => p.ModifiedById)
                .HasMaxLength(45);

            builder.Property(e => e.CreatedById)
                .HasDefaultValue("system");

        }
    }
}
