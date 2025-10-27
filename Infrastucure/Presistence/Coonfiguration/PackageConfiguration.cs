using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Presistence.Coonfiguration
{
    public class PackageConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.ToTable("Package");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.StartingDate).IsRequired();
            builder.Property(p => p.EndingDate).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.IsRefundable).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)")
                .IsRequired();
            builder.Property(p => p.ChildPrice).HasColumnType("decimal(18,2");
            builder.Property(p => p.CreatedById).HasMaxLength(45).IsRequired();
            builder.Property(p => p.ModifiedById).HasMaxLength(45);
            builder.Property(p => p.CreationDate).HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()").IsRequired();
            builder.Property(p => p.ModificationDate).HasColumnType("DATETIME");
            builder.Property(p => p.Active).HasDefaultValue(true);
            builder.Property(p => p.Deleted).HasDefaultValue(false);
            builder.HasQueryFilter(p => !p.Deleted);
            builder.HasOne(c => c.City)
                .WithMany(p => p.Packages)
                .HasForeignKey(k => k.FromCityId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
