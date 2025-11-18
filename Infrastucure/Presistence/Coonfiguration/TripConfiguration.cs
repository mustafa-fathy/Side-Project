using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Presistence.Coonfiguration
{
    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.ToTable("Trip");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id)
                .HasMaxLength(45)
                .IsRequired();

            builder.Property(p => p.StartingDate)
                .IsRequired();

            builder.Property(p => p.EndingDate)
                .IsRequired();

            builder.Property(p => p.IsRefundable)
                .IsRequired();

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.ChildPrice)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Guests)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(p => p.RemainingGuests);

            builder.Property(p => p.TripHours)
                .IsRequired();

            builder.Property(p => p.Deleted).
                HasDefaultValue(false);

            builder.Property(p => p.Active)
                .HasDefaultValue(true);

            builder.HasQueryFilter(p => !p.Deleted);

            builder.Property(p => p.CreatedById)
                .HasMaxLength(45)
                .IsRequired();

            builder.Property(p => p.CreationDate)
                .HasColumnType("DateTime")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            builder.Property(p => p.ModificationDate)
                .HasColumnType("DateTime");

            builder.Property(p => p.ModifiedById)
                .HasMaxLength(45);

            builder.HasOne(c => c.City)
                .WithMany(t => t.Trips)
                .HasForeignKey(f => f.FromCityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
