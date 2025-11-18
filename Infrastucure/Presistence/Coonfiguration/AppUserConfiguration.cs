using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Presistence.Coonfiguration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.ProfilePicture)
                .HasMaxLength(100);
            //------------------------------------------------------------------
            builder.Property(p => p.Deleted)
                .HasDefaultValue(false);

            builder.HasQueryFilter(p => !p.Deleted);

            builder.Property(p => p.Active)
                .HasDefaultValue(true);

            builder.Property(p => p.CreationDate)
                .HasColumnType("DateTime")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            builder.Property(p => p.ModificationDate)
                .HasColumnType("DateTime");

            builder.Property(p => p.CreatedById)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(p => p.ModifiedById)
                .HasMaxLength(60);

        }
    }
}
