using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Presistence.Coonfiguration
{
    public class AirPortConfiguration : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.ToTable("AirPort");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.NameAr);
            builder.Property(p => p.NameEn);
            builder.Property(p => p.CreatedById).HasMaxLength(45);
            builder.Property(p => p.ModifiedById).HasMaxLength(45);
            builder.Property(p => p.CreationDate).HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()").IsRequired();
            builder.Property(p => p.ModificationDate).HasColumnType("DATETIME");
            builder.Property(p => p.Code);
            builder.Property(p => p.Deleted).HasDefaultValue(false).IsRequired();
            builder.HasQueryFilter(q => !q.Deleted);
            
        }
    }
}
