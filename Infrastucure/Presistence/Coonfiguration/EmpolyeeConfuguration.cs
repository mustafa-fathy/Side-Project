using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Presistence.Coonfiguration
{
    public class EmpolyeeConfuguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.AgentCode)
                .HasMaxLength(20)
                .IsUnicode()
                .IsRequired();

            builder.Property(p => p.ServiceFees)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.Target)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.LastLogin)
                .HasColumnType("DateTime2(7)")
                .IsRequired();

            builder.Property(p => p.Active)
                .HasDefaultValue(true);

            builder.Property(p => p.Deleted)
                .HasDefaultValue(false);

            builder.Property(p => p.CreationDate)
                .HasColumnType("DateTime")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            builder.Property(p => p.ModificationDate)
                .HasColumnType("DateTime");

            builder.Property(p => p.CreatedById)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.ModifiedById)
                .HasMaxLength(20);

            builder.HasQueryFilter(f=>!f.Deleted);
        }
    }
}
